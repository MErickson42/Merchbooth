using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Merchbooth.Classes;

namespace Merchbooth
{
    public partial class BoothSalesPoint : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int intBandID = 0;

            lblMessage.Text = Server.UrlDecode(Request.QueryString["message"]);

            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }


            string strMessage = "";
            if (Request.QueryString["message"] != null)

            {
                strMessage = Request.QueryString["message"].ToString();
            }

            if (strMessage != "")
            {
                Response.Write("<script>alert('" + strMessage + "')</script>");

            }


            //string strUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            //int index1 = strUrl.LastIndexOf('/');

            //strUrl = strUrl.Substring(0, index1);
            //index1 += 1;
            //strUrl = strUrl.Substring(0, index1);

            //A connection to the database to be used when geting or updatinh data  
            SiteDCDataContext _siteContext = new SiteDCDataContext();

            //A tool that we use to bild the html fof each data item comig in from the database
            StringBuilder sb = new StringBuilder();

            var queryProducts = from p in _siteContext.TProducts
                                    where p.intBandID == intBandID && p.intIsDeleted == 0
                                join tp in _siteContext.TTypes
                                on p.intTypeID equals tp.intTypeID
                                join tbp in _siteContext.TBaseTypes
                                on tp.intBaseTypeID equals tbp.intBaseTypeID
                                orderby tp.intBaseTypeID
                                select new { p, tp, tbp };


            queryProducts.ToList();

            if (queryProducts.Count() > 0)
            {
                int intBaseTypeCompare = queryProducts.First().tbp.intBaseTypeID;

                sb.Append("<div class = 'Wrapper'>");

                sb.Append("<div class = 'ImRows'>");
                sb.Append("<div class = 'ImageRow'>");

                foreach (var prod in queryProducts)
                {
                    //Only products with image will be displayed in page to booth sales personal
                    if (prod.p.strImageLink == "" || prod.p.strImageLink == null)
                    {
                        continue;
                    }

                    int intProductID = prod.p.intProductID;
                    int intTypeID = prod.p.intTypeID;
                    string strImageLink = prod.p.strImageLink;


                    if (prod.p.strImageLink != "" )
                    {
                        if (prod.tbp.intBaseTypeID == intBaseTypeCompare)
                        {
                            sb.Append("<div class='OneImage'>");
                            sb.Append(" <img src='../../"  + strImageLink + "' class='image-responsive saleImage' onclick='addToCart(" + intProductID + "," + intTypeID + ",\"" + strImageLink + "\"," + prod.p.decBandPrice + "," + 1 + ")'" + "/>");

                            sb.Append("<p>");
                            sb.Append(prod.p.decBandPrice);
                            sb.Append("</p>");
                            sb.Append("</div>");
                        }
                        else
                        {
                            sb.Append("</div>");
                            sb.Append("<div class = 'ImageRow'>");
                            sb.Append("<div class='OneImage'>");
                            sb.Append(" <img src='../../"   + strImageLink + "' class='image-responsive saleImage' onclick='addToCart(" + intProductID + "," + intTypeID + ",\"" + strImageLink + "\"," + prod.p.decBandPrice + ","+ 1 + ")'" + "/>");

                            sb.Append("<p>");
                            sb.Append("<p>");
                            sb.Append(prod.p.decBandPrice);
                            sb.Append("</p>");
                            sb.Append("</div>");
                            intBaseTypeCompare = prod.tbp.intBaseTypeID;
                        }
                    }

                }
            }
            else
            {
                sb.Append("<div class='row'><div class='col-md-12'>No products are currently available.</div></div>");
            }

            sb.Append("</div>");

            sb.Append("</div>");
            sb.Append("</div>");

            ltrProducts.Text += sb.ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string strUrl = "/Admin/Checkout.aspx?cart=" + hdnCartItemsVariable.Value.ToString();
            Response.RedirectPermanent(strUrl);
           //base.OnLoad(e);??
        }
    }
}