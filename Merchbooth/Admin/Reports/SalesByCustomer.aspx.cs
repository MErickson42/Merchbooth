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
    public partial class SaleByCustomer : System.Web.UI.Page
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


            //Ceating- Report yearly string

            var querySalesByCustomer = from sbc in _siteContent.VCustomersPurchases
                                   .Where(x => x.intBandID == intBandID)
                                   .AsEnumerable()
                                   .GroupBy(x => new { x.intCustomerID, x.strLastName, x.strFirstName, x.strStateName,x.strCity, x.strAddress, x.strEmail, x.strPhone})
                                   .ToList()
                                   .Select(x => new { Total = x.Sum(b => b.decProductTotal), x.Key.strLastName, x.Key.strFirstName, x.Key.strStateName, x.Key.strCity, x.Key.strAddress, x.Key.strEmail, x.Key.strPhone, })
                                   .OrderByDescending(x => x.Total)
                                   select sbc;


            StringBuilder tl = new StringBuilder();
            tl.Append("<div class='DivBorderTableWrappCustomer'>");
            tl.Append("<table class='ReportTable'>");
            tl.Append("<thead>");

            tl.Append("<tr class='reportTableHeader'>");

            tl.Append("<th class='tableDataHeaders cusnameTHeader'>Last Name</th>");
            tl.Append("<th class='tableDataHeaders cusnameTHeader'>First Name</th>");
            tl.Append("<th class='tableDataHeaders'>Total</th>");
            tl.Append("<th class='tableDataHeaders'>State</th>");
            tl.Append("<th class='tableDataHeaders'>City</th>");
            tl.Append("<th class='tableDataHeaders'>Address</th>");
            tl.Append("<th class='tableDataHeaders'>Email</th>");
            tl.Append("<th class='tableDataHeaders'>Phone</th>");

            tl.Append("</tr>");

            tl.Append("</thead>");
            tl.Append("<tbody>");

            if (querySalesByCustomer.Count() > 0)
            {
                foreach (var cus in querySalesByCustomer)
                {

                    tl.Append("<tr>");

                    tl.Append("<td class='datecolumnCustomer customerName'>" + cus.strLastName + " </td>");
                    tl.Append("<td class='datecolumnCustomer customerName'>" + cus.strFirstName + " </td>");
                    tl.Append("<td class='datecolumnCustomer customerTotal'>$" + cus.Total + " </td>");
                    tl.Append("<td class='datecolumnCustomer'>" + cus.strStateName + " </td>");
                    tl.Append("<td class='datecolumnCustomer'>" + cus.strCity + " </td>");
                    tl.Append("<td class='datecolumnCustomer cusAddress'>" + cus.strAddress + " </td>");
                    tl.Append("<td class='datecolumnCustomer'>" + cus.strEmail + " </td>");
                    tl.Append("<td class='datecolumnCustomer'>" + cus.strPhone + " </td>");

                    tl.Append("</tr>");

                }
            }
            else
            {
                tl.Append("<tr><td colspan='7'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");
            tl.Append("</div>");

            lblSalesByCustomer.Text = tl.ToString();
        }
    }
}