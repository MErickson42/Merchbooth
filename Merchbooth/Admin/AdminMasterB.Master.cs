using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;

namespace Merchbooth.Admin
{
    public partial class AdminMadterB : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!DataHelper.IsBandLoggedIn())
            {
                Response.Redirect("/bandsignin.aspx?message=" + Server.UrlEncode("Your User Session Has Expired.||Please Login to Continue."));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}