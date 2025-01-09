namespace CriptoBull.Domain.Entities;

public sealed record CurrencyInput(
    string Symbol,
    decimal TokenQuantity,
    decimal AveragePrice);