using System;
using System.Linq;
using WebPage.Server.FinanceService.DataAccess.AlphaVantageApi;
using WebPage.Server.FinanceService.DataAccess.ServiceRepository;

namespace WebPage.Server.FinanceService.DataAccess.Converter
{
    public static class AlphaVantageExtension
    {
        public static StockInfo ConvertToStockInfo(this StockInfoDaily stockInfoDaily)
        {
            return new StockInfo
            {
                Symbol = stockInfoDaily.MetaData.Symbol,
                FirstValueDate = DateTime.Parse(stockInfoDaily.TimeSeriesDaily.Keys.Last()),
                LastRefreshed = DateTime.Parse(stockInfoDaily.TimeSeriesDaily.Keys.First()),
                Performance = stockInfoDaily.TimeSeriesDaily
                                .Select(stockTimestamp => new StockPerformance
                                {
                                    close = double.Parse(stockTimestamp.Value.close),
                                    valueDate = DateTime.Parse(stockTimestamp.Key)
                                })
                                .ToList()
            };

        }
    }
}
