using FamilyStockBet;
using FamilyStockBet.Client;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var t = Task.Run(() => FinanceApi.GetProductAsync("query?function=TIME_SERIES_DAILY&symbol=IBM&apikey=demo"));
            //t.Wait();

            //Shareholders test = new Shareholders();
            var controller = new FinanceController(new FinanceServiceClient());
            testController(controller).GetAwaiter().GetResult();
            _ = System.Console.ReadKey();

        }

        private static async Task testController(FinanceController controller)
        {
            _ = await controller.InitializePortfolios();
            controller.PrintShortStanding();
        }
    }
}
