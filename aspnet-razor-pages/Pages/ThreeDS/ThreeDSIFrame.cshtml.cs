using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test_Shop_Razor.Pages
{
    [IgnoreAntiforgeryToken]
    public class ThreeDSIFrameModel : PageModel
    {
        [BindProperty(Name = "amount")]
        public decimal Amount { get; set; }
        [BindProperty(Name = "pan")]
        public string PAN { get; set; }
        [BindProperty(Name = "month")]
        public int ExpMonth { get; set; }
        [BindProperty(Name = "year")]
        public int ExpYear { get; set; }
        [BindProperty(Name = "successUrl")]
        public string TargetUrl { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }

}
