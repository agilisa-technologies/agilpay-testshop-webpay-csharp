using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Test_Shop1.Pages
{
    public class IndexModel : PageModel
    {
        public bool ShowTestPage { get; set; }
        public string ApaymentWebApiUrl { get; set; }
        public string ApaymentWebPayUrl { get; set; }

        public IndexModel(IConfiguration configuration) : base() {
            ApaymentWebApiUrl = configuration["AppSettings:ApaymentWebApiUrl"];
            ApaymentWebPayUrl = configuration["AppSettings:ApaymentWebPayUrl"];
        }

        public IActionResult OnGet()
        {
            ShowTestPage = true;

            return Page();
        }
        public IActionResult OnPost()
        {
            return NotFound();
        }
    }
}
