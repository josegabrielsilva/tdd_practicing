using CriptoBull.Application.Services;
using CriptoBull.Domain.Entities;

namespace CriptoBull.Api.Controllers;

public static class CurrencyEndpoints
{
    public static void MapCurrencyEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/currency/summary", async (List<CurrencyInput> currencies, ICurrencySummaryService service) =>
        {
            var currencySummaries = await service.PriceEnrich(currencies);
            return Results.Ok(currencySummaries);
        });

        endpoints.MapPost("/currency/prices", async (List<CurrencyInput> currencies, ICurrencySummaryService service) =>
        {
            var currencySummaries = await service.Prices(currencies.Select(x => x.Symbol).ToList());
            return Results.Ok(currencySummaries.Select(x => x.price).ToList());
        });
    }
}