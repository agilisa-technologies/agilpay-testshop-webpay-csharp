using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Threading.Tasks;
using Test_Shop1.Models;

namespace Test_Shop1.Services
{
    public  class AuthToken
    {
        public string Agilpay_ApiUrl { get; set; }
        public string Client_id { get; set; }
        public string Client_Secret { get; set; }

        public AuthToken(IConfiguration configuration)
        {
            Agilpay_ApiUrl = configuration["AppSettings:Agilpay_ApiUrl"];
            Client_id = configuration["AppSettings:Client_id"];
            Client_Secret = configuration["AppSettings:Client_Secret"];
        }

        public  async Task<TokenResponse> GetJwtToken(PaymentTokenRequestModel model)
        {
            // override credentials
            if (model.client_id == null || model.client_secret == null)
            {
                model.client_id = Client_id;
                model.client_secret = Client_Secret;
            }

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
}
