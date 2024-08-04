
using CriptoBull.Application.Integrations;
using CriptoBull.Domain.Entities;

namespace CriptoBull.Application.Services;

public class CurrencySummaryService(ICoinMarketCapIntegration coinMarketCapIntegration) : ICurrencySummaryService
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

    public async Task<List<(string symbol, decimal price)>> Prices(List<string> currencies)
    {
        string symbols = string.Join(",", currencies);

        var currentPrices = await coinMarketCapIntegration.GetCurrentPrices(symbols);

        return currentPrices
            .Select(x => (x.Key, x.Value))
            .ToList();
    }
}