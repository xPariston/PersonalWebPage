using FamilyStockBet.APIFiles;
using System.Threading.Tasks;

namespace FamilyStockBet
{
    public class Stock
    {
        string Symbol;
        string StockName;
        StockInfoDaily StockDaily;
        decimal StockPriceStart;
        decimal StockPriceChangeInPercent;

        internal Stock(string symbol)
        {
            Symbol = symbol;
        }

        internal async Task<bool> ReadStockProperties()
        {
            bool success = await CallDailyAPI();
            if (success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        async Task<bool> CallDailyAPI()
        {
            StockDaily = await APIFunctions.GetProductDailyAsync(Symbol);
            if (StockDaily != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
