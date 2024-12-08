using Services.CryptoQuotes.Domain.ValueObjects;

namespace Services.CryptoQuotes.Domain;
public sealed class CryptoQuote
{
	public Status? Status { get; private set; }

	public Dictionary<string, List<CryptoData>>? Data { get; private set; }

	public static Result<CryptoQuote> Create(Status? status, Dictionary<string, List<CryptoData>>? data)
	{
		if (status is null)
		{
			return Result.Failure<CryptoQuote>(CryptoQuoteErrors.StatusIsNull);
		}

		if (data is null)
		{
			return Result.Failure<CryptoQuote>(CryptoQuoteErrors.DataIsNull);
		}

		return new CryptoQuote
		{
			Status = status,
			Data = data
		};
	}
}