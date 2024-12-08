using Services.CryptoQuotes.Domain.ValueObjects;

namespace CryptoQuotes.Domain.UnitTests.CryptoQuotes;

public static class CryptoQuoteData
{
	public static readonly Status Status = new(new DateTime(2024, 12, 5, 14, 30, 0, DateTimeKind.Utc));
	public static readonly Dictionary<string, List<CryptoData>> Data = new()
	{
		{
			"BTC", new List<CryptoData>
			{
				new CryptoData(
					symbol: "BTC",
					quote: new Dictionary<string, Quote>
					{
						{ "USD", new Quote(price: 50000m) },
						{ "EUR", new Quote(price: 47000m) }
					}
				)
			}
		},
		{
			"ETH", new List<CryptoData>
			{
				new CryptoData(
					symbol: "ETH",
					quote: new Dictionary<string, Quote>
					{
						{ "USD", new Quote(price: 4000m) },
						{ "GBP", new Quote(price: 3600m) }
					}
				)
			}
		}
	};
}