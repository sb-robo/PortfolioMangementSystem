using AuthorizationMS.Models;
using AuthorizationMS.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using AuthorizationMS.Routing;

namespace AuthorizationMS.Controllers
{
    [Route(ConstRouting.baseRoute)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly IConfiguration _config;
        static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(AuthController));

        public AuthController(IConfiguration config, IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
            _config = config;
        }

        [HttpPost]
        [Route(ConstRouting.loginRoute)]
        public IActionResult Login([FromBody] LoginModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }
                _logger.Info(nameof(Login) + $"method invoked, Username: " + user.Username);
                Customer customer = _authorizationRepository.CheckCredentials(user);
                if (customer != null)
                {
                    string tokenVal = _authorizationRepository.GenerateToken(_config, customer);
                    customer.token = tokenVal;
                    return Ok(customer);
                }
                return Unauthorized("Invalid Credentials");
            }
            catch (Exception e)
            {
                _logger.Info("Error Occured from " + nameof(Login) + " Error Message : " + e.Message);
                return BadRequest(e.Message);
            }
        }

    }
}
