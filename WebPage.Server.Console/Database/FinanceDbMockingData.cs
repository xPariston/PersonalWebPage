using System;
using System.Collections.Generic;
using WebPage.Server.FinanceService.DataAccess.ServiceRepository;

namespace WebPage.Server.Console.Database
{
    public class FinanceDbMockingData
    {
        public void InsertMockingData()
        {
            var stockInfoList = CreateStockInfoData();
            var stockPerformanceList = CreateStockPerformanceData();
            AddDataToDb(stockInfoList, stockPerformanceList);
        }

        private void AddDataToDb(List<StockInfo> stockInfoList, List<StockPerformance> stockPerformanceList)
        {
            var dbContext = new FinanceServiceContext();

            if (stockInfoList != null)
            {
                dbContext.AddRange(stockInfoList);
                dbContext.SaveChanges();
            }

            if (stockPerformanceList != null)
            {
                dbContext.AddRange(stockPerformanceList);
                dbContext.SaveChanges();
            }
        }

        private List<StockPerformance> CreateStockPerformanceData()
        {
            return new List<StockPerformance>
            {
                new StockPerformance
                {
                    StockInfoId = 1,
                    close = 126.64,
                    valueDate = DateTime.Parse("01.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 1,
                    close = 123.44,
                    valueDate = DateTime.Parse("02.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 1,
                    close = 133.11,
                    valueDate = DateTime.Parse("03.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 2,
                    close = 66.23,
                    valueDate = DateTime.Parse("01.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 2,
                    close = 68.44,
                    valueDate = DateTime.Parse("02.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 2,
                    close = 69.14,
                    valueDate = DateTime.Parse("03.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 3,
                    close = 166.23,
                    valueDate = DateTime.Parse("01.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 3,
                    close = 158.44,
                    valueDate = DateTime.Parse("02.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 3,
                    close = 149.14,
                    valueDate = DateTime.Parse("03.05.2021")
                }
            };
        }

        private List<StockInfo> CreateStockInfoData()
        {
            return new List<StockInfo>
            {
                new StockInfo
                {
                    Information = "Keine Info",
                    Symbol = "BMW",
                    FullName = "Bayrische Motoren Werke",
                    FirstValueDate = DateTime.Today,
                    LastRefreshed = DateTime.Now
                },
                 new StockInfo
                {
                    Information = "Keine Info",
                    Symbol = "ADI",
                    FullName = "Audi AG",
                    FirstValueDate = DateTime.Today,
                    LastRefreshed = DateTime.Now
                },
                  new StockInfo
                {
                    Information = "Keine Info",
                    Symbol = "DAI",
                    FullName = "Daimler AG",
                    FirstValueDate = DateTime.Today,
                    LastRefreshed = DateTime.Now
                },
            };
        }
    }
}
