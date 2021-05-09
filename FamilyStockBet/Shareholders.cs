using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyStockBet
{
    public class Shareholders
    {
        public List<Portfolio> ListOfShareholders;
        public Shareholders()
        {
            ListOfShareholders = new List<Portfolio>()
            {
                new Portfolio(
                    stockSymbols: new string[3]{"BA","HOT.DE","BAYN.DE"},
                    nameOfOwner: "Gunnar"
                    ),
                new Portfolio(
                    stockSymbols: new string[3]{"EJTTF","R6C.DE","CCL"},
                    nameOfOwner: "Paul"
                    ),
                new Portfolio(
                    stockSymbols: new string[3]{"ORCL","B4B.DE","ASL.DE"},
                    nameOfOwner: "Patrick"
                    ),
            };

            var t = Task.Run(() => ReadAllStockData());
            t.Wait();
        }

        public async Task ReadAllStockData()
        {
            foreach (var shareholder in ListOfShareholders)
            {
                bool temp = await shareholder.GetAllPortfolioStocks();
            }
        }
    }
}
