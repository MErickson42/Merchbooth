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
                                         orderby p.intBandID
                                         select new { b, p };

                //Ben -11/30 Changed from queryBands to queryBandsProducts




                queryBandsProducts.ToList();
                if (queryBandsProducts.Count() > 0)
                {
                    string strBandName = "";
                    int intBandID = 1;
                    int intPreviousBandID = 1;
                    bool blnFirstTimeThroughLoop = true;
                    bool blnNewBandDetected = false;
                    //int intProductCount = 1;

                    // This loop will loop through each product from the queryBands query we made
                    foreach (var item in queryBandsProducts)
                    {




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
                            //11111sb.Append("</div>");
                            sb.Append("</div>");


                            //11111.sb.Append("<div class='row'><div class='col-md-12'><br /><hr /></div></div>");
                        }


                        if (intCount > 4) continue;

                        if (blnFirstTimeThroughLoop == true)
                        {
                            //11111sb.Append("<div class='row'>");
                            sb.Append("<div class='row ImageRow'>");

                            // MDE - Get the band name from the current loop
                            strBandName = item.b.strBandName;

                            sb.Append("<h1 class='ecBantTitle'> <strong>" + strBandName + " </strong></h1>");

                            //ben 12/4
                            if (item.b.strBackroundImage != "")
                            {
                                //sb.Append("<div class='ImageRow' style= \"background-image: url('" + item.b.strBackroundImage+ "')\"; \"background-repeat: no-repeat\"; \"background-size:cover\"; >");
                                //sb.Append("<div class='ImageRow' style= \"background-image: url('" + item.b.strBackroundImage + "');\" >");

                                //11111sb.Append("<div class='ImageRow'> <img class='BacroundECommerceImages' src='..\\" + item.b.strBackroundImage + "'  >");
                                sb.Append("<img class='BacroundECommerceImages' src='..\\" + item.b.strBackroundImage + "'  >");

                            }
                            else
                            {
                                //11111sb.Append("<div class='ImageRow'>");
                            }
                        }

                        //Ben 12/4 changed
                        //if (intBandID != intPreviousBandID)
                        if (intBandID != intPreviousBandID && blnFirstTimeThroughLoop == false)
                        {
                            //11111sb.Append("<br />");
                            //11111sb.Append("<div class='row'>");

                            sb.Append("<div class='row ImageRow'>");

                            // MDE - Get the band name from the current loop
                            strBandName = item.b.strBandName;
                            // MDE - Show the band name and a header 'Products for Sale'
                            sb.Append("<h1 class='ecBantTitle'> <strong>" + strBandName + " </strong></h1>");


                            //ben 12/4

                            //ben 12/4
                            if (item.b.strBackroundImage != "")
                            {
                                //sb.Append("<div class='ImageRow' style= \"background-image: url('" + item.b.strBackroundImage+ "')\"; \"background-repeat: no-repeat\"; \"background-size:cover\"; >");
                                //sb.Append("<div class='ImageRow' style= \"background-image: url('" + item.b.strBackroundImage + "');\" >");
                                //11111sb.Append("<div class='ImageRow'> <img class='BacroundECommerceImages' src='..\\" + item.b.strBackroundImage + "'  >");

                                sb.Append("<img class='BacroundECommerceImages' src='..\\" + item.b.strBackroundImage + "'  >");

                            }
                            else
                            {
                                //11111sb.Append("<div class='ImageRow'>");
                            }

                        }

                        if (blnNewBandDetected == true)
                        {
                            blnNewBandDetected = false;
                        }
                        // MDE - Here is where the product details and image are displayed
                        //ben 12/4 commneted out** line 106 out
                        //sb.Append("<div style='margin-top:5px;padding-top:20px;padding-bottom-10px;margin-left:5px;border:1px solid gray;border-radius:6px;height:140;' class='col-md-3'>" + "Product Name: " + item.p.strProductName + "<br />" + "Price: $" + item.p.decBandPrice + "<br />" + "Quantity Remaining: " + item.p.intAmountAvialable + "<br />");



                        if (item.p.strImageLink != "")
                        {
                            //Ben -11/30 Changed 
                            //sb.Append(" <img src='../" + item.p.strImageLink + "' runat='server' class='imgHome''" + " />");

                            //Instead added
                            sb.Append("<div class='OneImage'>");
                            sb.Append(" <img style='display:inline;' class='image-responsive saleImage' src='../" + item.p.strImageLink + "' runat='server' onclick='addToCart(" + item.p.intProductID + "," + item.p.intTypeID + ",\"" + item.p.strImageLink + "\"," + item.p.decBandPrice + "," + 1 + ")'" + "/>");
                            sb.Append("<p>$ ");
                            sb.Append(item.p.decBandPrice);
                            sb.Append("</p>");
                            sb.Append("</div>");
                        }

                        ////sb.Append("</div>");



                        intCount += 1;
                        if (intCount > 4) continue;

                        blnFirstTimeThroughLoop = false;
                        intPreviousBandID = intBandID;

                    }

                    //Added due due to changes on 12/4
                    sb.Append("</div>");
                    
                    //11111sb.Append("</div>");
                }





            }
            else
            {
                sb.Append("<div class='row'><div class='col-md-12'>No products in this category are currently available.</div></div>");
            }

            ltrProducts.Text = sb.ToString();
        }

        protected void checkoutMain_Click(object sender, EventArgs e)
        {
            string strUrl = "http://localhost:10349/Customer/CheckoutMain.aspx?" + hdnCartItemsVariable.Value.ToString();
            Response.RedirectPermanent(strUrl);
            //base.OnLoad(e);??
        }
    }
}