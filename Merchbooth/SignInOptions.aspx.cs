using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Merchbooth
{
    public partial class SignInOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cart memory
            string cart = Server.UrlDecode(Request.QueryString["cart"]);
            if (cart != "" && cart != null)
            {
                hdnPassedCartItemsVariable.Value = cart;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<h2 style='color:darkblue'>Options:</h2>");
            sb.Append("<br/><br/>");
            sb.Append("<a id='signInBand' runat='server' href='~/ BandSignIn'>Sign In as Band</a><br/><br/>");
            sb.Append("<a id='signInCst' runat='server' href='~/ BandSignIn'>Sign In as Customer</a><br/><br/>");
            sb.Append("<br/><br/>");
            sb.Append("<a id='signUpBand' runat='server' href='~/ BandSignIn'>Sign Up as Band</a><br/><br/>");
            sb.Append("<a id='signUpCst' runat='server' href='~/ BandSignIn'>Sign Up as Customer</a><br/><br/>");

            ltrSignInOptions.Text = sb.ToString();
        }
    }
}