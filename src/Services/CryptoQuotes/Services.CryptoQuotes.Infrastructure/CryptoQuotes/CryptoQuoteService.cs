using Services.CryptoQuotes.Application.Contracts;
using Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;
using Services.CryptoQuotes.Domain;

namespace Services.CryptoQuotes.Infrastructure.CryptoQuotes;

internal sealed class CryptoQuoteService : ICryptoQuoteService
{
	private readonly IHttpService _httpService;
	private readonly IJsonDeserializer _jsonDeserializer;
	private readonly ICurrencyConversionService _currencyConversionService;

	public CryptoQuoteService(
		IHttpService httpService,
		IJsonDeserializer jsonDeserializer,
		ICurrencyConversionService currencyConversionService)
	{
		_httpService = httpService;
		_jsonDeserializer = jsonDeserializer;
		_currencyConversionService = currencyConversionService;
	}

	public async Task<Result<CryptoQuoteResponse>> GetQuoteAsync(string cryptocurrencyCode,
		CancellationToken cancellationToken)
	{
		try
		{
			string cryptoQuoteUrl = $"cryptocurrency/quotes/latest?symbol={cryptocurrencyCode.ToUpper()}";
			string jsonResponse = await _httpService.GetStringAsync("coinmarketcap", cryptoQuoteUrl, cancellationToken);

			CryptoQuoteResponse? cryptoResponse = _jsonDeserializer.DeserializeJson<CryptoQuoteResponse>(jsonResponse);

			if (cryptoResponse == null || cryptoResponse.Data == null ||
				!cryptoResponse.Data.ContainsKey(cryptocurrencyCode.ToUpper()))
			{
				return Result.Failure<CryptoQuoteResponse>(Error.Failure("No.Data.Found",
					$"No data found for cryptocurrency code {cryptocurrencyCode}"));
			}

			List<CryptoDataDto>? cryptoDataList = cryptoResponse.Data[cryptocurrencyCode.ToUpper()];
			if (cryptoDataList == null || !cryptoDataList.Any())
			{
				return Result.Failure<CryptoQuoteResponse>(Error.Failure("No.Data.Found",
					$"No data found for cryptocurrency code {cryptocurrencyCode}"));
			}

			CryptoDataDto cryptoData = cryptoDataList[0];
			decimal usdPrice = cryptoData.Quote["USD"].Price;

			string[] targetCurrencies = ["EUR", "BRL", "GBP", "AUD"];
			var convertedQuotes = new Dictionary<string, decimal>
			{
				{ "USD", usdPrice }
			};

			foreach (string currency in targetCurrencies)
			{
				Result<decimal> conversionResult = await _currencyConversionService.ConvertCurrencyAsync(currency,"USD", usdPrice, cancellationToken);

				if (conversionResult.IsSuccess)
				{
					convertedQuotes[currency] = conversionResult.Value;
				}
				else
				{
					return Result.Failure<CryptoQuoteResponse>(conversionResult.Error);
				}
			}

			var quoteData = new CryptoDataDto
			{
				Symbol = cryptocurrencyCode.ToUpper(),
				Quote = new Dictionary<string, QuoteDto>()
			};

			foreach (KeyValuePair<string, decimal> kvp in convertedQuotes)
			{
				quoteData.Quote[kvp.Key] = new QuoteDto{Price = kvp.Value};
			}

			Result<CryptoQuoteResponse> result = new CryptoQuoteResponse
			{
				Status = cryptoResponse.Status,
				Data = new Dictionary<string, List<CryptoDataDto>>
				{
					{ cryptocurrencyCode.ToUpper(), new List<CryptoDataDto> { quoteData } }
				}
			};

			return Result.Success(result.Value);
		}
		catch (Exception ex)
		{
			return Result.Failure<CryptoQuoteResponse>(Error.Failure("API.Error", ex.Message));
		}
	}
}
