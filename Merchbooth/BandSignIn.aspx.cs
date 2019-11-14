using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth
{
    public partial class SignIn : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnSigmInBand_Click(object sender, EventArgs e)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();
            string message = "Band name and passwored to not match.";
            int BandKey = 0;
            string strBandName = "";

            //First: test the email is in data base 
            bool blnNotEmailFlag = true;
            bool blnNoMatchFlag = true;
            var queryBnads = from b in _siteContext.TBands
                             select b;

            foreach (TBand bndBand in queryBnads)
            {
                if (bndBand.strEmail == txtEmail.Text)
                {
                    blnNotEmailFlag = false;
                    if (bndBand.strPassword == txtPassword.Text)
                    {
                        blnNoMatchFlag = false;
                        BandKey = bndBand.intBandID;
                        strBandName = bndBand.strBandName;
                    }

                    break;
                }
            }


            
            if (blnNotEmailFlag == false && blnNoMatchFlag == false)
            {
                if(BandKey >0)
                {
                    message = "Welcom back " + strBandName;

                    //TODO For now there is no home page
                    //Response.Redirect("/Admin/?pk=" + BandKey + "&message=" + Server.UrlEncode(message));

                    //So sending to modify product page
                    Response.Redirect("/Admin/Products.aspx?&message=" + Server.UrlEncode(message));

                }
                else
                {
                    Response.Write("There was an error retrieving band information");
                }

            }
            else//If one of the flag is still true - there is a problem
            {
                //Name used
                Response.Write(message);
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

    }
}