using System.Collections.Generic;
using WebPage.Server.Base;

namespace WebPage.Server.FinanceService
{
    public interface IFinanceRetrivalService
    {
        Result<IDictionary<string, double>> GetPerformanceThisYear(string symbol);
    }
}
