namespace WebPage.Server.FinanceService.DataAccess.ServiceRepository
{
    public interface IStockInfoRepository : IRepository<StockInfo>
    {
        public StockInfo GetSymbol(string symbol);
    }
}
