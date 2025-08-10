namespace CriptoBull.Api.Entities;

public sealed record WalletSummary
{
    private readonly List<CurrencySummary> CurrencySummaries = [];

    public WalletSummary(List<CurrencySummary> currencySummaries)
    {
        CurrencySummaries.AddRange(currencySummaries);
    }

    public decimal GainSummary
    {
        get
        {
            var result = CurrencySummaries.Sum(x => x.Gain);

            return Math.Round(result, 2);
        }
    }
    
    public decimal VariationSummary
    {
        get
        {
            decimal investedCapitalSum = CurrencySummaries.Sum(x => x.InvestedCapital);

            decimal result = (CurrencySummaries.Sum(x => x.MarketValue) - investedCapitalSum) / investedCapitalSum * 100;

            return Math.Round(result, 2);
        }
    }
}