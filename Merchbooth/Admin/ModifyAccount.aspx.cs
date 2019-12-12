﻿using System;
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
                    ddlState.SelectedValue= band.intStateID.ToString();
                    txtCity.Text = band.strCity;
                    txtAddress.Text = band.strAddress;
                    txtZip.Text = band.strZip;
                    //ltrHeaderImagePath.Text = band.strHeaderImage;
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
           
            
            
            string sOldHeaderPath = "";
            string sOldBackgroundPath = "";

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
                    // MDE - Fixed
                    band.strBandName = txtBandName.Text;
                    band.strEmail = txtEmail.Text;
                    band.strPassword = txtPassword.Text;
                    band.strPhone = txtPhone.Text;
                    int intState = 1;
                    //MDE Added convert to int for ddlState
                    intState = Convert.ToInt32(ddlState.SelectedValue);
                    band.intStateID = intState;
                    band.strCity = txtCity.Text;
                    band.strAddress = txtAddress.Text;
                    band.strZip = txtZip.Text;

                    sOldBackgroundPath = band.strBackroundImage;

                    band.strHeaderImage = sOldHeaderPath;
                    band.strBackroundImage = sOldBackgroundPath;

                }

                _siteContext.SubmitChanges();

                message = strTitle + " account information has been updated.";
            }

            string newFileDirectory = Request.PhysicalApplicationPath.ToString() + "Uploads\\Bands\\" + intBandID + "\\";
            //string newBandHeaderPath = "";

            if (!Directory.Exists(newFileDirectory))
            {
                Directory.CreateDirectory(newFileDirectory);
            }

            //if ((BandHeaderImage.HasFile) && (BandHeaderImage.PostedFile.ContentType.ToLower() == "image/jpeg"))
            //{
            //    if (sOldBackgroundPath.Length > 0)
            //    {

            //        string OldDocumentFilePath = Request.PhysicalApplicationPath.ToString() + sOldBackgroundPath.Replace("/", "\\");

            //        if (File.Exists(OldDocumentFilePath))
            //        {
            //            File.Delete(OldDocumentFilePath);
            //        }
            //    }

            //    if (sOldHeaderPath.Length > 0)
            //    {

            //        string OldDocumentFilePath2 = Request.PhysicalApplicationPath.ToString() + sOldHeaderPath.Replace("/", "\\");

            //        if (File.Exists(OldDocumentFilePath2))
            //        {
            //            File.Delete(OldDocumentFilePath2);
            //        }
            //    }

            //    string newFileName = BandHeaderImage.FileName;


            //    string newFilePath = newFileDirectory + newFileName;

            //    BandHeaderImage.PostedFile.SaveAs(newFilePath);

            //    newBandHeaderPath = "Uploads/Bands/" + intBandID + "/" + BandHeaderImage.FileName;

            //}

            //if (newBandHeaderPath.Length > 0)
            //{
            //    var queryBands = from b in _siteContext.TBands
            //                     where b.intBandID == intBandID
            //                     select b;

            //    foreach (TBand tband in queryBands)
            //    {
            //        tband.strHeaderImage = newBandHeaderPath;
            //    }

            //    _siteContext.SubmitChanges();
            //}



            string newBandBackgroundPath = "";

            if (!Directory.Exists(newFileDirectory))
            {
                Directory.CreateDirectory(newFileDirectory);
            }

            if ((BandBackgroundImage.HasFile) && (BandBackgroundImage.PostedFile.ContentType.ToLower() == "image/jpeg"))
            {
                if (sOldBackgroundPath.Length > 0)
                {
                    string OldDocumentFilePath = Request.PhysicalApplicationPath.ToString() + sOldBackgroundPath.Replace("/", "\\");

                    if (File.Exists(OldDocumentFilePath))
                    {
                        File.Delete(OldDocumentFilePath);
                    }
                }

                    string newFileName = BandBackgroundImage.FileName;


                string newFilePath = newFileDirectory + newFileName;

                BandBackgroundImage.PostedFile.SaveAs(newFilePath);

                newBandBackgroundPath = "Uploads/Bands/" + intBandID + "/" + BandBackgroundImage.FileName;

            }
            else
            {
                newBandBackgroundPath = sOldBackgroundPath;
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
            Response.Redirect("/Admin/Default/");
        }



    }
}