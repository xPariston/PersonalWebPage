using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebPage.Server.Base;
using WebPage.Server.FinanceService;

namespace WebPage.Server.Api.Controllers
{
    [ApiController]
    public class PublicApiController : ControllerBase
    {
        private readonly ILogger<PublicApiController> _logger;
        private readonly IFinanceRetrivalService _financeService;

        public PublicApiController(ILogger<PublicApiController> logger, IFinanceRetrivalService financeService)
        {
            _logger = logger;
            _financeService = financeService;
        }

        [HttpGet]
        [Route("stock/{symbol}/performance-this-year")]
        public ActionResult<IDictionary<string, double>> GetPerformanceThisYear(string symbol)
        {
            var result = _financeService.GetPerformanceThisYear(symbol);
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
