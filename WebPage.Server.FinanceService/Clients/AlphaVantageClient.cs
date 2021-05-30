using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebPage.Server.FinanceService.Clients
{
    public class AlphaVantageClient : IAlphaVantageClient
    {
        private UriBuilder _requestUri = new UriBuilder(
            schemeName: "https",
            hostName: "www.alphavantage.co");

        private string _apiKey = "UGEQWSSUECMLKYV4";

        public AlphaVantageClient()
        {
            _requestUri.Path = "query";
        }

        public async Task<HttpResponseMessage> GetPerformanceAllTime(string symbol)
        {
            _requestUri.Query = $"function=TIME_SERIES_DAILY&symbol={symbol}&outputsize=full&apikey={_apiKey}";
            return await QueryAlphavantage(_requestUri.ToString());
        }

        public async Task<HttpResponseMessage> GetPerformanceLast100Days(string symbol)
        {
            _requestUri.Query = $"function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_apiKey}";
            return await QueryAlphavantage(_requestUri.ToString());
        }

        private async Task<HttpResponseMessage> QueryAlphavantage(string requestUri)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpClient client = new HttpClient();
            return await client.GetAsync(requestUri);
        }
    }
}
