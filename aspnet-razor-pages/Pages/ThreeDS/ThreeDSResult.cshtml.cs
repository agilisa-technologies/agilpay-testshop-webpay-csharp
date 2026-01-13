using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test_Shop_Razor.Pages
{
    [IgnoreAntiforgeryToken]
    public class ThreeDSResultModel : PageModel
    {
        [BindProperty]
        public string ResponseValue { get; set; }

        public void OnGet()
        {
        }
        public void OnPost(string response)
        {
            ResponseValue = response;
        }
    }
}
