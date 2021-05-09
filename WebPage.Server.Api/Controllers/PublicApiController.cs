using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPage.Server.Base;
using WebPage.Server.FinanceService.Logic;

namespace WebPage.Server.Api.Controllers
{
    [ApiController]
    [Route("[publicapi]")]
    public class PublicApiController : ControllerBase
    {
        private readonly ILogger<PublicApiController> _logger;
        private readonly IFinanceService _financeService;

        public PublicApiController(ILogger<PublicApiController> logger, IFinanceService financeService)
        {
            _logger = logger;
            _financeService = financeService;
        }

        [HttpGet]
        [Route("stock/{symbol:string}/performance-this-year")]
        public async Task<ActionResult<IEnumerable<int>>> GetPerformanceThisYear(string symbol)
        {
            var result = await _financeService.GetPerformanceThisYear(symbol);
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
