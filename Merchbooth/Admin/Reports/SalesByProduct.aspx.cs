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
    public partial class SalesByProduct : System.Web.UI.Page
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


            //Ceating- Report by type string

            var querySalesByTypes = from sbc in _siteContent.VCustomersPurchases
                                   .Where(x => x.intBandID == intBandID)
                                   .AsEnumerable()
                                   .GroupBy(x => new { x.strBaseType})
                                   .ToList()
                                   .Select(x => new { Total = x.Sum(b => b.decProductTotal), Count = x.Sum(c =>c.intProductPurchaseCount), x.Key.strBaseType })
                                   .OrderBy(x => x.strBaseType)
                                       select sbc;


            StringBuilder tl = new StringBuilder();
            tl.Append("<div class='DivBorderTableWrappProduct'>");
            tl.Append("<table class='ReportTable'>");
            tl.Append("<thead>");
            tl.Append("<tr class='reportTableHeader'>");
            tl.Append("<th class='tableDataHeaders'>Type</th>");
            tl.Append("<th class='tableDataHeaders'>Total</th>");
            tl.Append("<th class='tableDataHeaders'>Av. Price</th>");
            tl.Append("<th class='tableDataHeaders'>#Num</th>");
            tl.Append("<th class='tableDataHeaders'>Selected</th>");
            tl.Append("</tr>");
            tl.Append("</thead>");
            tl.Append("<tbody>");

            int intCount = 0;
            string strFirsBaseType = "";
            if (querySalesByTypes.Count() > 0)
            {
                foreach (var prod in querySalesByTypes)
                {
                    intCount += 1;
                    string radioButtonId = "radio" + intCount.ToString();

                    tl.Append("<tr>");

                    tl.Append("<td class='datecolumnProduct productType '>" + prod.strBaseType + " </td>");
                    tl.Append("<td class='datecolumnProduct productTotal'>$" + prod.Total + " </td>");
                    tl.Append("<td class='datecolumnProduct productAvrege'>$" + Math.Round((prod.Total / prod.Count),2) + " </td>");
                    tl.Append("<td class='datecolumnProduct productAmount'>" + prod.Count + " </td>");

                    if(hdnSelecteType.Value.ToString() == "")
                    {
                        if (intCount == 1)
                        {
                            tl.Append("<td class='datecolumnProduct TypeSelected'><input id='" + radioButtonId + "' onclick='radioOnClick(\"" + radioButtonId + "\",\"" + prod.strBaseType + "\")' type = 'radio' name = 'basetype' checked value = '" + prod.strBaseType + "'>" + prod.strBaseType + "</td>");
                            //tl.Append("<td class='datecolumnProduct productAmount'><asp:RadioButton ID=\"" + prod.strBaseType + "\"  runat = \"server\" GroupName = \"BaseType\" Text = \"" + prod.strBaseType + "\" OnClick=\"btnUpdateBandAccount_Click\"/></td>");
                            strFirsBaseType = prod.strBaseType;
                        }
                        else
                        {
                            tl.Append("<td class='datecolumnProduct TypeSelected'><input id='" + radioButtonId + "' onclick='radioOnClick(\"" + radioButtonId + "\",\"" + prod.strBaseType + "\")' type = 'radio' name = 'basetype' value = '" + prod.strBaseType + "'>" + prod.strBaseType + "</td>");
                            //tl.Append("<td class='datecolumnProduct productAmount'><asp:RadioButton ID=\"" + prod.strBaseType + "\"  runat = \"server\" GroupName = \"BaseType\" Text = \"" + prod.strBaseType + "\" OnClick=\"btnUpdateBandAccount_Click\"/></td>");
                        }
                    }
                    else
                    {

                        if (hdnSelecteType.Value.ToString() == prod.strBaseType)
                        {
                            tl.Append("<td class='datecolumnProduct TypeSelected'><input id='" + radioButtonId + "' onclick='radioOnClick(\"" + radioButtonId + "\",\"" + prod.strBaseType + "\")' type = 'radio' name = 'basetype' checked value = '" + prod.strBaseType + "'>" + prod.strBaseType + "</td>");
                            //tl.Append("<td class='datecolumnProduct productAmount'><asp:RadioButton ID=\"" + prod.strBaseType + "\"  runat = \"server\" GroupName = \"BaseType\" Text = \"" + prod.strBaseType + "\" OnClick=\"btnUpdateBandAccount_Click\"/></td>");
                            strFirsBaseType = prod.strBaseType;
                        }
                        else
                        {
                            tl.Append("<td class='datecolumnProduct TypeSelected'><input id='" + radioButtonId + "' onclick='radioOnClick(\"" + radioButtonId + "\",\"" + prod.strBaseType + "\")' type = 'radio' name = 'basetype' value = '" + prod.strBaseType + "'>" + prod.strBaseType + "</td>");
                            //tl.Append("<td class='datecolumnProduct productAmount'><asp:RadioButton ID=\"" + prod.strBaseType + "\"  runat = \"server\" GroupName = \"BaseType\" Text = \"" + prod.strBaseType + "\" OnClick=\"btnUpdateBandAccount_Click\"/></td>");
                        }

                    }

                    tl.Append("</tr>");

                }
            }
            else
            {
                tl.Append("<tr><td colspan='5'>No Content currently available.</td></tr>");
            }

            tl.Append("</tbody>");
            tl.Append("</table>");
            tl.Append("</div>");

            lblSalesByTypes.Text = tl.ToString();

            if(hdnSelecteType.Value.ToString() == "")
            {
                populateOneTypeTable(strFirsBaseType);
            }
            else
            {
                populateOneTypeTable(hdnSelecteType.Value.ToString());
            }
        }



        //protected void btnUpdateBandAccount_Click(object sender, EventArgs e)
        //{
        //    populateOneTypeTable(sender.ToString());
        //}





        protected void populateOneTypeTable(string strBaseType)
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
            var queryBaseTypes = from bt in _siteContent.TBaseTypes
                                select bt;

           foreach(var bstp in queryBaseTypes)
            {
                if (bstp.strBaseType == strBaseType)
                {
                    blnFlagNoMatch = false;
                    break;
                }

            }

           //Basetype is in database
           if(blnFlagNoMatch == false)
            {

                var querySalesByProduct = from sbc in _siteContent.VCustomersPurchases
                                                   .Where(x => x.intBandID == intBandID && x.strBaseType == strBaseType)
                                                   .AsEnumerable()
                                                   .GroupBy(x => new { x.intProductID,  x.strProductName, Average = (x.decProductTotal/x.intProductPurchaseCount), x.strImageLink})
                                                   .ToList()
                                                   .Select(x => new { Total = x.Sum(b => b.decProductTotal), Count = x.Sum(c => c.intProductPurchaseCount), x.Key.strProductName, x.Key.strImageLink })
                                          select sbc;


                StringBuilder tl = new StringBuilder();
                tl.Append("<div class='DivBorderTableWrappProduct'>");
                tl.Append("<table class='ReportTable'>");
                tl.Append("<thead>");
                tl.Append("<tr class='reportTableHeader'>");
                tl.Append("<th class='tableDataHeaders'>Product</th>");
                tl.Append("<th class='tableDataHeaders'>Total</th>");
                tl.Append("<th class='tableDataHeaders'>Price</th>");
                tl.Append("<th class='tableDataHeaders'>#Num</th>");
                tl.Append("<th class='tableDataHeaders'>Image Link</th>");
                tl.Append("</tr>");
                tl.Append("</thead>");
                tl.Append("<tbody>");

                int intCount = 0;
                if (querySalesByProduct.Count() > 0)
                {
                    foreach (var prod in querySalesByProduct)
                    {
                        intCount += 1;
                        tl.Append("<tr>");

                        tl.Append("<td class='datecolumnProduct productType '>" + prod.strProductName + " </td>");
                        tl.Append("<td class='datecolumnProduct productTotal'>$" + prod.Total + " </td>");
                        tl.Append("<td class='datecolumnProduct productAvrege'>$" + Math.Round((prod.Total / prod.Count), 2) + " </td>");
                        tl.Append("<td class='datecolumnProduct productAmount'>" + prod.Count + " </td>");
                        tl.Append("<td class='datecolumnProduct'>" + prod.strImageLink + " </td>");
                        //if (intCount == 1)
                        //{
                        //    tl.Append("<td class='datecolumnProduct TypeSelected'><input onclick='radioOnClick(\"" + prod.strBaseType + "\")' type = 'radio' name = 'basetype' checked value = '" + prod.strBaseType + "'>" + prod.strBaseType + "</td>");
                        //    //tl.Append("<td class='datecolumnProduct productAmount'><asp:RadioButton ID=\"" + prod.strBaseType + "\"  runat = \"server\" GroupName = \"BaseType\" Text = \"" + prod.strBaseType + "\" OnClick=\"btnUpdateBandAccount_Click\"/></td>");

                        //}
                        //else
                        //{
                        //    tl.Append("<td class='datecolumnProduct TypeSelected'><input onclick='radioOnClick(\"" + prod.strBaseType + "\")' type = 'radio' name = 'basetype' value = '" + prod.strBaseType + "'>" + prod.strBaseType + "</td>");
                        //    //tl.Append("<td class='datecolumnProduct productAmount'><asp:RadioButton ID=\"" + prod.strBaseType + "\"  runat = \"server\" GroupName = \"BaseType\" Text = \"" + prod.strBaseType + "\" OnClick=\"btnUpdateBandAccount_Click\"/></td>");
                        //}
                        tl.Append("</tr>");

                    }
                }
                else
                {
                    tl.Append("<tr><td colspan='5'>No Content currently available.</td></tr>");
                }

                tl.Append("</tbody>");
                tl.Append("</table>");
                tl.Append("</div>");

                lblProductSalesByType.Text = tl.ToString();

            }
            
        }

    
    }
}