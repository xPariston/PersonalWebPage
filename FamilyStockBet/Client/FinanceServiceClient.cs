using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FamilyStockBet.Client
{
    public class FinanceServiceClient : IFinanceServiceClient
    {
        private UriBuilder _requestUri = new UriBuilder
        (
           scheme: "https",
           host: "localhost",
           portNumber: 5001
        );

        public async Task<Dictionary<DateTime, double>> GetPerformanceThisYear(string symbol)
        {
            _requestUri.Path = $"stock/{symbol}/performance-this-year";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_requestUri.ToString());
            if (response.IsSuccessStatusCode)
            {
                var resposneValue = JsonSerializer.Deserialize<Dictionary<string, double>>(await response.Content.ReadAsStringAsync());
                return resposneValue
                    .ToDictionary(key => DateTime.Parse(key.Key), value => value.Value);
            }
            else
            {
                return new Dictionary<DateTime, double>();
            }
        }
    }
}
