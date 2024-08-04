namespace CriptoBull.Domain.Entities;

public sealed class CurrencySummary(CurrencyInput currencyInput, decimal currentPrice)
{
    public decimal CurrentPrice { get; private set; } = currentPrice;

    public string Symbol { get; set; } = currencyInput.Symbol;

    public decimal Variation
    {
        get => currencyInput.AveragePrice > 0
            ? (CurrentPrice - currencyInput.AveragePrice) / currencyInput.AveragePrice * 100
            : 0;
    }

    public decimal InvestedCapital
    {
        get => currencyInput.TokenQuantity * currencyInput.AveragePrice;
    }

    public decimal MarketValue
    {
        get => currencyInput.TokenQuantity * CurrentPrice;
    }

    public decimal Gain
    {
        get => MarketValue - InvestedCapital;
    }
}