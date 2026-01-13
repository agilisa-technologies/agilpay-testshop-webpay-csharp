using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Test_Shop_Razor.Pages
{
    public class IndexModel : PageModel
    {
        public string Agilpay_WebPayUrl { get; set; }

        public IndexModel(IConfiguration configuration) : base() {
            Agilpay_WebPayUrl = configuration["AppSettings:Agilpay_WebPayUrl"];
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            return NotFound();
        }
    }
}
