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
    public partial class Events : System.Web.UI.Page
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

            var queryEvents = from ev in _siteContent.TEvents
                                orderby ev.dtmDate
                                where ev.intBandID == intBandID
                                select ev;

            queryEvents.ToList();

            StringBuilder tl = new StringBuilder();

            tl.Append("<table class='table table-condensed'>");
            tl.Append("<thead>");
            tl.Append("<tr><th colspan='3' class='alignright'><strong><a style='font-size:18px;' href='/Admin/ModifyEvent.aspx'>add Event &nbsp; <i class='fa fa-plus fa-lg'></i></a></strong></th></tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            if (queryEvents.Count() > 0)
            {
                foreach (var item in queryEvents)
                {


                    tl.Append("<tr><td><strong>" + item.strEventName + "</strong></td><td><strong>" + "</strong></td><td style='width: 300px;'><div class='pull-right'><strong><a href='/Admin/ModifyEvent.aspx?pk=" + item.intEventID + "'>Edit Event <i class='fa fa-pencil-square-o fa-lg'></i></a> &nbsp; | &nbsp; <a href ='/Admin/ModifyEvent.aspx?pk=" + item.intEventID + "&a=d' class='delete' data-confirm='Are you sure to delete this event?'>Delete Event <i class='fa fa-trash fa-lg'></i></a></strong></div></td></tr>");

                }
                tl.Append("<tr><td colspan='3'>&nbsp;</td></tr>");
            }
            else
            {
                tl.Append("<tr><td colspan='3'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");

            lblEvents.Text = tl.ToString();
        }
    }
}