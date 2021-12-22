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
        public FinanceServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private UriBuilder _requestUri = new UriBuilder
        (
           scheme: "https",
           host: "localhost",
           portNumber: 7137
        );
        private readonly HttpClient _httpClient;

        public async Task<Dictionary<DateTime, double>> GetPerformanceThisYear(string symbol)
        {
            _requestUri.Path = $"Financial/stock/{symbol}/performance-this-year";
            var response = await _httpClient.GetAsync(_requestUri.ToString());
            //var response = await client.SendAsync(request);
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
