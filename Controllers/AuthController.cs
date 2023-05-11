using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Test_Shop1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        public string Agilpay_ApiUrl { get; set; }
        public string Client_id { get; set; }
        public string Client_Secret { get; set; }

        public OAuthController(IConfiguration configuration) : base()
        {
            Agilpay_ApiUrl = configuration["AppSettings:Agilpay_ApiUrl"];
            Client_id = configuration["AppSettings:Client_id"];
            Client_Secret = configuration["AppSettings:Client_Secret"];
        }

        [HttpPost]
        public async Task<TokenResponse> PaymentTokenAsync(PaymentTokenRequestModel model)
        {
            // override credentials
            model.client_id = Client_id;
            model.client_secret = Client_Secret;

            TokenResponse response = null;
            try
            {
                var client = new RestClient(Agilpay_ApiUrl);
                var request = new RestRequest("oauth/paymenttoken");
                request.AddJsonBody(model);

                // request JWT
                response = await client.PostAsync<TokenResponse>(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }
    }

    public class TokenResponse
    {
        public string token_type { get; init; }
        public string access_token { get; init; }
        public string expires_in { get; init; }
    }

    public class PaymentTokenRequestModel
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        [Required]
        public string orderId { get; set; }
        [Required]
        public string customerId { get; set; }
        [Required]
        public decimal amount { get; set; }
    }
}
