using AuthorizationMS.Models;
using Microsoft.Extensions.Configuration;

namespace AuthorizationMS.Interface
{
    public interface IAuthorizationRepository
    {
        Customer CheckCredentials(LoginModel user);
        string GenerateToken(IConfiguration _config, Customer customer);
    }
}
