namespace CriptoBull.Domain.Entities;

public sealed class CurrencyInput(
    string symbol,
    decimal tokenQuantity,
    decimal averagePrice)
{
    public string Symbol { get; private set; } = symbol;

    public decimal AveragePrice { get; private set; } = averagePrice;

    public decimal TokenQuantity { get; private set; } = tokenQuantity;
}