namespace Services.CryptoQuotes.Domain.ValueObjects;

public sealed record CryptoData
{
	public string Symbol { get; init; }
	public Dictionary<string, Quote>? Quote { get; init; }

	public CryptoData(string symbol, Dictionary<string, Quote> quote)
	{
		if (string.IsNullOrWhiteSpace(symbol))
		{
			Result.Failure<CryptoData>(CryptoQuoteErrors.SymbolIsNullOrEmpty);
		}

		if (!System.Text.RegularExpressions.Regex.IsMatch(symbol, "^[A-Za-z0-9]{1,9}$"))
		{
			Result.Failure<CryptoData>(CryptoQuoteErrors.SymbolIsInvalid);
		}

		if (quote == null || quote.Count == 0)
		{
			Result.Failure<CryptoData>(CryptoQuoteErrors.QuoteIsNullOrEmpty);
		}

		Symbol = symbol;
		Quote = quote;
	}
}