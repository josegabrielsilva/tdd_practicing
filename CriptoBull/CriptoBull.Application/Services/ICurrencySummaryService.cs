using CriptoBull.Domain.Entities;

namespace CriptoBull.Application.Services;

public interface ICurrencySummaryService
{
    Task<List<CurrencySummary>> PriceEnrich(List<CurrencyInput> currencieInputs);

    Task<List<(string symbol, decimal price)>> Prices(List<string> symbols);
}