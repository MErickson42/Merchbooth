using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth.Customer
{
    public partial class OneBandProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //cart memory
            string cart = Server.UrlDecode(Request.QueryString["cart"]);
            if (cart != "" && cart != null)
            {
                hdnPassedCartItemsVariable.Value = cart;
            }


            SiteDCDataContext _siteContext = new SiteDCDataContext();
            StringBuilder sb = new StringBuilder();

            int CategoryKey = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["ck"]))
            {
                CategoryKey = Convert.ToInt32(Request.QueryString["ck"]);
            }

            if (CategoryKey != 0)
            {


                var queryBand = (from b in _siteContext.TBands
                                 where b.intBandID == CategoryKey
                                 select b).First();

                //queryBands.ToList();
                StringBuilder sbimg = new StringBuilder();


                // MDE - Commented out custom band header image
                //foreach (var name in queryBands)
                //{
                //    ltrBandName.Text = name.strBandName;
                //    sbimg.Append("/" + name.strHeaderImage);
                //}

                //imgBand.ImageUrl = sbimg.ToString();

                var queryProducts = from p in _siteContext.TProducts
                                    where p.intBandID == CategoryKey && p.intIsDeleted == 0
                                    join tp in _siteContext.TTypes
                                    on p.intTypeID equals tp.intTypeID
                                    join tbp in _siteContext.TBaseTypes
                                    on tp.intBaseTypeID equals tbp.intBaseTypeID
                                    orderby tp.intBaseTypeID
                                    select new { p, tp, tbp };

                var queryBandsProducts = from b in _siteContext.TBands
                                         join p in _siteContext.TProducts
                                         on b.intBandID equals p.intBandID
                                         where p.intBandID == CategoryKey
                                         orderby p.intTypeID
                                         select new { b, p };



                queryBandsProducts.ToList();

                queryProducts.ToList();
                string strBandName = "";
                //int intBandNameCount = 1;
                foreach (var item in queryBandsProducts)
                {
                    strBandName = item.b.strBandName;

                    //if (intBandNameCount == 1)
                    //{
                    //    sb.Append("<h1><strong>Home page for: </strong>" + strBandName + "</h1><h2>Products for Sale:" + "</h2>");
                    //}
                    //intBandNameCount += 1;
                }
                if (queryProducts.Count() > 0)
                {

                    sb.Append("<div class='oneBandsProductPAGE'>");
                    sb.Append("<h1 class='ecBantTitle'>" + queryBand.strBandName + "</h1>");

                    if (queryBand.strBackroundImage != "")
                    {
                        sb.Append("<img class='OneBandOnly_BacroundImage' src='/" + queryBand.strBackroundImage + "'  >");
                    }

                    sb.Append("<div style='margin-top:75px;'>");
                    sb.Append("<div class='row'style='margin-left:40px;'>");

                    //sb.Append("<div class='row'><div class='col-md-12'><hr /></div></div>");
                    int intPreviousBaseType = queryProducts.First().tbp.intBaseTypeID;
                    int intCurrentBaseType = queryProducts.First().tbp.intBaseTypeID;

                    foreach (var prod in queryProducts)
                    {
                        //Only products with image will be displayed in page to customer
                        if(prod.p.strImageLink =="" || prod.p.strImageLink ==null)
                        {
                            continue;
                        }
                        intCurrentBaseType = prod.tbp.intBaseTypeID;
                        if (intCurrentBaseType != intPreviousBaseType)
                        {
                            intPreviousBaseType = intCurrentBaseType;
                            sb.Append("</div>");

                            sb.Append("<div class='row'style='margin-left:40px;'>");

                        }
                        sb.Append(" <img style='display:inline; margin-right:100px;' title=' " + prod.p.strProductName + "' class='image-responsive saleImage' src='/" + prod.p.strImageLink + "' runat='server' onclick='addToCart(" + prod.p.intProductID + "," + prod.p.intTypeID + ",\"" + prod.p.strImageLink + "\"," + prod.p.decBandPrice + "," + 1 + ")'" + "/>");
                        sb.Append("<p style='display:inline; z-index:15; color:darkred;position:relative; top:90px; right:200px; background-color:white; font-weight:bold;'>$ ");
                        sb.Append(prod.p.decBandPrice);
                        sb.Append("</p>");

                    }
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");

                }
                else
                {
                    sb.Append("<div class='row'><div class='col-md-12'>No products for this band are currently available.</div></div>");
                }

                ltrOneBandProducts.Text = sb.ToString();
            }
            else
            {
                sb.Append("<div class='row'><div class='col-md-12'>Band key was not provided</div></div>");
            }
        }

        protected void checkout1_Click(object sender, EventArgs e)
        {
            string strUrl = "http://localhost:10349/Customer/CheckoutMain.aspx?" + hdnCartItemsVariable.Value.ToString();
            Response.RedirectPermanent(strUrl);
        }

    }
}