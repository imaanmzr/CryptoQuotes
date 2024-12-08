using System.Text.Json;
using Services.CryptoQuotes.Application.Contracts;

namespace Services.CryptoQuotes.Infrastructure.CryptoQuotes;
internal sealed class JsonDeserializer : IJsonDeserializer
{
	private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
	{
		PropertyNameCaseInsensitive = true
	};

	public T? DeserializeJson<T>(string jsonResponse)
	{
		return JsonSerializer.Deserialize<T>(jsonResponse, JsonSerializerOptions);
	}
}
