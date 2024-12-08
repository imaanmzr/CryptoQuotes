using System.Text.Json.Serialization;

namespace Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;
public sealed record ExchangeRatesResponse
{
	[JsonPropertyName("success")]
	public bool Success { get; set; }

	[JsonPropertyName("rates")]
	public Dictionary<string, decimal> Rates { get; set; } = [];
}
