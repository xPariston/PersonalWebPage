﻿using System;

namespace WebPage.Server.FinanceService.DataAccess.ServiceRepository
{
    public class StockPerformance
    {
        public int StockPerformanceId { get; set; }

        public DateTime valueDate { get; set; }

        public double close { get; set; }

        public int StockInfoId { get; set; }
    }
}
