using System;
using System.Text.Json.Serialization;

namespace WebPage.Server.FinanceService.DataAccess.ServiceRepository
{
    public class StockPerformance
    {
        public int StockPerformanceId { get; set; }

        public DateTime valueDate { get; set; }

        [JsonPropertyName("4. close")]
        public double close { get; set; }

        public int StockInfoId { get; set; }
    }
}
