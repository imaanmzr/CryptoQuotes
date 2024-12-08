using Services.CryptoQuotes.Domain;

namespace Services.CryptoQuotes.Application.Contracts;
public interface ICurrencyConversionService
{
	Task<Result<decimal>> ConvertCurrencyAsync(string fromCurrency, string toCurrency, decimal amount, CancellationToken cancellationToken);
}