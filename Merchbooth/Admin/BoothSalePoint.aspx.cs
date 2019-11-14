using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


namespace Merchbooth
{
    public partial class BoothSalesPoint : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //string strUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            //int index1 = strUrl.LastIndexOf('/');
       
            //strUrl = strUrl.Substring(0, index1);
            //index1 += 1;
            //strUrl = strUrl.Substring(0, index1);

            //A connection to the database to be used when geting or updatinh data  
            SiteDCDataContext _siteContext = new SiteDCDataContext();

            //A tool that we use to bild the html fof each data item comig in from the database
            StringBuilder sb = new StringBuilder();

            var queryProducts = from c in _siteContext.TProducts
                                    // where c.intProductID == intProductId
                                    orderby c.intTypeID
                                select c ;


            queryProducts.ToList();

            if (queryProducts.Count() > 0)
            {
                int intTypeCompare = 1;

                sb.Append("<div class = 'Wrapper'>");

                sb.Append("<div class = 'ImRows'>");
                sb.Append("<div class = 'ImageRow'>");

                foreach (TProduct prod in queryProducts)
                {

                    int intProductID = prod.intProductID;
                    int intTypeID = prod.intTypeID;
                    string strImageLink = prod.strImageLink;


                    if (prod.strImageLink != "" )
                    {
                        if (prod.intTypeID == intTypeCompare)
                        {
                            sb.Append("<div class='OneImage'>");
                            sb.Append(" <img src='../../"  + strImageLink + "' class='image-responsive saleImage' onclick='addToCart(" + intProductID + "," + intTypeID + ",\"" + strImageLink + "\"," + prod.decBandPrice + "," + 1 + ")'" + "/>");

                            sb.Append("<p>");
                            sb.Append(prod.decBandPrice);
                            sb.Append("</p>");
                            sb.Append("</div>");
                        }
                        else
                        {
                            sb.Append("</div>");
                            sb.Append("<div class = 'ImageRow'>");
                            sb.Append("<div class='OneImage'>");
                            sb.Append(" <img src='../../"   + strImageLink + "' class='image-responsive saleImage' onclick='addToCart(" + intProductID + "," + intTypeID + ",\"" + strImageLink + "\"," + prod.decBandPrice + ","+ 1 + ")'" + "/>");

                            sb.Append("<p>");
                            sb.Append("<p>");
                            sb.Append(prod.decBandPrice);
                            sb.Append("</p>");
                            sb.Append("</div>");
                            intTypeCompare += 1;
                        }
                    }

                }
            }
            else
            {
                //sb.Append("<div class='row'><div class='col-md-12'>No products in this category are currently available.</div></div>");
            }

            sb.Append("</div>");

            sb.Append("</div>");
            sb.Append("</div>");

            ltrProducts.Text += sb.ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string strUrl = "../Checkout.aspx?" + hdnCartItemsVariable.Value.ToString();
            Response.RedirectPermanent(strUrl);
           //base.OnLoad(e);??
        }
    }
}