using Microsoft.Extensions.Options;
using Services.CryptoQuotes.Application.Contracts;
using Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;
using Services.CryptoQuotes.Domain;

namespace Services.CryptoQuotes.Infrastructure.CryptoQuotes;
internal sealed class CurrencyConversionService : ICurrencyConversionService
{
	private readonly IHttpService _httpService;
	private readonly IJsonDeserializer _jsonDeserializer;
	private readonly string _apiKey;

	public CurrencyConversionService(
		IHttpService httpService,
		IOptions<ExchangeRatesSettings> exchangeRatesSettings,
		IJsonDeserializer jsonDeserializer)
	{
		_httpService = httpService;
		_jsonDeserializer = jsonDeserializer;
		_apiKey = exchangeRatesSettings.Value.ApiKey;
	}

	public async Task<Result<decimal>> ConvertCurrencyAsync(string fromCurrency, string toCurrency, decimal amount, CancellationToken cancellationToken)
    {
        try
        {
			string url = $"latest?access_key={_apiKey}&symbols=USD,EUR,BRL,GBP,AUD";
			string response = await _httpService.GetStringAsync("exchangerates", url, cancellationToken);

			ExchangeRatesResponse? exchangeRatesResponse = _jsonDeserializer.DeserializeJson<ExchangeRatesResponse>(response);

			if (exchangeRatesResponse == null || !exchangeRatesResponse.Success)
			{
				return Result.Failure<decimal>(Error.Failure("Failed.To.Retrieve", "Failed to retrieve exchange rates."));
			}

			if (exchangeRatesResponse.Rates.TryGetValue(fromCurrency, out decimal fromCurrencyRate) &&
			    exchangeRatesResponse.Rates.TryGetValue(toCurrency, out decimal toCurrencyRate))
			{
				decimal convertedAmount = amount * fromCurrencyRate / toCurrencyRate;

				return Result.Success(convertedAmount);
			}

			return Result.Failure<decimal>(Error.Failure("Invalid.Currency", "Invalid or missing currency rates."));
		}
		catch (Exception ex)
		{
			return Result.Failure<decimal>(Error.Failure("API.Error", ex.Message));
		}
	}
}
