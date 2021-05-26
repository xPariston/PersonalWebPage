using System.Collections.Generic;
using System.Threading.Tasks;
using WebPage.Server.Base;

namespace WebPage.Server.FinanceService.Logic
{
    public interface IFinanceRetrivalService
    {
        Task<Result<IEnumerable<int>>> GetPerformanceThisYear(string symbol);
    }
}
