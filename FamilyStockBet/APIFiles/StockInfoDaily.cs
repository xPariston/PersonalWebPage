using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FamilyStockBet.APIFiles
{
    public class StockInfoDaily
    {
        [JsonPropertyName("Meta Data")] 
        public StockMetadata MetaData { get; set; }

        [JsonPropertyName("Time Series (Daily)")]
        public Dictionary<string, StockTimestamp> TimeSeriesDaily { get; set; }
    }
}
