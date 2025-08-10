namespace CriptoBull.Api.Integrations;

public interface ICoinMarketCapIntegration
{
    Task<Dictionary<string, decimal>> GetCurrentPrices(string symbols);
}