using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Test_Shop_Razor.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class SuccessModel : PageModel
    {
        public SuccessModel() { }

        public string ResponseFormC { get; set; }

        public string ResponseType { get; set; }

        public string Authentication { get; set; }
        
        public IActionResult OnGet()
        {
            string JsonResponse = TempData["Response"].ToString();
            string url = TempData["ReturnURL"].ToString();
            //url = Url.Page("Success");            

            //return Content(content.ToHtmlFormInput().ToHtmlFormPage(url, __RequestVerificationToken), "text/html");
            ResponseFormC = JsonResponse;//.ToHtmlFormInput("Detail").ToHtmlFormPage(url);

            return Page();
        }
        public IActionResult OnPost()
        {
            Authentication = Request.Form["Authentication"];
            ResponseType = Request.Form["ResponseType"];
            ResponseFormC = Request.Form["Detail"];

            return Page();
        }
    }
}