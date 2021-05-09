using System.Text.Json.Serialization;

namespace WebPage.Server.FinanceService.Data.AlphaVantageApi
{
    public class StockTimestamp
    {
        [JsonPropertyName("1. open")]
        public string open { get; set; }

        [JsonPropertyName("2. high")]
        public string high { get; set; }

        [JsonPropertyName("3. low")]
        public string low { get; set; }

        [JsonPropertyName("4. close")]
        public string close { get; set; }

        [JsonPropertyName("5. volume")]
        public string volume { get; set; }
    }
}
