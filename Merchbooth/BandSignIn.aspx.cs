using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;

namespace Merchbooth
{
    public partial class SignIn : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //cart memory
            string cart = Server.UrlDecode(Request.QueryString["cart"]);
            if (cart != "" && cart != null)
            {
                hdnPassedCartItemsVariable.Value = cart;
            }


            // MDE  - check if querystring contains a message from sign in page - and then show it in a javascript alert box.
            string strMessage = "";
            if (Request.QueryString["message"] != null)

            {
                strMessage = Request.QueryString["message"].ToString();
            }

            if (strMessage != "")
            {
                Response.Write("<script>alert('" + strMessage + "')</script>");
                //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", strMessage, true);
                return;
            }
            txtEmail.Focus();
        }


        protected void btnSignInBand_Click(object sender, EventArgs e)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();
            string message = "Band email and passwored do not match.";
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
                    message = "Welcome back " + strBandName;

                    //TODO For now there is no home page
                    //Response.Redirect("/Admin/?pk=" + BandKey + "&message=" + Server.UrlEncode(message));

                    //So sending to modify product page
                   // Response.Redirect("/Admin/Products.aspx?&message=" + Server.UrlEncode(message));
                    if (DataHelper.ValidateUser(txtEmail.Text, txtPassword.Text))
                    {
                        //Response.Redirect("/Admin/Products.aspx?&message=" + Server.UrlEncode(message));
                        Response.Redirect("/Admin/Default.aspx?&message=" + Server.UrlEncode(message));
                    }


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