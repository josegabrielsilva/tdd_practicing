using CriptoBull.Application.Integrations;
using CriptoBull.Application.Services;
using CriptoBull.Integrations;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CriptoBull.IoC
{
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
                    builder
                        .RequireResourceRoles("ViewCurrencyPrice"); // Resource/Client role is fetched from token
                });
            }).AddKeycloakAuthorization(configuration);

            return services;
        }
    }
}