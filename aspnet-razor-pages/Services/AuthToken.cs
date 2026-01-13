using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Test_Shop_Razor.Models;

namespace Test_Shop_Razor.Services
{
    public class AuthToken
    {
        public string Agilpay_ApiUrl { get; set; }
        public string Client_id { get; set; }
        public string Client_Secret { get; set; }
        private readonly HttpClient _httpClient;

        public AuthToken(IConfiguration configuration, HttpClient httpClient)
        {
            Agilpay_ApiUrl = configuration["AppSettings:Agilpay_ApiUrl"];
            Client_id = configuration["AppSettings:Client_id"];
            Client_Secret = configuration["AppSettings:Client_Secret"];
            _httpClient = httpClient;
        }

        public async Task<TokenResponse> GetJwtToken(PaymentTokenRequestModel model)
        {
            if (model.client_id == null || model.client_secret == null)
            {
                model.client_id = Client_id;
                model.client_secret = Client_Secret;
            }

            TokenResponse response = null;
            try
            {
                var url = $"{Agilpay_ApiUrl.TrimEnd('/')}/oauth/paymenttoken";
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var httpResponse = await _httpClient.PostAsync(url, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    response = JsonSerializer.Deserialize<TokenResponse>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    Console.WriteLine($"HTTP Error: {httpResponse.StatusCode} - {await httpResponse.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return response;
        }
    }
}
