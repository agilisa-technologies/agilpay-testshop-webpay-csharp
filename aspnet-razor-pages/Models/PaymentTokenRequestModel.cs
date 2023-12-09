using System.ComponentModel.DataAnnotations;

namespace Test_Shop1.Models
{
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
