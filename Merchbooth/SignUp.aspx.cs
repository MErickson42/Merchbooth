using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Merchbooth {
	public partial class WebForm1 : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SiteDCDataContext _siteContext = new SiteDCDataContext();

                string Action = Request.QueryString["a"];
                int ProductKey = 0;
                if (!String.IsNullOrEmpty(Request.QueryString["pk"]))
                {
                    ProductKey = Convert.ToInt32(Request.QueryString["pk"]);
                }

                if (Action == "d")
                {
                    if (ProductKey > 0) // Delete a product.
                    {
                        var queryProducts = from p in _siteContext.TProducts
                                            where p.intProductID == ProductKey
                                            select p;



                        _siteContext.SubmitChanges();
                    }

                    Response.Redirect("/admin/products.aspx?message=" + Server.UrlEncode("Product has been deleted."));
                }

                //if (ProductKey == 0)
                //{
                //    btnUpdateProduct.Text = "Add";
                //    FormHeader.Text = "Add a Product";
                //}
                //else
                //{
                    //btnUpdateProduct.Text = "Update";
                    FormHeader.Text = "Band Sign-Up";

                    //var queryProducts = from p in _siteContext.TProducts
                    //                    where p.intProductID == ProductKey
                    //                    select p;

                    //foreach (TProduct prod in queryProducts)
                    //{
                        //ProductTitle.Text = prod.strProductName;
                        //ltrImagePath.Text = prod.strImageLink;
                        //txtPrice.Text = prod.decBandPrice.ToString();
                        //txtQuantity.Text = prod.intAmountAvialable.ToString();
                    //}
                //}


            }

        }

        protected void btnSigmUpBand_Click(object sender, EventArgs e)
        {
            string message = "";

            string strBandName  = txtBandName.Text;
            string strPassword  = txtPassword.Text;
            string strPhone     = txtPhone.Text;
            string strEmail     = txtEmail.Text;
            string strCity      = txtCity.Text;
            string strAddress   = txtAddress.Text;
            string strZip       = txtZip.Text;

            int intState = 1;

            SiteDCDataContext _siteContext = new SiteDCDataContext();


            TBand band = new TBand();

            band.strBandName = strBandName;
            band.strPassword = strPassword;
            band.strPhone = strPhone;
            band.strEmail = strEmail;
            band.intStateID = intState;
            band.strCity = strCity;

            band.strAddress = strAddress;
            band.strZip = strZip;

            band.strHeaderImage = "";
            band.strBackroundImage = "";
            band.strTeamPassword = "";

            _siteContext.TBands.InsertOnSubmit(band);

            _siteContext.SubmitChanges();

            int BandKey = band.intBandID;

            message = "Band " + band.strBandName + " has registered.";



            //}
            string newFileDirectory = Request.PhysicalApplicationPath.ToString() + "Uploads\\Bands\\" + BandKey + "\\";
            string newBandHeaderPath = "";

            if (!Directory.Exists(newFileDirectory))
            {
                Directory.CreateDirectory(newFileDirectory);
            }

            if ((BandHeaderImage.HasFile) && (BandHeaderImage.PostedFile.ContentType.ToLower() == "image/jpeg"))
            {
                string newFileName = BandHeaderImage.FileName;


                string newFilePath = newFileDirectory + newFileName;

                BandHeaderImage.PostedFile.SaveAs(newFilePath);

                newBandHeaderPath = "Uploads/Bands/" + BandKey + "/" + BandHeaderImage.FileName;

            }

            if (newBandHeaderPath.Length > 0)
            {
                var queryBands = from b in _siteContext.TBands
                                    where b.intBandID == BandKey
                                    select b;

                foreach (TBand tband in queryBands)
                {
                    tband.strHeaderImage = newBandHeaderPath;
                }

                _siteContext.SubmitChanges();
            }



            string newBandBackgroundPath = "";

            if (!Directory.Exists(newFileDirectory))
            {
                Directory.CreateDirectory(newFileDirectory);
            }

            if ((BandHeaderImage.HasFile) && (BandHeaderImage.PostedFile.ContentType.ToLower() == "image/jpeg"))
            {
                string newFileName = BandHeaderImage.FileName;


                string newFilePath = newFileDirectory + newFileName;

                BandHeaderImage.PostedFile.SaveAs(newFilePath);

                newBandBackgroundPath = "Uploads/Bands/" + BandKey + "/" + BandHeaderImage.FileName;

            }

            if (newBandBackgroundPath.Length > 0)
            {
                var queryBands = from b in _siteContext.TBands
                                 where b.intBandID == BandKey
                                 select b;

                foreach (TBand tband in queryBands)
                {
                    tband.strBackroundImage = newBandBackgroundPath;
                }

                _siteContext.SubmitChanges();
            }

            Response.Redirect("/Admin/Products.aspx?message=" + Server.UrlEncode(message));
        }

            protected void btnCancel_Click(object sender, EventArgs e)
            {
                Response.Redirect("/");
            }
        
    }
}