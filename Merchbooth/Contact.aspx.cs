﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cart memory
            string cart = Server.UrlDecode(Request.QueryString["cart"]);
            if (cart != "")
            {
                hdnPassedCartItemsVariable.Value = cart;
            }
        }
    }
}