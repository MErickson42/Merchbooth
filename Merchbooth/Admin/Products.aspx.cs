﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;

namespace Merchbooth.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Server.UrlDecode(Request.QueryString["message"]);
            int intBandID = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }

            SiteDCDataContext _siteContent = new SiteDCDataContext();

            var queryProducts = from p in _siteContent.TProducts

                                orderby p.intProductID
                                
                                where p.intBandID == intBandID
                                select p;

            queryProducts.ToList();

            StringBuilder tl = new StringBuilder();

            tl.Append("<table class='table table-condensed'>");
            tl.Append("<thead>");
            tl.Append("<tr><th colspan='3' class='alignright'><strong><a style='font-size:18px;' href='/Admin/ModifyProduct.aspx'>add Product &nbsp; <i class='fa fa-plus fa-lg'></i></a></strong></th></tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            if (queryProducts.Count() > 0)
            {
                foreach (var item in queryProducts)
                {
                   

                    tl.Append("<tr><td><strong>" + item.strProductName + "</strong></td><td><strong>" + "</strong></td><td style='width: 300px;'><div class='pull-right'><strong><a href='/Admin/ModifyProduct.aspx?pk=" + item.intProductID + "'>Edit Product <i class='fa fa-pencil-square-o fa-lg'></i></a> &nbsp; | &nbsp; <a href ='/Admin/ModifyProduct.aspx?pk=" + item.intProductID + "&a=d' class='delete' data-confirm='Are you sure to delete this product?'>Delete Product <i class='fa fa-trash fa-lg'></i></a></strong></div></td></tr>");

                }
                tl.Append("<tr><td colspan='3'>&nbsp;</td></tr>");
            }
            else
            {
                tl.Append("<tr><td colspan='3'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");

            lblProducts.Text = tl.ToString();
        }
    }
}