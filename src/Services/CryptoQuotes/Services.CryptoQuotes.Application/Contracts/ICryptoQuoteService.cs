using Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;
using Services.CryptoQuotes.Domain;

namespace Services.CryptoQuotes.Application.Contracts;
public interface ICryptoQuoteService
{
	Task<Result<CryptoQuoteResponse>> GetQuoteAsync(string cryptocurrencyCode, CancellationToken cancellationToken);
}
