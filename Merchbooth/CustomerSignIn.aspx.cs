using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;

namespace Merchbooth
{
    public partial class CustomerSignIn1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnSignInCustomer_Click(object sender, EventArgs e)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();
            string message = "Customer email and password do not match.";
            string cart= Server.UrlDecode(Request.QueryString["cart"]);
            int CustomerKey = 0;
            string strCustomerName = "";

            //First: test the email is in data base 
            bool blnNotEmailFlag = true;
            bool blnNoMatchFlag = true;
            var queryCustomers = from c in _siteContext.TCustomers
                                 select c;

            foreach (TCustomer cstCustomer in queryCustomers)
            {
                if (cstCustomer.strEmail == txtEmail.Text)
                {
                    blnNotEmailFlag = false;
                    if (cstCustomer.strPassword == txtPassword.Text)
                    {
                        blnNoMatchFlag = false;
                        CustomerKey = cstCustomer.intCustomerID;
                        strCustomerName = cstCustomer.strLastName + cstCustomer.strLastName;
                    }

                    break;
                }
            }



            if (blnNotEmailFlag == false && blnNoMatchFlag == false)
            {
                if (CustomerKey > 0)
                {
                    message = "Welcome back " + strCustomerName;


                    if (DataHelper.ValidateCustomer(txtEmail.Text, txtPassword.Text))
                    {
                        Response.Redirect("/Customer/Default?cart=" + Server.UrlEncode(cart), false);
                    }


                }
                else
                {
                    Response.Write("There was an error retrieving customer information");
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
            Response.Redirect("/Default.aspx", false);
        }
    }
}