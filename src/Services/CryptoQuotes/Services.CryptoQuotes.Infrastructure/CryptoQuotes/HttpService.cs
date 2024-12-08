using Services.CryptoQuotes.Application.Contracts;

namespace Services.CryptoQuotes.Infrastructure.CryptoQuotes;
internal sealed class HttpService : IHttpService
{
	private readonly IHttpClientFactory _httpClientFactory;

	public HttpService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<string> GetStringAsync(string clientName, string url, CancellationToken cancellationToken)
	{
		HttpClient client = _httpClientFactory.CreateClient(clientName);

		return await client.GetStringAsync(url, cancellationToken);
	}
}
