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

            //lblMessage.Text = Server.UrlDecode(Request.QueryString["message"]);
            int intBandID = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }

            SiteDCDataContext _siteContent = new SiteDCDataContext();

			// *added user entered low threshhold variable //EH 11.29.19
			int intQuantity = Convert.ToInt32(hdnThreshold.Value);

            if (intQuantity <= 0)
            {
                intQuantity = 50;
            }

            //Ceating- Low Inventory String
            var queryProducts = from p in _siteContent.TProducts

                                orderby p.intProductID
                                where p.intBandID == intBandID &&
                                        p.intAmountAvialable <= intQuantity
                                select p;
            



            queryProducts.ToList();

            StringBuilder tl = new StringBuilder();
            tl.Append("<div class='DivBorderTableWrapp'>");
            tl.Append("<table>");
            tl.Append("<thead>");
            tl.Append("<tr class='bandHomeTableH'><th colspan='2'>Low Inventory</th></tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            if (queryProducts.Count() > 0)
            {
                foreach (var item in queryProducts)
                {


                    tl.Append("<tr><td class='productLow'> <a href = '/Admin/ModifyProduct.aspx?pk=" + item.intProductID + "' >"+ item.strProductName+ "</a>" + " </td><td class='warning'>" + item.intAmountAvialable + "</td></tr>");
                    
                }
                tl.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            }
            else
            {
                tl.Append("<tr><td colspan='2'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");

            tl.Append("<form action = '#' onsubmit = 'return inputOutfocus(this);'style='font-size:14px;'>");
            tl.Append("<label for='Threshold'>Threshold:</label>");
            tl.Append("<input type='text' id='Threshold' name='Threshold' runat='server' value='"+ intQuantity.ToString() + "' onchange='changeNum()'/>");
            tl.Append("</form>");

            tl.Append("</div>");

            lblLowInventory.Text = tl.ToString();


            //Ceating- Sales String
            tl.Clear();
            int intCount = 0;
            var queryLastEvents = from E in _siteContent.TEvents

                              orderby E.dtmDate
                              where E.dtmDate < DateTime.Now &&
                                    E.dtmDate.Year == DateTime.Now.Year &&  //This year only

                                  E.intBandID == intBandID
                              select E;

            queryLastEvents.ToList();

            tl.Append("<div class='DivBorderTableWrapp'>");
            tl.Append("<table>");
            tl.Append("<thead>");
            tl.Append("<tr class='bandHomeTableH'><th colspan='2'>Latest Sales</th></tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            if (queryLastEvents.Count() > 0)
            {
                foreach (var LastEvents in queryLastEvents)
                {
                    intCount += 1;
                    if (intCount > 3) { break; }
                    //TODO
                    tl.Append("<tr><td class='bandNaeSales'> <a href ='' >" + LastEvents.strEventName + "</a></td><td style='color:#7575a3'>$ " + Convert.ToInt32(LastEvents.decEventSales)  + " </td></tr>");

                }
                tl.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            }
            else
            {
                tl.Append("<tr><td colspan='2'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");
            tl.Append("</div>");

            lblSales.Text = tl.ToString();



            //Ceating- Reports String
            tl.Clear();

            tl.Append("<div class='DivBorderTableWrapp'>");
            tl.Append("<table>");
            tl.Append("<thead>");
            tl.Append("<tr class='bandHomeTableH'><th >Reports</th></tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            tl.Append("<tr><td class='reports'> <a href ='/Admin/Reports/SalesByCustomer/' >Top Customers</a></td></tr>");

            tl.Append("<tr><td class='reports'>&nbsp;</td></tr>");


            tl.Append("<tr><td class='reports'> <a href ='/Admin/Reports/SalesByProduct/' >Sales by Product</a></d></tr>");
            tl.Append("<tr><td class='reports'> <a href ='' >Sales by Event</a></d></tr>");
            tl.Append("<tr><td class='reports'>&nbsp;</td></tr>");

            tl.Append("<tr><td class='reports'> <a href ='/Admin/Reports/SalesByDate/' >Sales by Date</a></td></tr>");

            tl.Append("</tbody>");
            tl.Append("</table>");
            tl.Append("</div>");

            lblReports.Text = tl.ToString();


            //Ceating- Upcoming Events String
            tl.Clear();

            var queryEvents = from E in _siteContent.TEvents

                                orderby E.dtmDate
                                where E.dtmDate >= DateTime.Now &&
                                    E.intBandID == intBandID
                              select E;

            queryEvents.ToList();

            tl.Append("<div class='DivBorderTableWrapp'>");
            tl.Append("<table>");
            tl.Append("<thead>");
            tl.Append("<tr class='bandHomeTableH'><th colspan='2'>Upcoming Events</th></tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            if (queryEvents.Count() > 0)
            {
                foreach (var Event in queryEvents)
                {

                                                         //TODO
                    tl.Append("<tr><td class='upcomming'> <a href ='' >" + Event.strEventName + "</a></td><td style='color:#7575a3'>" + Event.dtmDate.Month +"/" + Event.dtmDate.Day + " </td></tr>");

                }
                tl.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            }
            else
            {
                tl.Append("<tr><td colspan='2'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");
            tl.Append("</div>");



            lblUpcoming.Text = tl.ToString();

        } 
    }
}