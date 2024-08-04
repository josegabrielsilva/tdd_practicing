using CriptoBull.Application.Integrations;
using CriptoBull.Application.Services;
using CriptoBull.Integrations;
using Microsoft.Extensions.DependencyInjection;

namespace CriptoBull.IoC
{
    public static class AddInjections
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
}