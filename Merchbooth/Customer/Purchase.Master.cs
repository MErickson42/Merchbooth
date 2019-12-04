using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;

namespace Merchbooth
{
    public partial class Purchase : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!DataHelper.IsCustomerLoggedIn())
            {
                Response.Redirect("/customersignin.aspx?message=" + Server.UrlEncode("Your User Session Has Expired.||Please Login to Continue."));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}