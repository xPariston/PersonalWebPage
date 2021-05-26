using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPage.Server.FinanceService.DataAccess.ServiceRepository
{
    public class StockRepository : IRepository<StockInfo>
    {
        private StockContext _stockContext;
        public StockRepository(StockContext stockContext)
        {
            _stockContext = stockContext;
        }

        public Task<StockInfo> Create(StockInfo _object)
        {
            throw new NotImplementedException();
        }

        public void Delete(StockInfo _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public StockInfo GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(StockInfo _object)
        {
            throw new NotImplementedException();
        }

        public StockInfo GetSymbol(string symbol)
        {
            return _stockContext.StockInfos
                .Where(stock => stock.Symbol == symbol)
                .FirstOrDefault();
        }
    }
}
