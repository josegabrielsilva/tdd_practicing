using CriptoBull.Application.Services;
using CriptoBull.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CriptoBull.Api.Endpoints;

public static class CurrencyEndpoints
{
    public static void MapCurrencyEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/currency/summary", async (List<CurrencyInput> currencies, ICurrencySummaryService service) =>
        {
            var currencySummaries = await service.PriceEnrich(currencies);

            return Results.Ok(currencySummaries);
        });

        endpoints.MapPost("/currency/prices", async (List<string> symbols, ICurrencySummaryService service) =>
        {
            var currencySummaries = await service.Prices(symbols);

            return Results.Ok(currencySummaries.Select(x => x.price));
        });
    }
}