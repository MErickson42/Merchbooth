using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;

namespace Merchbooth.Admin
{
    public partial class ModifyEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SiteDCDataContext _siteContext = new SiteDCDataContext();

                int intBandID = 0;
                if (HttpContext.Current.Session["UserDetails"] != null)
                {
                    UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                    intBandID = ud.UserKey;
                }

                string Action = Request.QueryString["a"];
                int EventKey = 0;
                if (!String.IsNullOrEmpty(Request.QueryString["pk"]))
                {
                    EventKey = Convert.ToInt32(Request.QueryString["pk"]);
                }

                if (Action == "d")
                {
                    if (EventKey > 0) // Delete a event.
                    {
                        var queryEvents = from ev in _siteContext.TEvents
                                            where ev.intEventID == EventKey && ev.intBandID == intBandID

                                            select ev;



                       _siteContext.SubmitChanges();
                    }

                    Response.Redirect("/admin/events.aspx?message=" + Server.UrlEncode("Event has been deleted."));
                }






                if (EventKey == 0)
                {
                    btnUpdateProduct.Text = "Add";
                    FormHeader.Text = "Add a Event";
                }
                else
                {
                    btnUpdateProduct.Text = "Update";
                    FormHeader.Text = "Update a Event";

                    var queryEvents = from ev in _siteContext.TEvents
                                      where ev.intEventID == EventKey && ev.intBandID == intBandID

                                      select ev;



                    foreach (TEvent events in queryEvents)
                    {
                        EventTitle.Text = events.strEventName;
                        ltrImagePath.Text = events.strImageUrl;
                        txtEventLocation.Text = events.strLocation;
                        txtPrice.Text = events.decEntryPrice.ToString();
                        lblDate.Text = events.dtmDate.ToString();
                        
                    }
                }
            }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            int intBandID = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }

            string message = "";
            int EventKey = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["pk"]))
            {
                EventKey = Convert.ToInt32(Request.QueryString["pk"]);
            }


            string strTitle = EventTitle.Text;
            string strLocation = txtEventLocation.Text;
            DateTime dtmDate = calEventDate.SelectedDate;

            decimal decPrice = Decimal.Parse(txtPrice.Text);
            
            string sOldProductPath = "";
            

            SiteDCDataContext _siteContext = new SiteDCDataContext();

            if (EventKey > 0) // Update the Product
            {
                var queryEvents = from ev in _siteContext.TEvents
                                  where ev.intEventID == EventKey && ev.intBandID == intBandID

                                  select ev;

              

                foreach (var events in queryEvents)
                {
                    events.strEventName = strTitle;
                    sOldProductPath = events.strImageUrl;
                    events.strImageUrl= sOldProductPath;
                    events.decEntryPrice = decPrice;
                    events.dtmDate = dtmDate;
                    events.strLocation = strLocation;
                    events.intBandID = intBandID;

                }

                _siteContext.SubmitChanges();

                message = strTitle + " has been updated.";
            }
            else // Add a Product
            {
                TEvent events = new TEvent();

                events.strEventName = strTitle;
                events.strImageUrl = "";
                events.decEntryPrice = decPrice;
                events.dtmDate = dtmDate;
                events.strLocation = strLocation;
                events.intBandID = intBandID;



                _siteContext.TEvents.InsertOnSubmit(events);

                _siteContext.SubmitChanges();

                EventKey = events.intEventID;

                message = strTitle + " has been added.";
            }
            string newFileDirectory = Request.PhysicalApplicationPath.ToString() + "Uploads\\Events\\" + EventKey + "\\";
            string newProductPath = "";

            if (!Directory.Exists(newFileDirectory))
            {
                Directory.CreateDirectory(newFileDirectory);
            }

            if ((ProductImage.HasFile) && (ProductImage.PostedFile.ContentType.ToLower() == "image/jpeg"))
            {
                if (sOldProductPath.Length > 0)
                {
                    string OldDocumentFilePath = Request.PhysicalApplicationPath.ToString() + sOldProductPath.Replace("/", "\\");

                    if (File.Exists(OldDocumentFilePath))
                    {
                        File.Delete(OldDocumentFilePath);
                    }
                }
                string newFileName = ProductImage.FileName;


                string newFilePath = newFileDirectory + newFileName;

                ProductImage.PostedFile.SaveAs(newFilePath);

                newProductPath = "Uploads/Events/" + EventKey + "/" + ProductImage.FileName;

            }
            else
            {
                newProductPath = sOldProductPath;
            }

            if (newProductPath.Length > 0)
            {
                var queryEvents = from p in _siteContext.TEvents
                                    where p.intEventID == EventKey
                                    select p;

                foreach (TEvent events in queryEvents)
                {
                    events.strImageUrl= newProductPath;
                }

                _siteContext.SubmitChanges();
            }

            Response.Redirect("/Admin/Events.aspx?message=" + Server.UrlEncode(message));
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Events.aspx/");
        }

        protected void calEventDate_SelectionChanged(object sender, EventArgs e)
        {
    
      
            lblDate.Text = calEventDate.SelectedDate.ToString();
        }
    }



}