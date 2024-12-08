namespace Services.CryptoQuotes.Domain;
public static class CryptoQuoteErrors
{
	public static readonly Error StatusIsNull = Error.Failure(
		"CryptoQuote.Status.NullValue", "The status can't be null.");

	public static readonly Error DataIsNull = Error.Failure(
		"CryptoQuote.Data.NullValue", "Data can't be null.");

	public static readonly Error SymbolIsNullOrEmpty = Error.Failure(
		"CryptoData.SymbolIsNull", "Symbol cannot be null or empty.");

	public static readonly Error SymbolIsInvalid = Error.Failure(
		"CryptoData.SymbolIsInvalid", "Symbol must be alphanumeric and between 1 to 9 characters.");

	public static readonly Error QuoteIsNullOrEmpty = Error.Failure(
		"CryptoData.QuoteIsNullOrEmpty", "Quote dictionary must not be null and must contain at least one entry.");
}
