using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;

namespace Merchbooth.Admin.Reports
{
    public partial class AllSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblMessage.Text = Server.UrlDecode(Request.QueryString["message"]);
            int intBandID = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }


            SiteDCDataContext _siteContent = new SiteDCDataContext();
            StringBuilder tl = new StringBuilder();


            //Ceating- Report all sales string

            var queryAllSales = from s in _siteContent.VCustomersPurchases
                                orderby s.intCustomerPurchaseID
                                where s.intBandID == intBandID
                                select  s;


            queryAllSales.ToList();



                    tl.Append("<div class='DivBorderTableWrappCustomer' style='margin-bottom:60px;'>");
                    tl.Append("<table class='ReportTable'>");
                    tl.Append("<thead>");

                    tl.Append("<tr class='reportTableHeader'>");

                    tl.Append("<th class='tableDataHeaders'>#Sale</th>");
                    tl.Append("<th class='tableDataHeaders'>Total</th>");
                    tl.Append("<th class='tableDataHeaders'>Product</th>");
                    tl.Append("<th class='tableDataHeaders'>Price</th>");
                    tl.Append("<th class='tableDataHeaders'>#Units</th>");
                    tl.Append("<th class='tableDataHeaders'>Product Total</th>");
                    tl.Append("<th class='tableDataHeaders cusnameTHeader'>Last Name</th>");
                    tl.Append("<th class='tableDataHeaders cusnameTHeader'>First Name</th>");
                    tl.Append("<th class='tableDataHeaders'>Date</th>");

                    tl.Append("</tr>");

                    tl.Append("</thead>");
                    tl.Append("<tbody>");


                    if (queryAllSales.Count() > 0)
                    {
                        foreach (var sale in queryAllSales)
                        {

                            tl.Append("<tr>");

                            tl.Append("<td class='datecolumnCustomer'>" + sale.intCustomerPurchaseID + " </td>");
                            tl.Append("<td class='datecolumnCustomer'>$" + sale.Purchase_Total + " </td>");

                            tl.Append("<td class='datecolumnCustomer  customerName'>" + sale.strProductName + " </td>");
                            tl.Append("<td class='datecolumnCustomer  customerName'>$" + sale.decMomentPurchaseUnitPrice + " </td>");
                            tl.Append("<td class='datecolumnCustomer  customerName'>" + sale.intProductPurchaseCount + " </td>");
                            tl.Append("<td class='datecolumnCustomer customerTotal'>$" + sale.decProductTotal + " </td>");
                            tl.Append("<td class='datecolumnCustomer'>" + sale.strLastName + " </td>");
                            tl.Append("<td class='datecolumnCustomer'>" + sale.strFirstName + " </td>");
                            tl.Append("<td class='datecolumnCustomer'>" + sale.dtmDateTime + " </td>");

                            tl.Append("</tr>");

                        }
                    }
                    else
                    {
                        tl.Append("<tr><td colspan='9'>No Content currently available.</td></tr>");
                    }

                    tl.Append("</tbody>");
                    tl.Append("</table>");
                    tl.Append("</div>");

                    lblAllSales.Text = tl.ToString();

        }
        
    }
}