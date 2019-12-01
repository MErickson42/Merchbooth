using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections;
using System.Text;
using Merchbooth.Classes;

namespace Merchbooth
{
    public partial class CheckoutMain : System.Web.UI.Page
    {

        ArrayList productArrayList = new ArrayList();
        float sngCartTotal = 0;
        DateTime dtmTodayDate = DateTime.Now.Date;
        int intCustomerID = 0;
        int intNewPurchaseNumber = 0;
        int intNewCustomerPurchaseID=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int intCount = 0;
            string n = Request.RawUrl;
            n = HttpUtility.UrlDecode(n);
            StringBuilder sb = new StringBuilder();

            //If somthig was past in as query string 
            if (n.Length > 14)
            {
                n = n.Substring(14);

                String[] spearator = { "}" };


                if (HttpContext.Current.Session["UserDetails"] != null)
                {
                    UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                    intCustomerID = ud.UserKey;
                }

                // using the method 
                String[] strlist = n.Split(spearator,
                StringSplitOptions.None);

                //var productArrayList = new ArrayList();

                foreach (String s in strlist)
                {
                    if (s != "")
                    {
                        productArrayList.Add(new Hashtable());

                        string strForJson = s + "}";
                        JsonConvert.PopulateObject(strForJson, productArrayList[intCount]);

                        intCount += 1;

                        //Response.Write(strlist[intCount]);//testing
                    }
                }


                //now that all the product are orgeized as Hastables in ArrayList - populate view


                sb.Append("<div class = 'CartWrapper'>");

                int intProductID = 0;
                int intTypeID = 0;
                string strImageLink = "";
                Decimal decBandPrice = 0;
                int intAmount = 0;
                float sngProductTotal = 0;

                foreach (Hashtable htProd in productArrayList)
                {
                    foreach (DictionaryEntry pair in htProd)
                    {
                        if ((string)pair.Key == "Id")
                        {
                            intProductID = Convert.ToInt32(pair.Value);
                        }
                        else if ((string)pair.Key == "TypeID")
                        {
                            intTypeID = Convert.ToInt32(pair.Value);
                        }
                        else if ((string)pair.Key == "Image")
                        {
                            strImageLink = Convert.ToString(pair.Value);
                        }
                        else if ((string)pair.Key == "Price")
                        {
                            decBandPrice = Convert.ToDecimal(pair.Value);
                        }
                        else if ((string)pair.Key == "Amount")
                        {
                            intAmount = Convert.ToInt32(pair.Value);
                        }

                    }
                    sngProductTotal = intAmount * (float)decBandPrice;

                    sngCartTotal += sngProductTotal;
                    sb.Append("<div class = 'CartRow'>");

                    //sb.Append("<div class='CartItemImage'>");
                    sb.Append(" <img src='../" + strImageLink + "' class='image-responsive'/>");
                    //added item qty and unit price //EH 11.29.19
                    sb.Append("<p >Qty: ");
                    sb.Append(intAmount);

                    sb.Append("<p >Unit price: $");
                    sb.Append(decBandPrice);
                    sb.Append("</p> </br>");

                    sb.Append("</br><p class='ProductTotal'>Price: $");
                    sb.Append(sngProductTotal);
                    sb.Append("</p>");





                    sb.Append("</div>");


                }


                sb.Append("<div class = 'CartTotalRow'>");
                sb.Append("<p class='CartTotal'>Total: $");
                sb.Append(sngCartTotal);
                sb.Append("</p>");
                sb.Append("</div>");

                sb.Append("</div>");

                ltrCartMain.Text += sb.ToString();
            }
            else
            {
                //sb.Append("<div class='row'><div class='col-md-12'>No products in cart.</div></div>");
                //ltrCartMain.Text += sb.ToString();

            }
        }


    protected void ButtonCustomerPurchase_Click(object sender, EventArgs e)
    {
        string message = "";
        string messageSold = "";
        string messageNotSold = "";
        int intLoopCount = 0;
        SiteDCDataContext _siteContext = new SiteDCDataContext();

        foreach (Hashtable htProd in productArrayList)
        {
            if (htProd.ContainsKey("Id"))
            {
                if (htProd.ContainsKey("Amount"))
                {
                    intLoopCount += 1;

                    var queryProduct = (from p in _siteContext.TProducts
                                        where p.intProductID == Convert.ToInt32(htProd["Id"])
                                        select p).First();

                    if (intLoopCount == 1)
                    {

                            var quryMaxPurchaseNumber = (from p in _siteContext.TCustomerPurchases
                                                        select p.intPurchaseNumber).Max();

                            intNewPurchaseNumber = quryMaxPurchaseNumber + 1;

                            
                            //this is for the intire purchas with a total that represents the sum of all products available
                            TCustomerPurchase customerPurchase = new TCustomerPurchase();

                            customerPurchase.intCustomerID = intCustomerID;
                            customerPurchase.intPurchaseNumber = intNewPurchaseNumber;

                            customerPurchase.decTotal = 0; //This will be added for each product  
                                                           //indevedualy in case any product is not available

                            customerPurchase.dtmDateTime = dtmTodayDate;
                            //customerPurchase.intIsDeleted = 0;



                            _siteContext.TCustomerPurchases.InsertOnSubmit(customerPurchase);

                            _siteContext.SubmitChanges();
                        }

                        if (queryProduct != null)
                        {

                            if (queryProduct.intAmountAvialable >= Convert.ToInt32(htProd["Amount"]))
                            {
                                var quryCretedCustomerPurchase = (from p in _siteContext.TCustomerPurchases
                                                                  where p.intCustomerID == intCustomerID &&
                                                                  p.intPurchaseNumber == intNewPurchaseNumber
                                                                  select p).First();

                                intNewCustomerPurchaseID = quryCretedCustomerPurchase.intCustomerPurchaseID;

                                //this is for one product in the purcahse
                                TCustomerPurchaseProduct customerPurchaseProduct = new TCustomerPurchaseProduct();

                                customerPurchaseProduct.intCustomerPurchaseID = intNewCustomerPurchaseID;
                                customerPurchaseProduct.intProductID = Convert.ToInt32(htProd["Id"]);
                                customerPurchaseProduct.decMomentPurchaseUnitPrice = Convert.ToDecimal(htProd["Price"]);
                                customerPurchaseProduct.intProductPurchaseCount = Convert.ToInt32(htProd["Amount"]);
                                customerPurchaseProduct.decProductTotal = customerPurchaseProduct.decMomentPurchaseUnitPrice * Convert.ToDecimal(customerPurchaseProduct.intProductPurchaseCount);
                                customerPurchaseProduct.strMomentPurchaseIMG = Convert.ToString(htProd["Image"]);
                                customerPurchaseProduct.intIsDeleted = 0;

                                _siteContext.TCustomerPurchaseProducts.InsertOnSubmit(customerPurchaseProduct);



                                //Removing amount from inventory
                                queryProduct.intAmountAvialable -= Convert.ToInt32(htProd["Amount"]);

                                //if (intLoopCount > 1)
                                //{


                                quryCretedCustomerPurchase.decTotal += Convert.ToDecimal(htProd["Amount"]) * Convert.ToDecimal(htProd["Price"]);
                                //}
                                //else
                                //{
                                //    //Adding amount sold in this sale to  TCustomerPurchase
                                //    customerPurchase.decTotal += Convert.ToDecimal(htProd["Amount"]) * Convert.ToDecimal(htProd["Price"]);

                                //}

                                messageSold += "\n" + Convert.ToInt32(htProd["Amount"]) + " " + queryProduct.strProductName + " sold!.";

                                _siteContext.SubmitChanges();

                            }
                            else //If not enough in inventory for product
                            {    //sellig all products accept the one which there is not have enough in inventory

                                messageNotSold += "\nWe only have" + queryProduct.intAmountAvialable + queryProduct.strProductName + ".";
                            }


                        }

                    }
            }
        }
        message = "Purchase proccesed:" + messageSold + messageNotSold;

        Response.Redirect("/Default.aspx?message=" + Server.UrlEncode(message));

        //string strUrl = "../Admin/BoothSalePoint.aspx?message=Purchase complete.";
        //Response.RedirectPermanent(strUrl);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert ('Sale Complete')", true);

    }
}
}