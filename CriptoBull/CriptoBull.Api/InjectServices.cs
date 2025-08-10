using CriptoBull.Api.Integrations;
using CriptoBull.Domain.Services;

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
}