using CriptoBull.Application.Integrations;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CriptoBull.Integrations;

public sealed class CoinMarketCapIntegration : ICoinMarketCapIntegration
{
    private const string ApiKey = "";
    private const string BaseUrl = "https://pro-api.coinmarketcap.com/v1/";

    public async Task<Dictionary<string, decimal>> GetCurrentPrices(string symbols)
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(BaseUrl);
        httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", ApiKey);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await httpClient.GetAsync($"cryptocurrency/quotes/latest?symbol={symbols}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Falha ao obter dados: {response.ReasonPhrase}");
        }

        var responseString = await response.Content.ReadAsStringAsync();
        var responseJson = JsonDocument.Parse(responseString);
        var prices = new Dictionary<string, decimal>();

        foreach (var symbol in symbols.Split(','))
        {
            var price = responseJson.RootElement
                .GetProperty("data")
                .GetProperty(symbol)
                .GetProperty("quote")
                .GetProperty("USD")
                .GetProperty("price")
                .GetDecimal();

            prices.Add(symbol, price);
        }

        return prices;
    }
}