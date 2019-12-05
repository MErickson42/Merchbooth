using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth.Products
{
    public partial class Product_Details : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();
            StringBuilder sb = new StringBuilder();

            int CategoryKey = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["ck"]))
            {
                CategoryKey = Convert.ToInt32(Request.QueryString["ck"]);
            }

            var queryBands = from b in _siteContext.TBands
                                where b.intBandID == CategoryKey
                                select b;

            queryBands.ToList();
            StringBuilder sbimg = new StringBuilder();


            // MDE - Commented out custom band header image
            //foreach (var name in queryBands)
            //{
            //    ltrBandName.Text = name.strBandName;
            //    sbimg.Append("/" + name.strHeaderImage);
            //}

            //imgBand.ImageUrl = sbimg.ToString();

            var queryProducts = from p in _siteContext.TProducts
                                where p.intBandID == CategoryKey 
                                orderby p.strProductName
                                select p;

            queryProducts.ToList();

            if (queryProducts.Count() > 0)
            {
                //sb.Append("<div class='row'><div class='col-md-12'><hr /></div></div>");
                foreach (TProduct prod in queryProducts)
                {

                    sb.Append("<div style='margin-top:5px;padding-top:20px;padding-bottom-10px;margin-left:5px;border:1px solid gray;border-radius:6px;height:445px;' class='col-md-3'>" + "Product Name: " + prod.strProductName + "<br />" + "Price: $" + prod.decBandPrice + "<br />" + "Quantity Remaining: " + prod.intAmountAvialable + "<br />");
                    if (prod.strImageLink != "")
                    {
                        //Ben -11/30 Changed 
                        //sb.Append(" <img src='../" + item.p.strImageLink + "' runat='server' class='imgHome''" + " />");
                        sb.Append(" <img src='/" + prod.strImageLink + "' runat='server' class='imgHome' onclick='addToCart(" + prod.intProductID + "," + prod.intTypeID + ",\"" + prod.strImageLink + "\"," + prod.decBandPrice + "," + 1 + ")'" + "/>");
                        sb.Append("</div>");
                    }
                }
            }
            else
            {
                sb.Append("<div class='row'><div class='col-md-12'>No products for this band are currently available.</div></div>");
            }

            ltrProducts.Text = sb.ToString();
        }
    }
}