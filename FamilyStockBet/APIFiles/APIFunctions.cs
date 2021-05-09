using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FamilyStockBet.APIFiles
{
    internal static class APIFunctions
    { 
        static string apiSchlüssel = "UGEQWSSUECMLKYV4";
        internal static async Task<StockInfoDaily> GetProductDailyAsync(string symbol)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.alphavantage.co");
            client.DefaultRequestHeaders.Accept.Clear();

            string path = "query?function=TIME_SERIES_DAILY&symbol=" + symbol + "&apikey=" + apiSchlüssel;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                //var resposneJSON = JsonDocument.Parse(responseString);
                //var time = resposneJSON.RootElement.GetProperty("Time Series (Daily)");
                //var datapoints = time.EnumerateObject();

                var stockDaily = JsonSerializer.Deserialize<StockInfoDaily>(responseString);
                var DailyValues = stockDaily.TimeSeriesDaily.Values;
                List<decimal> CloseValues = new List<decimal>();
                foreach (var value in DailyValues)
                {
                    string close = value.close.Replace(".", ",");
                    CloseValues.Add(decimal.Parse(close));
                }
                return stockDaily;
            }
            else
            {
                return null;
            }
        }
    }
}
