using WebPage.Server.FinanceService;
using WebPage.Server.FinanceService.Clients;
using WebPage.Server.FinanceService.DataAccess.ServiceRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
ConfigureServices(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddEntityFrameworkSqlServer().AddDbContext<StockContext>();
    services.AddTransient<IStockInfoRepository, StockInfoRepository>();
    services.AddTransient<IAlphaVantageClient, AlphaVantageClient>();
    services.AddTransient<IFinanceRetrivalService, FinanceRetrivalService>();
}
