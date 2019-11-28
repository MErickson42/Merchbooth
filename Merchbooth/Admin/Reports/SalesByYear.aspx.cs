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
    public partial class SalesByYear : System.Web.UI.Page
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

            var querySalesByYear =  _siteContent.VCustomersPurchases
                                   .Where(x=> x.intBandID == intBandID)
                                   .AsEnumerable()
                                   .OrderByDescending(x => x.dtmDateTime.Year)
                                   .GroupBy(x => x.dtmDateTime.Year)
                                   .ToList()
                                   .Select(x => new{ Total = x.Sum(b => b.decProductTotal), Year = x.Key })
                                   ;


            StringBuilder tl = new StringBuilder();
            tl.Append("<div class='DivBorderTableWrapp'>");
            tl.Append("<table class='ReportTable'>");
            tl.Append("<thead>");
            tl.Append("<tr class='reportTableHeader'><th colspan='2'>Year</th></tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            if (querySalesByYear.Count() > 0)
            {
                foreach (var saleYear in querySalesByYear)
                {

                    tl.Append("<tr><td class='saleReport'>" + saleYear.Year+" </td><td class='reportAmount'>    $" + saleYear.Total + "</td></tr>");

                }
            }
            else
            {
                tl.Append("<tr><td colspan='2'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");
            tl.Append("</div>");

            lblSalesByYear.Text = tl.ToString();




            //Ceating- Monthly string
            tl.Clear();
            var querySalesByMonth = _siteContent.VCustomersPurchases
                                   .Where(x => x.intBandID == intBandID)
                                   .AsEnumerable()
                                   .OrderByDescending(x =>  x.dtmDateTime)
                                   .GroupBy(x => new { x.dtmDateTime.Year, x.dtmDateTime.Month })
                                   .ToList()
                                   .Select(x => new { Total = x.Sum(b => b.decProductTotal), Year = x.Key.Year, Month = x.Key.Month })
                                   ;


            tl.Append("<div class='DivBorderTableWrapp'>");
            tl.Append("<table class='ReportTable'>");
            tl.Append("<thead>");
            tl.Append("<tr class='reportTableHeader'><th colspan='2'>Month</th></tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            if (querySalesByMonth.Count() > 0)
            {
                foreach (var saleMonth in querySalesByMonth)
                {

                    tl.Append("<tr><td class='saleReport'>" + saleMonth.Year + "-" + saleMonth.Month+ " </td><td class='reportAmount'>    $" + saleMonth.Total + "</td></tr>");

                }
            }
            else
            {
                tl.Append("<tr><td colspan='2'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");
            tl.Append("</div>");

            lblSalesByMonth.Text = tl.ToString();

        }
    }
}