using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth
{
    public partial class Default : Page
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
                    var queryBands = from b in _siteContext.TBands
                                     join p in _siteContext.TProducts
                                     on b.intBandID equals p.intBandID
                                    // where b.intBandID == prod.intBandID
                                     select new { b, p };

                    queryBands.ToList();
                    if (queryBands.Count() > 0)
                    {
                        string strBandName = "";
                        int intBandID = 1;
                        int intPreviousBandID = 1;
                        bool blnFirstTimeThroughLoop = true;
                        bool blnNewBandDetected = false;
                        foreach (var item in queryBands)
                        {
                            intBandID = item.p.intBandID;

                            if (intBandID != intPreviousBandID && blnFirstTimeThroughLoop == false)
                            {
                                blnNewBandDetected = true;
                            }
                            if (blnNewBandDetected == true)
                            {
                                sb.Append("<div class='row'><div class='col-md-12'><hr /></div></div>");
                            }
                            if (blnNewBandDetected == true)
                            {
                                sb.Append("</div>");
                                blnNewBandDetected = false;
                            }

                        if (blnFirstTimeThroughLoop == true)
                            {
                                sb.Append("<div class='row'>");
                                // MDE - Get the band name from the current loop
                                strBandName = item.b.strBandName;

                                sb.Append("<h1><strong>Band Name: </strong>" + strBandName + "</h1><br />");
                            }
                            if (intBandID != intPreviousBandID)
                            {
                                sb.Append("<br />");
                                sb.Append("<div class='row'>");
                                // MDE - Get the band name from the current loop
                                strBandName = item.b.strBandName;

                                sb.Append("<h1><strong>Band Name: </strong>" + strBandName + "</h1><br />");
                            }

                            
                            // MDE - Here is where the product details and image are displayed
                            sb.Append("<div style='' class='col-md-6'>" + "Product Name: " +item.p.strProductName + "<br />" + "Price: $" + item.p.decBandPrice + "<br />" + "Quantity Remaining: " + item.p.intAmountAvialable + "<br />");
                            if (item.p.strImageLink != "")
                            {

                                sb.Append("<img src='/" + item.p.strImageLink + "' class='imgHome''" + " />");
                            }

                             sb.Append("</div>");

                            


                            intCount += 1;
                            blnFirstTimeThroughLoop = false;
                            intPreviousBandID = intBandID;

                        } 
                    }



                    

            }
            else
            {
                sb.Append("<div class='row'><div class='col-md-12'>No products in this category are currently available.</div></div>");
            }

            ltrProducts.Text = sb.ToString();
        }
    }
}