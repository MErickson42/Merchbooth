using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//TODO 11/14     1.add regular expreeesion for password textbox.
//               2.change state input from txtbox to drop down.
namespace Merchbooth {
	public partial class WebForm1 : System.Web.UI.Page {


        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnSigmUpBand_Click(object sender, EventArgs e)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();

            //First: test the band name is not being used
            bool blnNameFlag = false;
            var queryBnads = from b in _siteContext.TBands

                             select b;

            foreach (TBand bndBand in queryBnads)
            {
                if(bndBand.strBandName == txtBandName.Text)
                {
                    blnNameFlag = true;
                    break;
                }
            }

            if(blnNameFlag == true)
            {
                //Name used
                Response.Write("The band name is already used.");
                txtBandName.Focus();
            }
            else
            {
                string message = "";

                string strBandName  = txtBandName.Text;
                string strPassword  = txtPassword.Text;
                string strPhone     = txtPhone.Text;
                string strEmail     = txtEmail.Text;
                string strCity      = txtCity.Text;
                string strAddress   = txtAddress.Text;
                string strZip       = txtZip.Text;

                int intState = 1;

                TBand band = new TBand();

                band.strBandName = strBandName;
                band.strPassword = strPassword;
                band.strPhone = strPhone;
                band.strEmail = strEmail;
                band.intStateID = intState;
                band.strCity = strCity;

                band.strAddress = strAddress;
                band.strZip = strZip;

                band.strHeaderImage = "";
                band.strBackroundImage = "";
                band.strTeamPassword = "";

                _siteContext.TBands.InsertOnSubmit(band);

                _siteContext.SubmitChanges();

                int BandKey = band.intBandID;

                message = "Band " + band.strBandName + " has registered.";



                //}
                string newFileDirectory = Request.PhysicalApplicationPath.ToString() + "Uploads\\Bands\\" + BandKey + "\\";
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

                    newBandHeaderPath = "Uploads/Bands/" + BandKey + "/" + BandHeaderImage.FileName;

                }

                if (newBandHeaderPath.Length > 0)
                {
                    var queryBands = from b in _siteContext.TBands
                                        where b.intBandID == BandKey
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

                    newBandBackgroundPath = "Uploads/Bands/" + BandKey + "/" + BandHeaderImage.FileName;

                }

                if (newBandBackgroundPath.Length > 0)
                {
                    var queryBands = from b in _siteContext.TBands
                                     where b.intBandID == BandKey
                                     select b;

                    foreach (TBand tband in queryBands)
                    {
                        tband.strBackroundImage = newBandBackgroundPath;
                    }

                    _siteContext.SubmitChanges();
                }


                //TODO For now there is no home page
                //Response.Redirect("/Admin/?pk=" + BandKey + "&message=" + Server.UrlEncode(message));

                //So sending to modify product page
                Response.Redirect("/Admin/Products.aspx?&message=" + Server.UrlEncode(message));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
            {
                Response.Redirect("/");
            }
        
    }
}