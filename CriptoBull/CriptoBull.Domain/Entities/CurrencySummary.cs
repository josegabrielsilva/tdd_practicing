namespace CriptoBull.Domain.Entities;

public sealed record CurrencySummary(CurrencyInput CurrencyInput, decimal CurrentPrice)
{
    public decimal Variation
    {
        get => CurrencyInput.AveragePrice > 0
            ? (CurrentPrice - CurrencyInput.AveragePrice) / CurrencyInput.AveragePrice * 100
            : 0;
    }

    public decimal InvestedCapital
    {
        get => CurrencyInput.TokenQuantity * CurrencyInput.AveragePrice;
    }

    public decimal MarketValue
    {
        get => CurrencyInput.TokenQuantity * CurrentPrice;
    }

    public decimal Gain
    {
        get => MarketValue - InvestedCapital;
    }
}