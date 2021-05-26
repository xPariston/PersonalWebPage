using WebPage.Server.FinanceService.Clients;

namespace WebPage.Server.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //new FinanceDbMockingData().InsertMockingData();
            new AlphaVantageClient().GetPerformanceAllTime("BMW.DEX");
        }
    }
}
