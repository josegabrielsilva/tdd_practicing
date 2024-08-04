namespace CriptoBull.Application.Integrations;

public interface ICoinMarketCapIntegration
{
    Task<Dictionary<string, decimal>> GetCurrentPrices(string symbols);
}