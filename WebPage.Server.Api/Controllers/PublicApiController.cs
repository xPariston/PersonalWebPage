﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPage.Server.Base;
using WebPage.Server.FinanceService;
namespace WebPage.Server.Api.Controllers
{
    [ApiController]
    public class PublicApiController : ControllerBase
    {
        private DateTime maxDate = DateTime.Parse("2024-12-31");
        private readonly ILogger<PublicApiController> _logger;
        private readonly IFinanceRetrivalService _financeService;

        public PublicApiController(ILogger<PublicApiController> logger, IFinanceRetrivalService financeService)
        {
            _logger = logger;
            _financeService = financeService;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [Route("stock/{symbol}/performance-this-year")]
        public async Task<ActionResult<IDictionary<string, double>>> GetPerformanceThisYear(string symbol)
        {
            var result = await _financeService.GetPerformanceThisYear(symbol, maxDate);
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
