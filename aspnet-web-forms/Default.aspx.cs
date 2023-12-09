using Newtonsoft.Json;
using System;
using System.Text;
using System.Web.Services;
using System.Web.UI;

namespace Test_Shop2
{
    public partial class _Default : Page
    {
        public static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetAccessToken()
        {
            // API endpoint and request JWT access token
            string api_url = "https://sandbox-webapi.agilpay.net/";
            // replace with your client_id and client_secret
            string client_id = "API-001";
            string client_secret = "Dynapay";
            // customer order number, same as Detail.Service
            string orderId = "ABC12345";
            // customer account number
            string customerId = "User-123456";
            // order total amount
            decimal amount = 123.55M;

            // Prepare the request data
            var request_data = new TokenRequestModel
            {
                client_id = client_id,
                client_secret = client_secret,
                orderId = orderId,
                customerId = customerId,
                amount = amount
            };

            TokenResponse tokenResponse = null;

            client.BaseAddress = new Uri(api_url);

            var json = JsonConvert.SerializeObject(request_data);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            // request JWT
            var response = client.PostAsync("oauth/paymenttoken", data).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result);
            }
            return tokenResponse.access_token;

        }
    }

    public class TokenRequestModel
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string orderId { get; set; }
        public string customerId { get; set; }
        public decimal amount { get; set; }
    }
    public class TokenResponse
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }
}