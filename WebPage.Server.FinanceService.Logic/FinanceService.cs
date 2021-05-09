using System.Collections.Generic;
using System.Threading.Tasks;
using WebPage.Server.Base;

namespace WebPage.Server.FinanceService.Logic
{
    public class FinanceService : IFinanceService
    {
        async Task<Result<IEnumerable<int>>> IFinanceService.GetPerformanceThisYear(string symbol)
        {
            throw new System.NotImplementedException();
        }
    }
}