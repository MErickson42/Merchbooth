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

            //get band object with ID for background images EH 12.11.2019			
            var queryBand = (from b in _siteContext.TBands
                             where b.intBandID == intBandID
                             select b).First();



            queryProducts.ToList();

            if (queryProducts.Count() > 0)
            {

                sb.Append("<div class='BoothProductPAGE'>");
                //sb.Append("<h1 class='ecBantTitle'>" + queryBand.strBandName + "</h1>");

                if (queryBand.strBackroundImage != "")
                {
                    sb.Append("<img class='Booth_BackgroundImage' src='/" + queryBand.strBackroundImage + "'  >");
                }

                sb.Append("<div style='margin-top:25px;'>");
                sb.Append("<div class='row'style='margin-left:40px;'>");

                //sb.Append("<div class='row'><div class='col-md-12'><hr /></div></div>");
                int intPreviousBaseType = queryProducts.First().tbp.intBaseTypeID;
                int intCurrentBaseType = queryProducts.First().tbp.intBaseTypeID;

                foreach (var prod in queryProducts)
                {
                    //Only products with image will be displayed in page to customer
                    if (prod.p.strImageLink == "" || prod.p.strImageLink == null)
                    {
                        continue;
                    }
                    intCurrentBaseType = prod.tbp.intBaseTypeID;
                    if (intCurrentBaseType != intPreviousBaseType)
                    {
                        intPreviousBaseType = intCurrentBaseType;
                        sb.Append("</div>");

                        sb.Append("<div class='row'style='margin-left:40px;'>");

                    }
                    sb.Append(" <img style='display:inline; margin-right:100px;' class='image-responsiveBooth saleImageBooth' src='/" + prod.p.strImageLink + "' runat='server' onclick='addToCart(" + prod.p.intProductID + "," + prod.p.intTypeID + ",\"" + prod.p.strImageLink + "\"," + prod.p.decBandPrice + "," + 1 + ")'" + "/>");
                    sb.Append("<p style='display:inline; z-index:15; color:darkred;position:relative; top:7px; right:200px; background-color:white; font-weight:bold;'>$ ");
                    sb.Append(prod.p.decBandPrice);
                    sb.Append("</p>");

                }
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

            }
            else
            {
                sb.Append("<div class='row'><div class='col-md-12'>No products for this band are currently available.</div></div>");
            }

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