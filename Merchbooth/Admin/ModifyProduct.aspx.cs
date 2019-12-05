using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Merchbooth.Classes;

namespace Merchbooth.Admin
{
    public partial class ModifyProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SiteDCDataContext _siteContext = new SiteDCDataContext();

                int intBandID = 0;
                if (HttpContext.Current.Session["UserDetails"] != null)
                {
                    UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                    intBandID = ud.UserKey;
                }

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
                                            where p.intProductID == ProductKey && p.intBandID == intBandID

                                            select p;

                      

                        _siteContext.SubmitChanges();
                    }

                    Response.Redirect("/admin/products.aspx?message=" + Server.UrlEncode("Product has been deleted."));
                }

                if (ProductKey == 0)
                {
                    btnUpdateProduct.Text = "Add";
                    FormHeader.Text = "Add a Product";
                }
                else
                {
                    btnUpdateProduct.Text = "Update";
                    FormHeader.Text = "Update a Product";

                    var queryProducts = from p in _siteContext.TProducts
                                        where p.intProductID == ProductKey && p.intBandID == intBandID
                                        select p;

                    foreach (TProduct prod in queryProducts)
                    {
                        ProductTitle.Text = prod.strProductName;
                        ltrImagePath.Text = prod.strImageLink;
                        txtPrice.Text = prod.decBandPrice.ToString();
                        txtPriceForBand.Text = prod.decCostToBand.ToString();
                        txtQuantity.Text = prod.intAmountAvialable.ToString();
                    }
                }


            }

        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            int intBandID = 0;
            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                intBandID = ud.UserKey;
            }

            string message = "";
            int ProductKey = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["pk"]))
            {
                ProductKey = Convert.ToInt32(Request.QueryString["pk"]);
            }
          

            string strTitle = ProductTitle.Text;
            int intQuantity = Int32.Parse(txtQuantity.Text);
            decimal decPrice = Decimal.Parse(txtPrice.Text);
            decimal decBandPrice = Decimal.Parse(txtPriceForBand.Text);
            string sOldProductPath = "";

            SiteDCDataContext _siteContext = new SiteDCDataContext();

            if (ProductKey > 0) // Update the Product
            {
                var queryProducts = from p in _siteContext.TProducts
                                    where p.intProductID== ProductKey && p.intBandID == intBandID
                                    select p;

                foreach (TProduct prod in queryProducts)
                {
                    prod.strProductName = strTitle;
                    sOldProductPath = prod.strImageLink;
                    prod.strImageLink = sOldProductPath;
                    prod.decBandPrice = decPrice;
                    prod.intAmountAvialable = intQuantity;
                    prod.decCostToBand = decBandPrice;
                    prod.intBandID = intBandID;
                    prod.intTypeID = 1;
                }

                _siteContext.SubmitChanges();

                message = strTitle + " has been updated.";
            }
            else // Add a Product
            {
                TProduct prod = new TProduct();

                prod.strProductName = strTitle;
                prod.strImageLink = "";
                prod.decBandPrice = decPrice;
                prod.decCostToBand = decBandPrice;
                prod.intAmountAvialable = intQuantity;
                //MDE - For now - just hardcoding TypeID 1 until  I write the join for type
                prod.intBandID = intBandID;
                prod.intTypeID = 1;
                prod.intSortLevel = 10;

                _siteContext.TProducts.InsertOnSubmit(prod);

                _siteContext.SubmitChanges();

                ProductKey = prod.intProductID;

                message = strTitle + " has been added.";
            }
            string newFileDirectory = Request.PhysicalApplicationPath.ToString() + "Uploads\\Products\\" + ProductKey + "\\";
            string newProductPath = "";

            if (!Directory.Exists(newFileDirectory))
            {
                Directory.CreateDirectory(newFileDirectory);
            }

            if ((ProductImage.HasFile) && (ProductImage.PostedFile.ContentType.ToLower() == "image/jpeg"))
            {
                if (sOldProductPath.Length > 0)
                {
                    string OldDocumentFilePath = Request.PhysicalApplicationPath.ToString() + sOldProductPath.Replace("/", "\\");

                    if (File.Exists(OldDocumentFilePath))
                    {
                        File.Delete(OldDocumentFilePath);
                    }
                }
                string newFileName = ProductImage.FileName;


                string newFilePath = newFileDirectory + newFileName;

                ProductImage.PostedFile.SaveAs(newFilePath);

                newProductPath = "Uploads/Products/" + ProductKey + "/" + ProductImage.FileName;

            }
            else
            {
                newProductPath = sOldProductPath;
            }

            if (newProductPath.Length > 0)
            {
                var queryProducts = from p in _siteContext.TProducts
                                    where p.intProductID == ProductKey
                                    select p;

                foreach (TProduct prod in queryProducts)
                {
                    prod.strImageLink = newProductPath;
                }

                _siteContext.SubmitChanges();
            }

            Response.Redirect("/Admin/Products.aspx?message=" + Server.UrlEncode(message));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Products.aspx/");
        }
    }
}