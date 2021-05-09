using System.Text.Json.Serialization;

namespace WebPage.Server.FinanceService.Data.AlphaVantageApi
{
    public class StockMetadata
    {
        [JsonPropertyName("1. Information")]
        public string Information { get; set; }

        [JsonPropertyName("2. Symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("3. Last Refreshed")]
        public string LastRefreshed { get; set; }

        [JsonPropertyName("4. Output Size")]
        public string OutputSize { get; set; }

        [JsonPropertyName("5. Time Zone")]
        public string _5TimeZone { get; set; }
    }
}
