using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth
{
    public partial class CustomerSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUpCustomer_Click(object sender, EventArgs e)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();

            //First: test the custome eamil is not being used
            bool blnEmailFlag = false;
            var queryCustomers = from c in _siteContext.TCustomers

                             select c;

            foreach (TCustomer cstCustomer in queryCustomers)
            {
                if (cstCustomer.strEmail == txtEmail.Text)
                {
                    blnEmailFlag = true;
                    break;
                }
            }

            if (blnEmailFlag == true)
            {
                //Name used
                Response.Write("This email is already used.");
                txtEmail.Focus();
            }
            else
            {
                string message = "";

                string strFirstName = txtFirstName.Text;
                string strLastName = txtLastName.Text;
                string strPassword = txtPassword.Text;
                string strPhone = txtPhone.Text;
                string strEmail = txtEmail.Text;
                string strCity = txtCity.Text;
                string strAddress = txtAddress.Text;
                string strZip = txtZip.Text;

                int intState = 1;
                int intGender = 1;

                TCustomer customer = new TCustomer();

                customer.strFirstName = strFirstName;
                customer.strLastName = strLastName;
                customer.strPassword = strPassword;
                customer.strPhone = strPhone;
                customer.strEmail = strEmail;
                customer.strCity = strCity;
                customer.strAddress = strAddress;
                customer.strZip = strZip;

                customer.intStateID = intState;
                customer.intGenderID = intGender;


                _siteContext.TCustomers.InsertOnSubmit(customer);

                _siteContext.SubmitChanges();

                int CustomeKey = customer.intCustomerID;

                message = "Customer " + customer.strFirstName + customer.strLastName + " has registered.";


                //So sending to modify product page
                Response.Redirect("/?&message=" + Server.UrlEncode(message));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

    }
}