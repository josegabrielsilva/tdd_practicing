namespace CriptoBull.Api.Entities;

public sealed record CurrencyInput
    (
        string Symbol,
        decimal TokenQuantity,
        decimal AveragePrice
    );