using Microsoft.EntityFrameworkCore;

namespace WebPage.Server.FinanceService.DataAccess.ServiceRepository
{
    public class StockContext : DbContext
    {
        public DbSet<StockInfo> StockInfos { get; set; }
        public DbSet<StockPerformance> StockPerformance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=StockGameData;Integrated Security=True");
        }
    }
}
