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

namespace Merchbooth
{
    public partial class Checkout : System.Web.UI.Page
    {
        ArrayList productArrayList = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            int intCount = 0;
            string n = Request.RawUrl;
            n = HttpUtility.UrlDecode(n);
            StringBuilder sb = new StringBuilder();

            if (n.Length >9)
            {
                n = n.Substring(10);

            String[] spearator = { "}" };


            //If somthig was past in as query string 



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
                float sngCartTotal = 0;

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

                    sb.Append("<p class='ProductTotal'>Price $: ");
                    sb.Append(sngProductTotal);
                    sb.Append("</p>");

                    //sb.Append("</div>");
                    sb.Append("</div>");


                }


                sb.Append("<div class = 'CartTotalRow'>");
                sb.Append("<p class='CartTotal'>Total $: ");
                sb.Append(sngCartTotal);
                sb.Append("</p>");
                sb.Append("</div>");

                sb.Append("</div>");

                ltrCart.Text += sb.ToString();
            }
            else
            {
                //sb.Append("<div class='row'><div class='col-md-12'>No products in cart.</div></div>");
                //ltrCart.Text += sb.ToString();

            }
        }


        protected void LinkButtonPurchase_Click(object sender, EventArgs e)
        {

            SiteDCDataContext _siteContext = new SiteDCDataContext();

            foreach (Hashtable htProd in productArrayList)
            {
                if (htProd.ContainsKey("Id"))
                {
                    if (htProd.ContainsKey("Amount"))
                    {
                        var queryProduct = (from c in _siteContext.TProducts
                                            where c.intProductID == Convert.ToInt32(htProd["Id"])
                                            select c).First();
                        if (queryProduct.intAmountAvialable >= Convert.ToInt32(htProd["Amount"]))
                        {
                            queryProduct.intAmountAvialable -= Convert.ToInt32(htProd["Amount"]);
                            _siteContext.SubmitChanges();

                        }

                    }
                }
            }

            string strUrl = "BoothSalesPoint.aspx";
            Response.RedirectPermanent(strUrl);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert ('Sale Complete')", true);

        }
    }
}