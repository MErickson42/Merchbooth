using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Merchbooth
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //A connection to the database to be used when geting or updatinh data            SiteDCDataContext _siteContext = new SiteDCDataContext();
            SiteDCDataContext _siteContext = new SiteDCDataContext();

            //A tool that we use to bild the html fof each data item comig in from the database
            StringBuilder sb = new StringBuilder();

            int intProductId = 1;
      

            var queryProducts = from c in _siteContext.TProducts
                                // where c.intProductID == intProductId
                                select c;


            queryProducts.ToList();

            if (queryProducts.Count() > 0)
            {
                int intCount = 1;
                sb.Append("<div class='column-left'><div class='col-md-12'><hr /></div></div>");

                foreach (TProduct prod in queryProducts)
                {

                    sb.Append("<div class='column-left' style='padding-bottom: 10px;text-align:left;'>");
                  
                    sb.Append("<div style='text-align:left;' class='row'>");
                    sb.Append("<div class='col-md-2'>");
                    if (prod.strImageLink != "" && intCount == 1)
                    {
                        sb.Append("<img src='../" + prod.strImageLink + "' class='img-responsive' style='display: block !important;margin-left: auto !important;margin-right: auto !important; '" + " />");
                    }
                    if (prod.strImageLink != "" && intCount != 1)
                    {

                        sb.Append("<img src='../" + prod.strImageLink + "' class='img-responsive''" + " />");
                    }
                    sb.Append("</div>");

                    sb.Append("<div style='text-align:left;' class='col-md-6'>" + prod.strProductName + "</div>");
                    sb.Append("<div class='col-md-4'>");

                    
                   

                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("<div class='row'><div class='col-md-12'><hr /></div></div>");
                    intCount += 1;
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