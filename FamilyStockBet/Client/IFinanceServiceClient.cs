using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyStockBet.Client
{
    public interface IFinanceServiceClient
    {
        Task<Dictionary<DateTime, double>> GetPerformanceThisYear(string symbol);
    }
}
