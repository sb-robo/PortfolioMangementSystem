using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DailySharePriceMS.Repository;
using DailySharePriceMS.Loggers;
using DailySharePriceMS.Interface;
using DailySharePriceMS.Routing;
using Microsoft.AspNetCore.Authorization;

namespace DailySharePriceMS.Controllers
{
    [Route(ConstRouting.baseRoute)]
    [ApiController]
    public class DailySharePriceController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        private readonly ILoggerManager _logger;
        public DailySharePriceController(IStockRepository stockRepository, ILoggerManager logger)
        {
            _stockRepository = stockRepository;
            _logger = logger;
        }

        // GET: api/<DailySharePriceController>
        [HttpGet(ConstRouting.getStocknameRoute)]
        public ActionResult GetStockDetail(string stockName)
        {
            if (String.IsNullOrEmpty(stockName))
            {
                return BadRequest();
            }
            var stocks = _stockRepository.GetDailyShare(stockName);
            if (stocks == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"Daily share price for {stockName} returned");
            return Ok(stocks);
        }
    }
}
