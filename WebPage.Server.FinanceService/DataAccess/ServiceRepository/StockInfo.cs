using System;
using System.Collections.Generic;

namespace WebPage.Server.FinanceService.DataAccess.ServiceRepository
{
    public class StockInfo
    {
        public int StockInfoId { get; set; }

        public string Information { get; set; }

        public string Symbol { get; set; }

        public string FullName { get; set; }

        public DateTime LastRefreshed { get; set; }

        public DateTime FirstValueDate { get; set; }

        public IReadOnlyCollection<StockPerformance> Performance { get; set; }
    }
}
