using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPage.Server.Base;

namespace WebPage.Server.FinanceService
{
    public interface IFinanceRetrivalService
    {
        Task<Result<IDictionary<string, double>>> GetPerformanceThisYear(string symbol, DateTime maxDate);
    }
}
