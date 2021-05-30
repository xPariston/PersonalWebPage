using System.Collections.Generic;

namespace FamilyStockBet.Contracts
{
    public class Portfolio
    {
        public List<Stock> Stocks { get; set; }
        public string NameOfOwner { get; set; }
    }
}
