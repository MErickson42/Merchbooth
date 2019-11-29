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
            txtEmail.Focus();

        }

        protected void btnSignInCustomer_Click(object sender, EventArgs e)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();
            string message = "Customer email and password do not match.";
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
                        Response.Redirect("/?&message=" + Server.UrlEncode(message), false);
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
            Response.Redirect("/", false);
        }
    }
}