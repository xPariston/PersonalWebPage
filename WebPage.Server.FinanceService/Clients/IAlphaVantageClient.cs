using System.Net.Http;
using System.Threading.Tasks;

namespace WebPage.Server.FinanceService.Clients
{
    public interface IAlphaVantageClient
    {
        public Task<HttpResponseMessage> GetPerformanceAllTime(string symbol);

        public Task<HttpResponseMessage> GetPerformanceLast100Days(string symbol);
    }
}
