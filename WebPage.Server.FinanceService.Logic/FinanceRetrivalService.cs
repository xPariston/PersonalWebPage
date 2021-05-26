using System.Collections.Generic;
using System.Threading.Tasks;
using WebPage.Server.Base;
using WebPage.Server.FinanceService.Data.ServiceRepository;

namespace WebPage.Server.FinanceService.Logic
{
    public class FinanceRetrivalService : IFinanceRetrivalService
    {
        private readonly StockRepository _stockRepository;

        public FinanceRetrivalService(StockRepository stockRepository)
        {
            this._stockRepository = stockRepository;
        }

        async Task<Result<IEnumerable<int>>> IFinanceRetrivalService.GetPerformanceThisYear(string symbol)
        {
            throw new System.NotImplementedException();
        }
    }
}