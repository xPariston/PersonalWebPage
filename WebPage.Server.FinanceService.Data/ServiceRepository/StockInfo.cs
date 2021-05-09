using System;

namespace WebPage.Server.FinanceService.Data.ServiceRepository
{
    public class StockInfo
    {
        public int StockInfoId { get; set; }

        public string Information { get; set; }

        public string Symbol { get; set; }

        public string FullName { get; set; }

        public DateTime LastRefreshed { get; set; }

        public DateTime FirstValueDate { get; set; }
    }
}
