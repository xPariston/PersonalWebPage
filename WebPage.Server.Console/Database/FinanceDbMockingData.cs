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
                    close = 126.64f,
                    valueDate = DateTime.Parse("01.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 1,
                    close = 123.44f,
                    valueDate = DateTime.Parse("02.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 1,
                    close = 133.11f,
                    valueDate = DateTime.Parse("03.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 2,
                    close = 66.23f,
                    valueDate = DateTime.Parse("01.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 2,
                    close = 68.44f,
                    valueDate = DateTime.Parse("02.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 2,
                    close = 69.14f,
                    valueDate = DateTime.Parse("03.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 3,
                    close = 166.23f,
                    valueDate = DateTime.Parse("01.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 3,
                    close = 158.44f,
                    valueDate = DateTime.Parse("02.05.2021")
                },
                new StockPerformance
                {
                    StockInfoId = 3,
                    close = 149.14f,
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
                    Symbol = "BMW",
                    FirstValueDate = DateTime.Today,
                    LastRefreshed = DateTime.Now
                },
                 new StockInfo
                {
                    Symbol = "ADI",
                    FirstValueDate = DateTime.Today,
                    LastRefreshed = DateTime.Now
                },
                  new StockInfo
                {
                    Symbol = "DAI",
                    FirstValueDate = DateTime.Today,
                    LastRefreshed = DateTime.Now
                },
            };
        }
    }
}
