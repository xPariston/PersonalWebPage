using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebPage.Server.FinanceService;
using WebPage.Server.FinanceService.Clients;
using WebPage.Server.FinanceService.DataAccess.ServiceRepository;

namespace WebPage.Server.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyMethod()
                                              .AllowAnyHeader()
                                              .AllowAnyOrigin()
                                              .WithExposedHeaders("x-custom-header");
                                  });
            });
            services.AddControllers();
            services.AddEntityFrameworkSqlServer().AddDbContext<StockContext>();
            services.AddTransient<IStockInfoRepository, StockInfoRepository>();
            services.AddTransient<IAlphaVantageClient, AlphaVantageClient>();
            services.AddTransient<IFinanceRetrivalService, FinanceRetrivalService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
