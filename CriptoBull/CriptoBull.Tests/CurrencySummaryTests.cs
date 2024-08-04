using CriptoBull.Domain.Entities;
using FluentAssertions;

namespace CriptoBull.Tests
{
    public class CurrencySummaryTests
    {
        [Fact]
        public void Variation_WhenAveragePriceIsLowerThanZero_ShouldReturnZero()
        {
            CurrencyInput currencyInput = new("XYZ", 10, 0);

            CurrencySummary currencySummary = new(currencyInput, 10);

            currencySummary.Variation.Should().Be(0);
        }

        [Theory]
        [InlineData(10, 20, 100)]
        [InlineData(10, 15, 50)]
        [InlineData(10, 10, 0)]
        [InlineData(10, 5, -50)]
        [InlineData(10, 0, -100)]
        public void Variation_WhenAveragePriceIsGreatherThanZero_ShouldReturnRespectiveVariation(
            decimal averagePrice,
            decimal currentPrice,
            decimal expectedVariation)
        {
            CurrencyInput currencyInput = new("XYZ", 10, averagePrice);

            CurrencySummary currencySummary = new(currencyInput, currentPrice);

            currencySummary.Variation.Should().Be(expectedVariation);
        }

        [Theory]
        [InlineData(10, 20, 200)]
        [InlineData(100, 23.6, 2360)]
        public void InvestedCapital_WhenValidData_ShouldReturnExpectedResults(
            decimal tokenQuantity,
            decimal averagePrice,
            decimal expectedInvestedCapital)
        {
            CurrencyInput currencyInput = new("XYZ", tokenQuantity, averagePrice);

            CurrencySummary currencySummary = new(currencyInput, 0);

            currencySummary.InvestedCapital.Should().Be(expectedInvestedCapital);
        }

        [Theory]
        [InlineData(10, 20, 200)]
        [InlineData(100, 23.6, 2360)]
        public void MarketValue_WhenValidData_ShouldReturnExpectedResults(
            decimal tokenQuantity,
            decimal currentPrice,
            decimal expectedMarketValue)
        {
            CurrencyInput currencyInput = new("XYZ", tokenQuantity, 0);

            CurrencySummary currencySummary = new(currencyInput, currentPrice);

            currencySummary.MarketValue.Should().Be(expectedMarketValue);
        }

        [Theory]
        [InlineData(10, 10, 30, 200)]
        [InlineData(10, 3.5, 2, -15)]
        public void Gain_WhenValidData_ShouldReturnExpectedResults(
            decimal tokenQuantity,
            decimal averagePrice,
            decimal currentPrice,
            decimal expectedGain)
        {
            CurrencyInput currencyInput = new("XYZ", tokenQuantity, averagePrice);

            CurrencySummary currencySummary = new(currencyInput, currentPrice);

            currencySummary.Gain.Should().Be(expectedGain);
        }
    }
}