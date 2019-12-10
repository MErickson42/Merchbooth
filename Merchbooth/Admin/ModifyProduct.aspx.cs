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
                        var queryProducts = (from p in _siteContext.TProducts
                                            where p.intProductID == ProductKey 

                                            select p).First();

                        queryProducts.intIsDeleted = 1;

                        _siteContext.SubmitChanges();
                    }

                    Response.Redirect("/admin/products.aspx?message=" + Server.UrlEncode("Product has been deleted."));
                }


                var queryProductsandTypes = from p in _siteContext.TProducts
                                            where p.intProductID == ProductKey && p.intBandID == intBandID
                                            join t in _siteContext.TTypes
                                            on p.intTypeID equals t.intTypeID
                                            select new { p, t };

                //  Populate the Drop Down Box for basetype
                var queryProductTypes = from type in _siteContext.TBaseTypes
                                        where type.intIsDeleted == 0
                                        orderby type.intBaseTypeID
                                        select type;

                ddlProductBaseType.DataTextField = "strBaseType";
                ddlProductBaseType.DataValueField = "intBaseTypeID";
                ddlProductBaseType.DataSource = queryProductTypes;
                ddlProductBaseType.DataBind();

                //  Populate the Drop Down Box for color
                var queryColors = from color in _siteContext.TColors
                                        where color.intIsDeleted == 0
                                        orderby color.intColorID
                                        select color;

                ddlColor.DataTextField = "strColor";
                ddlColor.DataValueField = "intColorID";
                ddlColor.DataSource = queryColors;
                ddlColor.DataBind();

                //  Populate the Drop Down Box for Size
                var querySize = from size in _siteContext.TSizes
                                  where size.intIsDeleted == 0
                                  orderby size.intSizeID
                                  select size;

                ddlSize.DataTextField = "strFullSize";
                ddlSize.DataValueField = "intSizeID";
                ddlSize.DataSource = querySize;
                ddlSize.DataBind();

                //  //  Populate the Drop Down Box for Gender
                var queryGender = from gender in _siteContext.TGenders
                                where gender.intIsDeleted == 0
                                orderby gender.intGenderID
                                select gender;

                ddlGender.DataTextField = "strGender";
                ddlGender.DataValueField = "intGenderID";
                ddlGender.DataSource = queryGender;
                ddlGender.DataBind();


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

                    //var queryType = from 

                    foreach (var prod in queryProductsandTypes)
                    {
                        ProductTitle.Text = prod.p.strProductName;
                        ltrImagePath.Text = prod.p.strImageLink;

                        txtPrice.Text = prod.p.decBandPrice.ToString();
                        txtPriceForBand.Text = prod.p.decCostToBand.ToString();
                        txtQuantity.Text = prod.p.intAmountAvialable.ToString();

                        ddlColor.SelectedIndex = prod.t.intColorID;
                        ddlGender.SelectedIndex = prod.t.intGenderID;

                    }

                    //foreach (TProduct prod in queryProducts)
                    //{
                    //    ProductTitle.Text = prod.strProductName;
                    //    ltrImagePath.Text = prod.strImageLink;

                    //    txtPrice.Text = prod.decBandPrice.ToString();
                    //    txtPriceForBand.Text = prod.decCostToBand.ToString();
                    //    txtQuantity.Text = prod.intAmountAvialable.ToString();
                    //}
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

            // Get values of dropdowns and store in variable
            int intGender = Convert.ToInt32(ddlGender.SelectedValue);
            int intColor = Convert.ToInt32(ddlColor.SelectedValue);
            int intSize = Convert.ToInt32(ddlSize.SelectedValue);
            int intBaseType = Convert.ToInt32(ddlProductBaseType.SelectedValue);

            SiteDCDataContext _siteContext = new SiteDCDataContext();

            if (ProductKey > 0) // Update the Product
            {
                var queryProducts = from p in _siteContext.TProducts
                                    where p.intProductID== ProductKey && p.intBandID == intBandID
                                    select p;
                 
                // MDE Join for getting types joined to products
                var queryProductsandTypes = from p in _siteContext.TProducts
                                            where p.intProductID == ProductKey && p.intBandID == intBandID 
                                            join t in _siteContext.TTypes
                                            on p.intTypeID equals t.intTypeID
                                            select new { p, t };

                foreach (var prod in queryProductsandTypes)
                {
                    prod.p.strProductName = strTitle;
                    sOldProductPath = prod.p.strImageLink;
                    prod.p.strImageLink = sOldProductPath;
                    prod.p.decBandPrice = decPrice;
                    prod.p.intAmountAvialable = intQuantity;
                    prod.p.decCostToBand = decBandPrice;
                    prod.p.intBandID = intBandID;
                    prod.p.intTypeID = prod.t.intTypeID;

                    // update type table
                    prod.t.intGenderID = intGender;
                    prod.t.intColorID = intColor;
                    prod.t.intBaseTypeID = intBaseType;
                    prod.t.intSizeID = intSize;
                }

                _siteContext.SubmitChanges();

                message = strTitle + " has been updated.";
            }
            else // Add a Product
            {
                //add new entry to ttypes
                TType type = new TType();
                type.intBaseTypeID = intBaseType;
                type.intColorID = intColor;
                type.intGenderID = intGender;
                type.intSizeID = intSize;
                type.strQrCode = "";
                type.intIsDeleted = 0;
                _siteContext.TTypes.InsertOnSubmit(type);
                _siteContext.SubmitChanges();

                TProduct prod = new TProduct();

                prod.strProductName = strTitle;
                prod.strImageLink = "";
                prod.decBandPrice = decPrice;
                prod.decCostToBand = decBandPrice;
                prod.intAmountAvialable = intQuantity;
              
                prod.intBandID = intBandID;
                // Get the ID of the TType entry we just created
                prod.intTypeID = type.intTypeID;
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