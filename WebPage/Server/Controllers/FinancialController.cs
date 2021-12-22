using Microsoft.AspNetCore.Mvc;
using WebPage.Server.Base;
using WebPage.Server.FinanceService;

namespace WebPage.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFinanceRetrivalService _financeRetrivalService;

        public FinancialController(ILogger<WeatherForecastController> logger, IFinanceRetrivalService financeRetrivalService)
        {
            _logger = logger;
            _financeRetrivalService = financeRetrivalService;
        }

        [HttpGet]
        [Route("stock/{symbol}/performance-this-year")]
        public async Task<ActionResult<IDictionary<string, double>>> GetPerformanceThisYear(string symbol)
        {
            var result = await _financeRetrivalService.GetPerformanceThisYear(symbol);
            return MapResult(result);
        }

        private ActionResult<T> MapResult<T>(Result<T> result)
            where T : class
        {
            return result.ResultState switch
            {
                ResultState.Ok => new ActionResult<T>(result.Content),
                ResultState.NotFound => new ActionResult<T>(NotFound()),
                ResultState.BadRequest => new ActionResult<T>(BadRequest()),
                _ => Problem("An unexpected Error occurred.")
            };
        }
    }
}