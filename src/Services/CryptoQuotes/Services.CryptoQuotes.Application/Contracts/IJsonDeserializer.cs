namespace Services.CryptoQuotes.Application.Contracts;
public interface IJsonDeserializer
{
	T? DeserializeJson<T>(string jsonResponse);
}