using System;
using System.Collections.Generic;

namespace FamilyStockBet.Contracts
{
    public class Stock
    {
        public string Symbol { get; set; }

        public string StockName { get; set; }

        public double StockPriceStart { get; set; }

        public IDictionary<DateTime, double> StockValues { get; set; }

        public IDictionary<DateTime, double> StockRelativeValues { get; set; }

        public double StockLastRelativeValues { get; set; }
    }
}
