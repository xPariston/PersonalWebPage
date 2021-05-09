using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyStockBet
{
    public class Portfolio
    {
        public List<Stock> Stocks;
        public string NameOfOwner;

        public Portfolio(string[] stockSymbols, string nameOfOwner)
        {
            NameOfOwner = nameOfOwner;

            Stocks = new List<Stock>();
            foreach (string symbol in stockSymbols)
            {
                Stocks.Add(new Stock(symbol));
            }
        }

        public async Task<bool> GetAllPortfolioStocks()
        {
            bool success = true;
            foreach (var stock in Stocks)
            {
                bool temp = await stock.ReadStockProperties();
                if (!temp)
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
