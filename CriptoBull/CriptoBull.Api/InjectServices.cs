using CriptoBull.Api;
using CriptoBull.Api.Integrations;
using CriptoBull.Domain.Services;
using CriptoBull.Integrations;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;

namespace CriptoBull.Api;

public static class InjectServices
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddScoped<ICurrencySummaryService, CurrencySummaryService>();

        return service;
    }

    public static IServiceCollection AddIntegrations(this IServiceCollection service)
    {
        service.AddScoped<ICoinMarketCapIntegration, CoinMarketCapIntegration>();

        return service;
    }

    public static IServiceCollection AddAuthentication(
        this IServiceCollection service,
        IConfiguration configuration)
    {
        service.AddKeycloakWebApiAuthentication(configuration);

        return service;
    }

    public static IServiceCollection AddAuthorization(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminAndUser", builder =>
            {
                builder.RequireResourceRoles("ViewCurrencyPrice");
            });
        }).AddKeycloakAuthorization(configuration);

        return services;
    }
}