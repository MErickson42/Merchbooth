using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth.Customer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string strMessage = "";
            if (Request.QueryString["message"] != null)

            {
                strMessage = Request.QueryString["message"].ToString();
            }

            if (strMessage != "")
            {
                Response.Write("<script>alert('" + strMessage + "')</script>");

            }

            SiteDCDataContext _siteContext = new SiteDCDataContext();
            StringBuilder sb = new StringBuilder();

            var queryProducts = from p in _siteContext.TProducts
                                select p;

            queryProducts.ToList();

            if (queryProducts.Count() > 0)
            {
                int intCount = 1;
                // MDE this linq to sql query does a join - joining the intBandID from tables TBands and TProducts 
                var queryBandsProducts = from b in _siteContext.TBands
                                         join p in _siteContext.TProducts
                                         on b.intBandID equals p.intBandID
                                         where p.intIsDeleted == 0
                                         orderby p.intBandID
                                         select new { b, p };

                queryBandsProducts.ToList();
                if (queryBandsProducts.Count() > 0)
                {
                    string strBandName = "";
                    int intBandID = 1;
                    int intPreviousBandID = 1;
                    bool blnFirstTimeThroughLoop = true;
                    bool blnNewBandDetected = false;

                    // This loop will loop through each product from the queryBands query we made
                    foreach (var item in queryBandsProducts)
                    {
                        //Only products with image will be displayed in page to customer
                        if (item.p.strImageLink == "" || item.p.strImageLink == null)
                        {
                            continue;
                        }

                        // MDE - item.p refrers to the 'p' in the 'select new {b, p}' part of the linq query. p represents products
                        // we are setting the variable intBandID equal to the band ID of the item in the current loop
                        intBandID = item.p.intBandID;


                        // We are checking to see if a new bandID  has been detected by seeing if the Band ID of the current loop does NOT equal the BandID of the previous loop


                        if (intBandID != intPreviousBandID && blnFirstTimeThroughLoop == false)
                        {
                            blnNewBandDetected = true;
                            intCount = 1;
                        }

                        if (blnNewBandDetected == true)
                        {
                            sb.Append("</div>");
                        }

                        if (intCount > 4) continue;

                        if (blnFirstTimeThroughLoop == true)
                        {
                            sb.Append("<div class='row ImageRow'>");

                            // MDE - Get the band name from the current loop
                            //strBandName = item.b.strBandName;

                            //sb.Append("<h1 class='ecBantTitle'> <strong>" + strBandName + " </strong></h1>");
                            strBandName = item.b.strBandName;

                            sb.Append("<h1 class='ecBantTitle'><a id='band"+ intBandID+"' style='color:darkred;' href='/Customer/OneBandProducts/?ck=" + item.b.intBandID + "'>" + strBandName + "</a></h1>");

                            //ben 12/4
                            if (item.b.strBackroundImage != "")
                            {
                                sb.Append("<img class='BacroundECommerceImages' src='..\\" + item.b.strBackroundImage + "'  >");
                            }
                        }

                        //Ben 12/4 changed
                        //if (intBandID != intPreviousBandID)
                        if (intBandID != intPreviousBandID && blnFirstTimeThroughLoop == false)
                        {


                            sb.Append("<div class='row ImageRow'>");

                            //// MDE - Get the band name from the current loop
                            strBandName = item.b.strBandName;
                            //// MDE - Show the band name and a header 'Products for Sale'
                            //ben
                            sb.Append("<h1 class='ecBantTitle'><a id='band" + intBandID + "' style='color:darkred;' href='/Products/Product-Details/?ck=" + item.b.intBandID + "'>" + strBandName + "</a></h1>");

                            if (item.b.strBackroundImage != "")
                            {
                                sb.Append("<img class='BacroundECommerceImages' src='..\\" + item.b.strBackroundImage + "'  >");
                            }
                        }

                        if (blnNewBandDetected == true)
                        {
                            blnNewBandDetected = false;
                        }
                        // MDE - Here is where the product details and image are displayed


                        if (item.p.strImageLink != "")
                        {
                            sb.Append("<div class='OneImage'>");
                            sb.Append(" <img style='display:inline;' title=' " + item.p.strProductName + "' class='image-responsive saleImage' src='../" + item.p.strImageLink + "' runat='server' onclick='addToCart(" + item.p.intProductID + "," + item.p.intTypeID + ",\"" + item.p.strImageLink + "\"," + item.p.decBandPrice + "," + 1 + ")'" + "/>");
                            sb.Append("<p>$ ");
                            sb.Append(item.p.decBandPrice);
                            sb.Append("</p>");
                            sb.Append("</div>");
                        }

                        intCount += 1;
                        if (intCount > 4) continue;

                        blnFirstTimeThroughLoop = false;
                        intPreviousBandID = intBandID;

                    }

                    sb.Append("</div>");
                    
                }
            }
            else
            {
                sb.Append("<div class='row'><div class='col-md-12'>No products in this category are currently available.</div></div>");
            }

            ltrProducts.Text = sb.ToString();

            string cart= Server.UrlDecode(Request.QueryString["cart"]); 
            if(cart != "" && cart != null)
            {
                hdnPassedCartItemsVariable.Value = cart;
            }
            

        }

        protected void checkoutMain_Click(object sender, EventArgs e)
        {
            string strUrl = "http://localhost:10349/Customer/CheckoutMain.aspx?cart=" + hdnCartItemsVariable.Value.ToString();
            Response.RedirectPermanent(strUrl);
        }
    }
}