using System.Text.Json.Serialization;

namespace Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;

public sealed record CryptoQuoteResponse
{
	[JsonPropertyName("status")]
	public StatusDto Status { get; set; }

	[JsonPropertyName("data")]
	public Dictionary<string, List<CryptoDataDto>> Data { get; set; }
}

public sealed record StatusDto
{
	[JsonPropertyName("timestamp")]
	public DateTime Timestamp { get; set; }
}

public sealed record CryptoDataDto
{
	[JsonPropertyName("symbol")]
	public string Symbol { get; set; }

	[JsonPropertyName("quote")]
	public Dictionary<string, QuoteDto> Quote { get; set; }
}

public sealed record QuoteDto
{
	[JsonPropertyName("price")]
	public decimal Price { get; set; }
}
