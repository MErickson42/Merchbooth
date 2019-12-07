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
                                    where p.intBandID == CategoryKey
                                    orderby p.strProductName
                                    orderby p.intTypeID

                                    select p;

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
                    sb.Append("<h1 class='ecBantTitle'>"+ queryBand.strBandName + "</h1>");

                    if (queryBand.strBackroundImage != "")
                    {
                        sb.Append("<img class='OneBandOnly_BacroundImage' src='/" + queryBand.strBackroundImage + "'  >");
                    }

                    sb.Append("<div style='margin-top:75px;'>");
                    sb.Append("<div class='row'style='margin-left:40px;'>");

                    //sb.Append("<div class='row'><div class='col-md-12'><hr /></div></div>");
                    int intPreviousType = queryProducts.First().intTypeID;
                    int intCurrentType = queryProducts.First().intTypeID;

                    foreach (TProduct prod in queryProducts)
                    {
                        intCurrentType = prod.intTypeID;
                        if (intCurrentType != intPreviousType && (intCurrentType==9 || intCurrentType ==10 || intCurrentType ==11))
                        {
                            intPreviousType = intCurrentType;
                            sb.Append("</div>");

                            sb.Append("<div class='row'style='margin-left:40px;'>");

                        }
                        sb.Append(" <img style='display:inline; margin-right:100px;' class='image-responsive saleImage' src='/" + prod.strImageLink + "' runat='server' onclick='addToCart(" + prod.intProductID + "," + prod.intTypeID + ",\"" + prod.strImageLink + "\"," + prod.decBandPrice + "," + 1 + ")'" + "/>");

                        //////ben 12/7 
                        //sb.Append("<div style='margin-top:5px;padding-top:20px;padding-bottom-10px;margin-left:5px;border:1px solid gray;border-radius:6px;height:445px;' class='col-md-3'>" + "Product Name: " + prod.strProductName + "<br />" + "Price: $" + prod.decBandPrice + "<br />" + "Quantity Remaining: " + prod.intAmountAvialable + "<br />");
                        //if (prod.strImageLink != "")
                        //{
                        //    //Ben -11/30 Changed 
                        //    //sb.Append(" <img src='../" + item.p.strImageLink + "' runat='server' class='imgHome''" + " />");
                        //    sb.Append(" <img src='/" + prod.strImageLink + "' runat='server' class='imgHome' onclick='addToCart(" + prod.intProductID + "," + prod.intTypeID + ",\"" + prod.strImageLink + "\"," + prod.decBandPrice + "," + 1 + ")'" + "/>");
                        //    sb.Append("</div>");
                        //}
                    }
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");

                }
                else
                {
                    sb.Append("<div class='row'><div class='col-md-12'>No products for this band are currently available.</div></div>");
                }

                ltrProducts.Text = sb.ToString();
            }
            else
            {
                sb.Append("<div class='row'><div class='col-md-12'>Band key was not provided</div></div>");
            }

        }
    }
}