using Microsoft.EntityFrameworkCore;
using WebPage.Server.FinanceService.Data.ServiceRepository;

namespace WebPage.Server.Console.Database
{
    public class FinanceServiceContext : DbContext
    {
        public DbSet<StockInfo> StockInfos { get; set; }
        public DbSet<StockPerformance> StockPerformance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=StockGameData;Integrated Security=True");
        }
    }
}
