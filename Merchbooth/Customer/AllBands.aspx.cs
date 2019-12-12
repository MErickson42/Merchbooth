using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth.Customer
{
    public partial class AllBands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteDCDataContext _siteContent = new SiteDCDataContext();

            StringBuilder sb = new StringBuilder();

            //var queryBandsProducts = from b in _siteContent.TBands
            //                         join p in _siteContent.TProducts
            //                         on b.intBandID equals p.intBandID
            //                         where _siteContent.TProducts.Any()
            //                         orderby b.intBandID
            //                         select new { b };
            var queryBandsProducts = (from b in _siteContent.TBands
                                     join p in _siteContent.TProducts
                                     on b.intBandID equals p.intBandID
                                     where _siteContent.TProducts.Any()
                                     orderby b.intBandID
                                     select   b).Distinct();


            var queryBands = from b in _siteContent.TBands
                             orderby b.strBandName
                             select b;

            //cart memory
            string cart = Server.UrlDecode(Request.QueryString["cart"]);
            if (cart != "" && cart != null)
            {
                hdnPassedCartItemsVariable.Value = cart;
            }

            queryBandsProducts.ToList();
            queryBands.ToList();
            sb.Append("<div class='row'>");
            foreach (var item in queryBandsProducts)
            {
               //if (item.p.intBandID > 0)
               // {
              
                    sb.Append("<div class='col-md-3'><a href='/Customer/OneBandProducts/?cart=" + cart + "&ck=" + item.intBandID + "&ct=" + item.strBandName.Replace(" ", "-").Replace("&", "and") + "' title='" + item.strBandName + "'><div class='resource-box'>");
                //}

                


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