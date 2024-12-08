using Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;

namespace CryptoQuotes.Application.UnitTests;

public static class CryptoQuoteResponseData
{
	public static readonly CryptoQuoteResponse QuoteResponse = new CryptoQuoteResponse
	{
		Status = new StatusDto
		{
			Timestamp = new DateTime(2024, 12, 5, 14, 30, 0, DateTimeKind.Utc)
		},
		Data = new Dictionary<string, List<CryptoDataDto>>
		{
			{
				"BTC", new List<CryptoDataDto>
				{
					new CryptoDataDto
					{
						Symbol = "BTC",
						Quote = new Dictionary<string, QuoteDto>
						{
							{ "USD", new QuoteDto { Price = 50000m } },
							{ "EUR", new QuoteDto { Price = 47000m } }
						}
					}
				}
			},
			{
				"ETH", new List<CryptoDataDto>
				{
					new CryptoDataDto
					{
						Symbol = "ETH",
						Quote = new Dictionary<string, QuoteDto>
						{
							{ "USD", new QuoteDto { Price = 4000m } },
							{ "GBP", new QuoteDto { Price = 3600m } }
						}
					}
				}
			}
		}
	};
}