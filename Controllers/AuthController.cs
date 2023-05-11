using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Test_Shop1.Models;
using Test_Shop1.Services;

namespace Test_Shop1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private  IConfiguration Config { get; set; }

        public OAuthController(IConfiguration configuration) : base()
        {
            Config = configuration;
        }

        [HttpPost]
        public async Task<TokenResponse> PaymentTokenAsync(PaymentTokenRequestModel model)
        {
            var _authService = new AuthToken(Config);
            TokenResponse response = await _authService.GetJwtToken(model);
            return response;
        }


    }
}
