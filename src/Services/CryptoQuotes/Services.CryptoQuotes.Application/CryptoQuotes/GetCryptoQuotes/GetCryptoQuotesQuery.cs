using MediatR;
using Services.CryptoQuotes.Domain;

namespace Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;

public sealed record GetCryptoQuotesQuery(string CryptocurrencyCode) : IRequest<Result<CryptoQuoteResponse>>;
