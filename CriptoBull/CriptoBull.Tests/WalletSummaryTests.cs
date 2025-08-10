using CriptoBull.Api.Entities;
using FluentAssertions;

namespace CriptoBull.Tests;

public class WalletSummaryTests
{
    [Fact]
    public void Test1()
    {
        var walletSummary = new CurrencySummary(
            CurrencyInput: new CurrencyInput(
                Symbol: "TIA", 
                TokenQuantity: 100, 
                AveragePrice: 4m), 
            CurrentPrice: 8m);

        Math.Round(walletSummary.Variation)
            .Should()
            .Be(100);
    }
}