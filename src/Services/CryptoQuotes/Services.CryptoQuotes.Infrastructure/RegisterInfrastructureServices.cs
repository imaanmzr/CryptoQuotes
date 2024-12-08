using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Services.CryptoQuotes.Application.Contracts;
using Services.CryptoQuotes.Infrastructure.CryptoQuotes;
using Services.CryptoQuotes.Presentation.CryptoQuotes;

namespace Services.CryptoQuotes.Infrastructure;
public static class RegisterInfrastructureServices
{
	public static void MapEndpoints(IEndpointRouteBuilder app)
	{
		GetCryptoQuotes.MapEndpoint(app);
	}

	public static IServiceCollection AddCryptoQuotesService(this IServiceCollection services, IConfiguration configuration)
	{
        string coinMarketCapApiKey = Environment.GetEnvironmentVariable("COINMARKETCAP_API_KEY")
                                     ?? throw new InvalidOperationException("CoinMarketCap API key is missing.");

        string exchangeRatesApiKey = Environment.GetEnvironmentVariable("EXCHANGERATES_API_KEY")
                                     ?? throw new InvalidOperationException("ExchangeRates API key is missing.");

        services.Configure<CoinMarketCapSettings>(configuration.GetSection("CoinMarketCap"));
        services.PostConfigure<CoinMarketCapSettings>(settings =>
        {
            settings.ApiKey = coinMarketCapApiKey;
        });

        services.Configure<ExchangeRatesSettings>(configuration.GetSection("ExchangeRates"));
        services.PostConfigure<ExchangeRatesSettings>(settings =>
        {
            settings.ApiKey = exchangeRatesApiKey;
        });

        services.AddHttpClient("coinmarketcap", (serviceProvider, httpClient) =>
		{
			CoinMarketCapSettings coinMarketCapSettings = serviceProvider.GetRequiredService<IOptions<CoinMarketCapSettings>>().Value;
			httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", coinMarketCapSettings.ApiKey);
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			httpClient.BaseAddress = new Uri(coinMarketCapSettings.BaseUrl);
		});

		services.AddHttpClient("exchangerates", (serviceProvider, httpClient) =>
		{
			ExchangeRatesSettings exchangeRatesSettings = serviceProvider.GetRequiredService<IOptions<ExchangeRatesSettings>>().Value;
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {exchangeRatesSettings.ApiKey}");
			httpClient.BaseAddress = new Uri(exchangeRatesSettings.BaseUrl);
		});

		services.AddScoped<ICryptoQuoteService, CryptoQuoteService>();
		services.AddScoped<IHttpService, HttpService>();
		services.AddScoped<ICurrencyConversionService, CurrencyConversionService>();
		services.AddScoped<IJsonDeserializer, JsonDeserializer>();

		return services;
	}
}
