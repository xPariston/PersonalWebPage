using System.Text.Json.Serialization;

namespace Test.Stock
{
    public class StockData
    {

        [JsonPropertyName("1. open")]
        public decimal Open { get; set; }

        public decimal High { get; set; }
        public decimal Low { get; set; }

        public decimal Close { get; set; }
        public decimal Volume { get; set; }

    }
}
