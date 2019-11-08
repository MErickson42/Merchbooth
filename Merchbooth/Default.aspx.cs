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
                    // MDE this linq to sql query does a join - joining the intBandID from tables TBands and TProducts 
                    var queryBands = from b in _siteContext.TBands
                                     join p in _siteContext.TProducts
                                     on b.intBandID equals p.intBandID
                                     orderby p.intBandID
                                     select new { b, p };

                    
                    


                    queryBands.ToList();
                    if (queryBands.Count() > 0)
                    {
                        string strBandName = "";
                        int intBandID = 1;
                        int intPreviousBandID = 1;
                        bool blnFirstTimeThroughLoop = true;
                        bool blnNewBandDetected = false;
                        int intProductCount = 1;

                    // This loop will loop through each product from the queryBands query we made
                    foreach (var item in queryBands)
                        {

                   


                            // MDE - item.p refrers to the 'p' in the 'select new {b, p}' part of the linq query. p represents products
                            // we are setting the variable intBandID equal to the band ID of the item in the current loop
                        intBandID = item.p.intBandID;
                            

                        // We are checking to see if a new bandID  has been detected by seeing if the Band ID of the current loop does NOT equal the BandID of the previous loop
                            

                           if (intBandID != intPreviousBandID && blnFirstTimeThroughLoop == false)
                            {
                                blnNewBandDetected = true;
                                
                            }
                            
                            if (blnNewBandDetected == true)
                            {
                                sb.Append("<div class='row'><div class='col-md-12'><br /><hr /></div></div>");
                            }

                            if (blnNewBandDetected == true)
                            {
                                sb.Append("</div>");
                                
                              
                            }

                            if (blnFirstTimeThroughLoop == true)
                            {
                                sb.Append("<div class='row'>");
                                // MDE - Get the band name from the current loop
                                strBandName = item.b.strBandName;

                                sb.Append("<h1><strong>Band Name: </strong>" + strBandName + "</h1><h2>Products for Sale:" + "</h2>");
                            }
                            if (intBandID != intPreviousBandID)
                            {
                                sb.Append("<br />");
                                sb.Append("<div class='row'>");
                                // MDE - Get the band name from the current loop
                                strBandName = item.b.strBandName;
                                // MDE - Show the band name and a header 'Products for Sale'
                                sb.Append("<h1><strong>Band Name: </strong>" + strBandName + "</h1><h2>Products for Sale:"  + "</h2>");
                            }

                            if (blnNewBandDetected == true)
                            {
                                blnNewBandDetected = false;
                            }
                            // MDE - Here is where the product details and image are displayed
                            sb.Append("<div style='margin-top:5px;padding-top:20px;padding-bottom-10px;margin-left:5px;border:1px solid gray;border-radius:6px;height:445px;' class='col-md-3'>" + "Product Name: " +item.p.strProductName + "<br />" + "Price: $" + item.p.decBandPrice + "<br />" + "Quantity Remaining: " + item.p.intAmountAvialable + "<br />");
                            if (item.p.strImageLink != "")
                            {

                                sb.Append(" <img src='../" + item.p.strImageLink + "' runat='server' class='imgHome''" + " />");
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