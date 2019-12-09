using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth
{
    public partial class AllBands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cart memory
            string cart = Server.UrlDecode(Request.QueryString["cart"]);
            if (cart != "" && cart != null)
            {
                hdnPassedCartItemsVariable.Value = cart;
            }

            SiteDCDataContext _siteContent = new SiteDCDataContext();

            StringBuilder sb = new StringBuilder();

            var queryBands = from b in _siteContent.TBands                                
                                  orderby b.strBandName
                                  select b;

            queryBands.ToList();
            sb.Append("<div class='row'>");
            foreach (var item in queryBands)
            {
                sb.Append("<div class='col-md-3'><a href='/Products/Product-Details/?ck=" + item.intBandID + "&ct=" + item.strBandName.Replace(" ", "-").Replace("&", "and") + "' title='" + item.strBandName + "'><div class='resource-box'>");


                // MDE - Placeholder until we setup band image (if we get to it)
                //string newFileDirectory = Request.PhysicalApplicationPath.ToString() + "Uploads\\Products\\category-" + item.ID + ".jpg";

                //if (File.Exists(newFileDirectory))
                //{
                //    sb.Append("<img src='/Uploads/Products/category-" + item.ID + ".jpg' class='img-responsive alt='" + item.MenuName + "' />");
                //}
                //else
                //{
                //    sb.Append("<img src='/Uploads/Products/box-na.jpg' class='img-responsive alt='" + item.MenuName + "' />");
                //}


                sb.Append("<strong>" + item.strBandName + "</strong></div></a></div></br>"); //added </br> so list runs down page.//EH 12.04.2019
            }
            sb.Append("</div>");

            ltrBands.Text = sb.ToString();
        }
    }
}