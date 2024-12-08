namespace Services.CryptoQuotes.Application.Contracts;
public interface IHttpService
{
	Task<string> GetStringAsync(string clientName, string url, CancellationToken cancellationToken);
}
