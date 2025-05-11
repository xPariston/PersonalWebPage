using System;
using WebPage.Server.FinanceService;
using WebPage.Server.FinanceService.Clients;
using WebPage.Server.FinanceService.DataAccess.ServiceRepository;

namespace WebPage.Server.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //new FinanceDbMockingData().InsertMockingData();
            //new AlphaVantageClient().GetPerformanceAllTime("BMW.DEX");
            IFinanceRetrivalService x = new FinanceRetrivalService(new StockInfoRepository(new StockContext()), new AlphaVantageClient());
            var y = x.GetPerformanceThisYear("BMW.DEX", DateTime.Today);
        }
    }
}
