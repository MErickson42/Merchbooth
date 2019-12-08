using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            

                //Building the customer orders string
                StringBuilder tl = new StringBuilder();

                var queryCustomerOrders = _siteContext.VCustomersPurchases
                                       .Where(x => x.intCustomerID == intCustomerID)
                                       .AsEnumerable()
                                       .OrderBy(x => x.intCustomerPurchaseID)
                                       .GroupBy(x => new { x.intCustomerPurchaseID , x.strProductName , x.decMomentPurchaseUnitPrice, x.intProductPurchaseCount, x.decProductTotal , x.Purchase_Total , x.dtmDateTime })
                                       .ToList()
                                       .Select(x => new { PurchaseId = x.Key.intCustomerPurchaseID, ProductName = x.Key.strProductName, Price = x.Key.decMomentPurchaseUnitPrice, Amount = x.Key.intProductPurchaseCount, ProductTotal = x.Key.decProductTotal, Total = x.Key.Purchase_Total, Date = x.Key.dtmDateTime})
                                       ;


                tl.Append("<div class='CustomerDivBorderTableWrapp'>");
                tl.Append("<table class='CustomerReportTable'>");
                tl.Append("<caption class='tableCaption'>Orders</caption >");
                tl.Append("<thead>");
                tl.Append("<tr class='reportTableHeader'>");

                tl.Append("<th class='CustomerTableDataHeaders C_small'>ID</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_large'>Product Name</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_med'>Price</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_small'>#Units</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_med'>Product Total</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_med'>Purchase Total</th>");
                tl.Append("<th class='CustomerTableDataHeaders'>Date</th>");

                tl.Append("</tr>");
                tl.Append("</thead>");
                tl.Append("<tbody>");

                if (queryCustomerOrders.Count() > 0)
                {
                    foreach (var order in queryCustomerOrders)
                    {

                        tl.Append("<tr>");
                        tl.Append("<td class='datecolumnCustomerGray'>" + order.PurchaseId + " </td>");
                        tl.Append("<td class='datecolumnCustomer productName'>" + order.ProductName + " </td>");
                        tl.Append("<td class='datecolumnCustomer'>$" + order.Price + " </td>");
                        tl.Append("<td class='datecolumnCustomer'>" + order.Amount + " </td>");
                        tl.Append("<td class='datecolumnCustomer productTotal'>$" + order.ProductTotal + " </td>");
                        tl.Append("<td class='datecolumnCustomerGray'>$" + order.Total + " </td>");
                        tl.Append("<td class='datecolumnCustomerGray'>" + order.Date.Month + "/" + order.Date.Day + "/" + order.Date.Year +" </td>");
                        tl.Append("<tr>");

                    }
                }
                else
                {
                    tl.Append("<tr><td colspan='7'>No Content currently available.</td></tr>");
                }

                tl.Append("</tbody>");
                tl.Append("</table>");
                tl.Append("</div>");

                lblCustomerOrders.Text = tl.ToString();

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