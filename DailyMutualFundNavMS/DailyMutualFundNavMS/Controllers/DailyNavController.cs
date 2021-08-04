using DailyMutualFundNavMS.Interface;
using DailyMutualFundNavMS.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFundNavMS.Controllers
{
    [Route(ConstRouting.baseRoute)]
    [ApiController]
    public class DailyNavController : ControllerBase
    {
        private readonly IMutualFundRepo _mutualFundRepo;
        private readonly ILoggerManager _logger;
        public DailyNavController(IMutualFundRepo mutualFundRepo, ILoggerManager logger)
        {
            _mutualFundRepo = mutualFundRepo;
            _logger = logger;
        }

        // GET: api/<MutualFundsController>
        [HttpGet(ConstRouting.getMutualName)]
        public ActionResult GetMutualFundDetail(string mutualFundName)
        {
            if (String.IsNullOrEmpty(mutualFundName))
            {
                _logger.LogInformation($"Daily mutual fund nav not returned as name was not provided");
                return BadRequest();
            }
            var fund = _mutualFundRepo.GetDailyNav(mutualFundName);
            if (fund == null)
            {
                _logger.LogInformation($"Daily mutual fund nav for {mutualFundName} not found");
                return NoContent();
            }
            _logger.LogInformation($"Daily mutual fund nav for {mutualFundName} returned");
            return Ok(fund);
        }
    }
}
