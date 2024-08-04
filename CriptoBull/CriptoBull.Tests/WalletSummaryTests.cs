using CriptoBull.Domain.Entities;
using FluentAssertions;

namespace CriptoBull.Tests
{
    public class WalletSummaryTests
    {
        [Fact]
        public void Test1()
        {
            var walletSummary = new CurrencySummary(
                currencyInput: new CurrencyInput(
                    symbol: "TIA", 
                    tokenQuantity: 100, 
                    averagePrice: 4m), 
                currentPrice: 8m);

            Math.Round(walletSummary.Variation)
                .Should()
                .Be(100);
        }
    }
}