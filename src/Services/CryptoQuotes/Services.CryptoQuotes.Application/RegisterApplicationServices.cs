using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Services.CryptoQuotes.Application;

public static class RegisterApplicationServices
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        Assembly[] serviceAssemblies)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(serviceAssemblies);
        });

        services.AddValidatorsFromAssemblies(serviceAssemblies, includeInternalTypes: true);

		return services;
    }
}
