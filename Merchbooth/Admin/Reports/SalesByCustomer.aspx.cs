using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;


namespace Merchbooth.Admin.Reports
{
    public partial class SaleByCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblMessage.Text = Server.UrlDecode(Request.QueryString["message"]);
            int intBandID = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }


            SiteDCDataContext _siteContent = new SiteDCDataContext();


            //Ceating- Report yearly string

            var querySalesByCustomer = from sbc in _siteContent.VCustomersPurchases
                                   .Where(x => x.intBandID == intBandID)
                                   .AsEnumerable()
                                   .GroupBy(x => new { x.intCustomerID, x.strLastName, x.strFirstName, x.strStateName,x.strCity, x.strAddress, x.strEmail, x.strPhone})
                                   .ToList()
                                   .Select(x => new { Total = x.Sum(b => b.decProductTotal), x.Key.intCustomerID, x.Key.strLastName, x.Key.strFirstName, x.Key.strStateName, x.Key.strCity, x.Key.strAddress, x.Key.strEmail, x.Key.strPhone, })
                                   .OrderByDescending(x => x.Total)
                                   select sbc;


            StringBuilder tl = new StringBuilder();
            tl.Append("<div class='DivBorderTableWrappCustomerLeft' style='margin-bottom:60px;'>");
            tl.Append("<table class='ReportTable'>");
            tl.Append("<thead>");
            tl.Append("<caption style='color:darkblue; font-size:42px;'>Sales by Customer</caption>");

            tl.Append("<tr class='reportTableHeader'>");

            tl.Append("<th class='tableDataHeaders cusnameTHeader'>Last Name</th>");
            tl.Append("<th class='tableDataHeaders cusnameTHeader'>First Name</th>");
            tl.Append("<th class='tableDataHeaders'>Total</th>");
            tl.Append("<th class='tableDataHeaders'>State</th>");
            tl.Append("<th class='tableDataHeaders'>City</th>");
            tl.Append("<th class='tableDataHeaders'>Address</th>");
            tl.Append("<th class='tableDataHeaders'>Email</th>");
            tl.Append("<th class='tableDataHeaders'>Phone</th>");
            tl.Append("<th class='tableDataHeaders'>Selected</th>");


            tl.Append("</tr>");

            tl.Append("</thead>");
            tl.Append("<tbody>");


            int intCount = 0;
            int intCustomerId =0;

            if (querySalesByCustomer.Count() > 0)
            {
                foreach (var cus in querySalesByCustomer)
                {
                    intCount += 1;
                    string radioButtonId = "radio" + intCount.ToString();

                    tl.Append("<tr>");

                    tl.Append("<td class='datecolumnCustomer customerName'>" + cus.strLastName + " </td>");
                    tl.Append("<td class='datecolumnCustomer customerName'>" + cus.strFirstName + " </td>");
                    tl.Append("<td class='datecolumnCustomer customerTotal'>$" + cus.Total + " </td>");
                    tl.Append("<td class='datecolumnCustomer'>" + cus.strStateName + " </td>");
                    tl.Append("<td class='datecolumnCustomer'>" + cus.strCity + " </td>");
                    tl.Append("<td class='datecolumnCustomer cusAddress'>" + cus.strAddress + " </td>");
                    tl.Append("<td class='datecolumnCustomer'>" + cus.strEmail + " </td>");
                    tl.Append("<td class='datecolumnCustomer'>" + cus.strPhone + " </td>");








                    if (hdnSelectedCustomer.Value.ToString() == "")
                    {
                        if (intCount == 1)
                        {
                            tl.Append("<td class='datecolumnProduct TypeSelected'><input id='" + radioButtonId + "' onclick='radioOnClick(\"" + radioButtonId + "\",\"" + cus.intCustomerID + "\")' type = 'radio' name = 'customerID' checked value = '" + cus.intCustomerID + "'>" + cus.strLastName + ","+cus.strFirstName + "</td>");
                            intCustomerId = cus.intCustomerID;
                        }
                        else
                        {
                            tl.Append("<td class='datecolumnProduct TypeSelected'><input id='" + radioButtonId + "' onclick='radioOnClick(\"" + radioButtonId + "\",\"" + cus.intCustomerID + "\")' type = 'radio' name = 'customerID' value = '" + cus.intCustomerID + "'>" + cus.strLastName + "," + cus.strFirstName + "</td>");
                        }
                    }
                    else
                    {

                        if (hdnSelectedCustomer.Value.ToString() == cus.intCustomerID.ToString())
                        {
                            tl.Append("<td class='datecolumnProduct TypeSelected'><input id='" + radioButtonId + "' onclick='radioOnClick(\"" + radioButtonId + "\",\"" + cus.intCustomerID + "\")' type = 'radio' name = 'customerID' checked value = '" + cus.intCustomerID + "'>" + cus.strLastName + "," + cus.strFirstName + "</td>");
                            intCustomerId = cus.intCustomerID;
                        }
                        else
                        {
                            tl.Append("<td class='datecolumnProduct TypeSelected'><input id='" + radioButtonId + "' onclick='radioOnClick(\"" + radioButtonId + "\",\"" + cus.intCustomerID + "\")' type = 'radio' name = 'customerID' value = '" + cus.intCustomerID + "'>" + cus.strLastName + "," + cus.strFirstName + "</td>");
                        }

                    }











                    tl.Append("</tr>");

                }
            }
            else
            {
                tl.Append("<tr><td colspan='7'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");
            tl.Append("</div>");

            lblSalesByCustomer.Text = tl.ToString();


            if (hdnSelectedCustomer.Value.ToString() == "")
            {
                populateOneCustomerPurchases(intCustomerId);
            }
            else
            {
                populateOneCustomerPurchases(Convert.ToInt32(hdnSelectedCustomer.Value));
            }
        }






        protected void populateOneCustomerPurchases(int intCustomerId)
        {


            //lblMessage.Text = Server.UrlDecode(Request.QueryString["message"]);
            int intBandID = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }


            SiteDCDataContext _siteContent = new SiteDCDataContext();

            //Checking that basetype is in database
            bool blnFlagNoMatch = true;
            var queryuCustomer = from ct in _siteContent.TCustomers
                                 select ct;

            foreach (var c in queryuCustomer)
            {
                if (c.intCustomerID == intCustomerId)
                {
                    blnFlagNoMatch = false;
                    break;
                }

            }

            //Basetype is in database
            if (blnFlagNoMatch == false)
            {

                var queryCustomerPurchases = from cos in _siteContent.VCustomersPurchases
                                                orderby cos.intCustomerPurchaseID
                                                where cos.intBandID == intBandID &&
                                                    cos.intCustomerID == intCustomerId
                                             select cos;


                StringBuilder tl = new StringBuilder();
                tl.Append("<div class='DivBorderTableWrappProduct'>");
                tl.Append("<table class='ReportTable'>");
                tl.Append("<caption style='color:darkblue; font-size:38px;'>"+ queryCustomerPurchases.First().strLastName+"," + queryCustomerPurchases.First().strFirstName+"</caption>");
                tl.Append("<thead>");
                tl.Append("<tr class='reportTableHeader'>");
                tl.Append("<th class='CustomerTableDataHeaders C_med'>#Purchase</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_large'>Product Name</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_med'>Price</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_small'>#Units</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_med'>Product Total</th>");
                tl.Append("<th class='CustomerTableDataHeaders C_med'>Purchase Total</th>");
                tl.Append("<th class='CustomerTableDataHeaders'>Date</th>");
                tl.Append("</tr>");
                tl.Append("</thead>");
                tl.Append("<tbody>");

                int intCount = 0;
                if (queryCustomerPurchases.Count() > 0)
                {
                    foreach (var prod in queryCustomerPurchases)
                    {
                        intCount += 1;
                        tl.Append("<tr>");

                        tl.Append("<tr>");
                        tl.Append("<td class='datecolumnCustomerGray'>" + prod.intCustomerPurchaseID + " </td>");
                        tl.Append("<td class='datecolumnCustomer productName'>" + prod.strProductName + " </td>");
                        tl.Append("<td class='datecolumnCustomer'>$" + prod.decMomentPurchaseUnitPrice + " </td>");
                        tl.Append("<td class='datecolumnCustomer'>" + prod.intProductPurchaseCount + " </td>");
                        tl.Append("<td class='datecolumnCustomer productTotal'>$" + prod.decProductTotal + " </td>");
                        tl.Append("<td class='datecolumnCustomerGray'>$" + prod.Purchase_Total + " </td>");
                        tl.Append("<td class='datecolumnCustomerGray'>" + prod.dtmDateTime +" </td>");
                        tl.Append("<tr>");


                        tl.Append("</tr>");

                    }
                }
                else
                {
                    tl.Append("<tr><td colspan='7'>No Content currently available.</td></tr>");
                }

                tl.Append("</tbody>");
                tl.Append("</table>");
                tl.Append("</div>");

                lblSelectedCustomerPurchases.Text = tl.ToString();

            }

        }










    }
}