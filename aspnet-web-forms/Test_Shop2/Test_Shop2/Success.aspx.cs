using System;

namespace Test_Shop2
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResult.Text = Request.Form["Detail"];
        }
    }
}