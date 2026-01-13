using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Test_Shop_Razor.Models;
using Test_Shop_Razor.Services;

namespace Test_Shop_Razor.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly AuthToken _authService;

        public OAuthController(AuthToken authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<TokenResponse> PaymentTokenAsync(PaymentTokenRequestModel model)
        {
            TokenResponse response = await _authService.GetJwtToken(model);
            return response;
        }
    }
}
