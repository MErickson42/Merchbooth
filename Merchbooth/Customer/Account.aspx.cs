using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;

namespace Merchbooth.Customer
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SiteDCDataContext _siteContext = new SiteDCDataContext();

                int intCustomerID = 0;
                if (HttpContext.Current.Session["UserDetails"] != null)
                {
                    UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                    intCustomerID = ud.UserKey;
                }


                var queryCustomer = from c in _siteContext.TCustomers
                                    where c.intCustomerID == intCustomerID
                                    select c;

                foreach (TCustomer custumer in queryCustomer)
                {
                    txtFirstName.Text = custumer.strFirstName;
                    txtLastName.Text = custumer.strLastName;
                    txtPassword.Text = custumer.strPassword.ToString();
                    txtPhone.Text = custumer.strPhone;
                    txtEmail.Text = custumer.strEmail;
                    ddlState.SelectedValue = custumer.intStateID.ToString();
                    txtCity.Text = custumer.strCity;
                    txtAddress.Text = custumer.strAddress;
                    txtZip.Text = custumer.strZip;
                    ddlGender.Text = custumer.intGenderID.ToString();
                }
            }
        }


        protected void btnUpdateCustomerAccount_Click(object sender, EventArgs e)
        {

            int intCustomer = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intCustomer = ud.UserKey;
            }

            string message = "";
            string strTitle = txtLastName.Text+txtFirstName.Text;


            SiteDCDataContext _siteContext = new SiteDCDataContext();

            if (intCustomer > 0) 
            {

                var queryCustomer = from c in _siteContext.TCustomers
                                where c.intCustomerID == intCustomer
                                    select c;

                foreach (TCustomer cst in queryCustomer)
                {
                    cst.strFirstName = txtFirstName.Text;
                    cst.strLastName = txtLastName.Text;
                    cst.strPassword = txtPassword.Text;
                    cst.strEmail = txtEmail.Text;
                    cst.strPhone = txtPhone.Text;
                    int intState = 1;
                    int intGeder = 1;
                    //MDE Added convert to int for ddlState
                    intState = Convert.ToInt32(ddlState.SelectedValue);
                    intGeder = Convert.ToInt32(ddlGender.SelectedValue);
                    cst.intStateID = intState;
                    cst.intGenderID = intGeder;
                    cst.strCity = txtCity.Text;
                    cst.strAddress = txtAddress.Text;
                    cst.strZip = txtZip.Text;

                }

                _siteContext.SubmitChanges();

                message = strTitle + " account information has been updated.";
            }

            Response.Redirect("/Customer/Default.aspx?&message=" + Server.UrlEncode(message));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Customer/Defualt/");
        }

    }
    
}