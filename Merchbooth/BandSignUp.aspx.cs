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
            //cart memory
            string cart = Server.UrlDecode(Request.QueryString["cart"]);
            if (cart != "")
            {
                hdnPassedCartItemsVariable.Value = cart;
            }
        }


        protected void btnSignUpBand_Click(object sender, EventArgs e)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();

            //First: test the band name is not being used
            bool blnNameFlag = false;
            //test the custome eamil is not being used
            bool blnEmailFlag = false;
            var queryBnads = from b in _siteContext.TBands

                             select b;

            foreach (TBand bndBand in queryBnads)
            {
                if(bndBand.strBandName == txtBandName.Text)
                {
                    blnNameFlag = true;
                    break;
                }
                if(bndBand.strEmail == txtEmail.Text)
                {
                    blnEmailFlag = true;
                    break;
                }
            }

            if(blnNameFlag == true)
            {
                //Name used
                Response.Write("The band name is already used.");
                Response.Write("<script>alert('The band name is already used.')</script>");
                txtBandName.Focus();
            }
            else if(blnEmailFlag == true)
            {
                //Name used
                //Response.Write("This email is already used.");
                // MDE - Trying javascript alert
                Response.Write("<script>alert('This email is already used.')</script>");
                txtEmail.Focus();
            }
            else
            {
                string message = "";

                string strMusicLink = "";

                string strBandName  = txtBandName.Text;
                string strPassword  = txtPassword.Text;
                string strPhone     = txtPhone.Text;
                string strEmail     = txtEmail.Text;
                string strCity      = txtCity.Text;
                string strAddress   = txtAddress.Text;
                string strZip       = txtZip.Text;

                int intState = 1;
                //MDE Added convert to int for ddlState
                intState = Convert.ToInt32(ddlState.SelectedValue);

                TBand band = new TBand();

                band.strBandName = strBandName;
                band.strPassword = strPassword;
                band.strPhone = strPhone;
                band.strEmail = strEmail;
                band.intStateID = intState;
                band.strCity = strCity;
                band.strMusicLink = strMusicLink;
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

                //Response.Redirect("/Admin/Defaults.aspx?message=" + Server.UrlEncode(message));

                //MDE - changed redirect to the band login page
                Response.Redirect("/BandSignIn.aspx?message=" + Server.UrlEncode(message));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
            {
                Response.Redirect("/");
            }
        
    }
}