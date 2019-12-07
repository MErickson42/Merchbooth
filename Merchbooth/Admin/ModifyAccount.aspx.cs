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
    public partial class Account : System.Web.UI.Page
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


                var queryBand = from b in _siteContext.TBands
                                where b.intBandID == intBandID
                                select b;

                foreach (TBand band in queryBand)
                {
                    txtBandName.Text = band.strBandName;
                    txtEmail.Text = band.strEmail;
                    txtPassword.Text = band.strPassword.ToString();
                    txtPhone.Text = band.strPhone;
                    txtState.Text = band.intStateID.ToString();
                    txtCity.Text = band.strCity;
                    txtAddress.Text = band.strAddress;
                    txtZip.Text = band.strZip;
                    ltrHeaderImagePath.Text = band.strHeaderImage;
                    ltrBackgroundImagePath.Text = band.strBackroundImage;

                }
            }
        }






        protected void btnUpdateBandAccount_Click(object sender, EventArgs e)
        {

            int intBandID = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }

            string message = "";
            string strTitle = txtBandName.Text;

            
            
            //string sOldHeaderPath = "";
            //string sOldBackgroundPath = "";

            SiteDCDataContext _siteContext = new SiteDCDataContext();

            if (intBandID > 0) // Update the Product
            {

                var queryBand = from b in _siteContext.TBands
                                where b.intBandID == intBandID
                                select b;

                foreach (TBand band in queryBand)
                {
                    //BUG
                    //todo  This is not getting the new information FROM the textboxes  
                    band.strBandName = txtBandName.Text;
                    band.strEmail = txtEmail.Text;
                    band.strPassword = txtPassword.Text;
                    band.strPhone = txtPhone.Text;
                    band.intStateID = 1;           
                    band.strCity = txtCity.Text;
                    band.strAddress = txtAddress.Text;
                    band.strZip = txtZip.Text;


                    band.strHeaderImage = band.strHeaderImage;
                    band.strBackroundImage = band.strBackroundImage;

                }

                _siteContext.SubmitChanges();

                message = strTitle + " account information has been updated.";
            }

            string newFileDirectory = Request.PhysicalApplicationPath.ToString() + "Uploads\\Bands\\" + intBandID + "\\";
            string newBandHeaderPath = "";

            if (!Directory.Exists(newFileDirectory))
            {
                Directory.CreateDirectory(newFileDirectory);
            }

            if ((BandHeaderImage.HasFile) && (BandHeaderImage.PostedFile.ContentType.ToLower() == "image/jpeg"))
            {
                string newFileName = BandHeaderImage.FileName;


                string newFilePath = newFileDirectory + newFileName;

                BandHeaderImage.PostedFile.SaveAs(newFilePath);

                newBandHeaderPath = "Uploads/Bands/" + intBandID + "/" + BandHeaderImage.FileName;

            }

            if (newBandHeaderPath.Length > 0)
            {
                var queryBands = from b in _siteContext.TBands
                                 where b.intBandID == intBandID
                                 select b;

                foreach (TBand tband in queryBands)
                {
                    tband.strHeaderImage = newBandHeaderPath;
                }

                _siteContext.SubmitChanges();
            }



            string newBandBackgroundPath = "";

            if (!Directory.Exists(newFileDirectory))
            {
                Directory.CreateDirectory(newFileDirectory);
            }

            if ((BandHeaderImage.HasFile) && (BandHeaderImage.PostedFile.ContentType.ToLower() == "image/jpeg"))
            {
                string newFileName = BandHeaderImage.FileName;


                string newFilePath = newFileDirectory + newFileName;

                BandHeaderImage.PostedFile.SaveAs(newFilePath);

                newBandBackgroundPath = "Uploads/Bands/" + intBandID + "/" + BandHeaderImage.FileName;

            }

            if (newBandBackgroundPath.Length > 0)
            {
                var queryBands = from b in _siteContext.TBands
                                 where b.intBandID == intBandID
                                 select b;

                foreach (TBand tband in queryBands)
                {
                    tband.strBackroundImage = newBandBackgroundPath;
                }

                _siteContext.SubmitChanges();
            }

            Response.Redirect("/Admin/Default.aspx?&message=" + Server.UrlEncode(message));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Defualt/");
        }



    }
}