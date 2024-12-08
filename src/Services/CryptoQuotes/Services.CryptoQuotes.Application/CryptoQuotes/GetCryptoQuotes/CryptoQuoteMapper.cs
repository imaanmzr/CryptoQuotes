using Services.CryptoQuotes.Domain;
using Services.CryptoQuotes.Domain.ValueObjects;

namespace Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;
public static class CryptoQuoteMapper
{
	public static CryptoQuote Map(CryptoQuoteResponse quoteResponse)
	{
		var status = new Status(quoteResponse.Status.Timestamp);

		var data = quoteResponse.Data.ToDictionary(
			item => item.Key,
			item => item.Value.Select(cryptoData => new CryptoData
			(
				cryptoData.Symbol,
				cryptoData.Quote.ToDictionary(q => q.Key, q => new Quote (q.Value.Price))
			)).ToList()
		);

		Result<CryptoQuote> result = CryptoQuote.Create(status, data);

		return result.Value;
	}
}
