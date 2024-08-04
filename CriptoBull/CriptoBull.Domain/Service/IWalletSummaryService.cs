namespace CriptoBull.Domain.Service;

public interface IWalletSummaryService
{
    Task<List<(string symbol, decimal price)>> BuildWalletSummary(List<string> symbols);
}