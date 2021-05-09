using WebPage.Server.Console.Database;

namespace WebPage.Server.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new FinanceDbMockingData().InsertMockingData();
        }
    }
}
