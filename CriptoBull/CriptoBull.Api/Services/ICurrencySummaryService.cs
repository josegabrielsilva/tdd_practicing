using CriptoBull.Api.Entities;

namespace CriptoBull.Domain.Services;

public interface ICurrencySummaryService
{
    Task<List<CurrencySummary>> PriceEnrich(List<CurrencyInput> currencieInputs);

    Task<List<(string symbol, decimal price)>> Prices(List<string> symbols);
}