using CriptoBull.Application.Services;
using CriptoBull.Domain.Entities;

namespace CriptoBull.Api.Controllers;

public static class WalletEndpoints
{
    public static void MapWalletEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/wallet/summary", async (List<CurrencyInput> currencies, ICurrencySummaryService service) =>
        {
            var currencySummaries = await service.PriceEnrich(currencies);
            return Results.Ok(new WalletSummary(currencySummaries));
        });
    }
}