using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;


namespace Merchbooth.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Server.UrlDecode(Request.QueryString["message"]);
            int intBandID = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }

            SiteDCDataContext _siteContent = new SiteDCDataContext();

            var queryProducts = from p in _siteContent.TProducts

                                orderby p.intProductID
                                where   p.intBandID == intBandID &&
                                        p.intAmountAvialable < 100
                                select p;

            queryProducts.ToList();

            StringBuilder tl = new StringBuilder();
            tl.Append("<div class='DivBorderTableWrapp'>");
            tl.Append("<table>");
            tl.Append("<thead>");
            tl.Append("<tr class='bandHomeTableH' colspan='2'><th>Low Inventory</th></tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            if (queryProducts.Count() > 0)
            {
                foreach (var item in queryProducts)
                {


                    tl.Append("<tr><td> <a href = '/Admin/ModifyProduct.aspx?pk=" + item.intProductID + "' >"+ item.strProductName+ "</a>" + " </td><td class='warning'>" + item.intAmountAvialable + "</td></tr>");
                    
                }
                tl.Append("<tr><td colspan='3'>&nbsp;</td></tr>");
            }
            else
            {
                tl.Append("<tr><td colspan='3'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");
            tl.Append("</div>");

            lblLowInventory.Text = tl.ToString();

            tl.Clear();
            tl.Append("<div class='DivBorderTableWrapp'>Reports");
            tl.Append("</div>");

            lblReports.Text = tl.ToString();

            tl.Clear();
            tl.Append("<div class='DivBorderTableWrapp'> Sales");
            tl.Append("</div>");

            lbl3.Text = tl.ToString();



            tl.Clear();
            tl.Append("<div class='DivBorderTableWrapp'>Upcoming Events");
            tl.Append("</div>");

            lblUpcoming.Text = tl.ToString();

        }
    }
}