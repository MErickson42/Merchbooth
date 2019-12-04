<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Merchbooth.Customer.Default" %>
<asp:Content ID="HeaderImage1" ContentPlaceHolderID="HeaderImage" runat="server">
  
    <div class="headerImage">
         
   </div>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomerContent" runat="server">
    <div style="margin-top:200px"></div>
    <asp:Literal  ID="ltrProducts" runat="server"></asp:Literal>
   
    <%--Removed ben 11/30--%> 
    <%--<img src="Images/download1.jpg" />--%>


    <%--Added ben 11/30--%>
    <asp:HiddenField ID="hdnCartItemsVariable" value="" runat="server" />
    <asp:LinkButton ID="LnkButtion" CssClass="buttonClass" runat="server" Text="Checkout" OnClick="checkoutMain_Click"/>


    <style type="text/css">
                 /*#testing
                 {
                    padding: 5px 10px;
                    text-decoration: none;
                    background-color: bisque;
                    z-index:50;
                    position:fixed;
                    right:0px;
                    top:225px;
                    height: 100px;
                    width:400px;
                    color:#262422;
                    font-size: 20px;
                    border-radius:4px 4px 4px 4px;
                 }*/
                .buttonClass
                {
                    padding: 5px 10px;
                    text-decoration: none;
                    /*border: solid 3px #cf6c0a;*/
                    background-color: #ed7f11;
                    z-index:50;
                    position:fixed;
                    right:0px;
                    top:185px;
                    color:#262422;
                    font-size: 20px;
                    border-radius:4px 4px 4px 4px;
                }
                .buttonClass:hover
                {
                    transition-duration:300ms;
                    font-size: 22px;
                    border-radius:30px;
                    padding:20px,10px;
                    text-decoration:none;

                }
            </style>
    	    <script type="text/javascript">

                var Products = {};

                //var objCart = { intTotalCount: 0, Products};
                var cartUrl = "http://localhost:10349/About.aspx";

                var intTotalCount = 0;


                function addToCart(intProductID, intTypeID,strImageUrl, decPrice, intAmount) {

                intTotalCount += 1;
                var strProductNumber = "" + intProductID;

                if (strProductNumber in Products) {

                    Products[strProductNumber].Amount += intAmount

                }
                else
                {

                    Products[strProductNumber] = { Id: intProductID, TypeId: intTypeID, Image: "\""+ strImageUrl +"\"", Price: decPrice, Amount: intAmount };


                }

                //objCart.Products{objCart.intTotalCount-1 } = "{Id:" + intProductID + ",TypeId:" + intTypeID + ",Image:" + strImageUrl + ",Price:" + decPrice + ",Amount:" + intAmount + "},";
			    //document.getElementById(id).innerHTML =  objCart.ThirstIDs + objCart.intTotalCount;
                //


                document.getElementById("cartCount").innerHTML = intTotalCount + " +";

                //document.getElementById("testing").innerHTML =  Products;

                document.getElementById("<%= hdnCartItemsVariable.ClientID%>").value = ObjToString(Products);

                }


                function ObjToString(Products) {

                    var strProductString = "";

                    var intcount = 0;
                    for(ProductNumber in Products)
                    {
                        intcount += 1;
                        //strProductString += "" +intcount +"{Id:" + prod['Id'] + ",TypeId:" + prod['TypeId'] + ",Image:" + prod['Image'] + ",Price:" + prod['Price'] + ",Amount:" + prod['Amount'] + "}";
                        strProductString +="{Id:" + Products[ProductNumber].Id + ",TypeId:" + Products[ProductNumber].TypeId + ",Image:" +Products[ProductNumber].Image + ",Price:" + Products[ProductNumber].Price + ",Amount:" + Products[ProductNumber].Amount + "}";

                    }
                    return strProductString;
                }


                </script>


</asp:Content>
