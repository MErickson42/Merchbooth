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
                //Response.Write("This email is already used.");
                // MDE - Trying javascript alert
                Response.Write("<script>alert('This email is already used.')</script>");
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
                //MDE Added convert to int for ddlState
                intState = Convert.ToInt32(ddlState.SelectedValue);
                int intGender = 1;

                //MDE added Convert to int for ddlGender
                intGender = Convert.ToInt32(ddlGender.SelectedValue);

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

                // MDE added a space between first and last name
                message = "Customer " + customer.strFirstName + " " + customer.strLastName + " has registered.";


                //So sending to modify product page
                //Response.Redirect("/Default.aspx?&message=" + Server.UrlEncode(message));

                //MDE do the redirect, Show sucess message - code to show message is in default.aspx - it requests the querystring.

                Response.Redirect("/Default.aspx?message=" + Server.UrlEncode(message));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}