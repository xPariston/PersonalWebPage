using System.Collections.Generic;
using System.Linq;
using WebPage.Server.Base;
using WebPage.Server.FinanceService.DataAccess.ServiceRepository;

namespace WebPage.Server.FinanceService
{
    public class FinanceRetrivalService : IFinanceRetrivalService
    {
        private readonly IStockInfoRepository _stockRepository;

        public FinanceRetrivalService(IStockInfoRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        Result<IDictionary<string, double>> IFinanceRetrivalService.GetPerformanceThisYear(string symbol)
        {
            var stock = _stockRepository.GetSymbol(symbol);
            var performance = stock.Performance
                .OrderBy(stock => stock.valueDate)
                .ToDictionary(performance => performance.valueDate.ToShortDateString(), performance => performance.close);
            return Result<IDictionary<string, double>>.CreateSuccessResult(performance);
        }
    }
}