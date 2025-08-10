
using CriptoBull.Api.Integrations;
using CriptoBull.Api.Entities;
using Microsoft.Extensions.Logging;

namespace CriptoBull.Domain.Services;

public class CurrencySummaryService(ICoinMarketCapIntegration coinMarketCapIntegration, ILogger<CurrencySummaryService> logger) : ICurrencySummaryService
{
    public async Task<List<CurrencySummary>> PriceEnrich(List<CurrencyInput> currencieInputs)
    {
        string symbols = string.Join(",", currencieInputs.Select(x => x.Symbol));

        var currentPrices = await coinMarketCapIntegration.GetCurrentPrices(symbols);

        List<CurrencySummary> currencySummaries = [];

        foreach(var currencyInput in currencieInputs)
        {
            currentPrices.TryGetValue(currencyInput.Symbol, out decimal currentPrice);

            currencySummaries.Add(new CurrencySummary(currencyInput, currentPrice));
        }

        return currencySummaries;
    }

    public async Task<List<(string symbol, decimal price)>> Prices(List<string> symbols)
    {
        string joinedSymbols = string.Join(",", symbols);

        logger.LogInformation("Fetching current prices");

        var currentPrices = await coinMarketCapIntegration.GetCurrentPrices(joinedSymbols);

        logger.LogInformation("Fetched current prices");

        return [.. currentPrices.Select(x => (x.Key, x.Value))];
    }
}