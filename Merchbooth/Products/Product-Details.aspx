﻿<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product-Details.aspx.cs" Inherits="Merchbooth.Products.Product_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
    <%--<asp:Image ID="imgBand" ImageUrl="/" runat="server" />--%>

    <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="z-index:9999">
                <div class="col-md-12">
                    <h1><asp:Literal ID="ltrBandName" runat="server"></asp:Literal></h1>
                </div>
            </div>

    <asp:Literal ID="ltrProducts" runat="server"></asp:Literal>
        <asp:HiddenField ID="hdnCartItemsVariable" value="" runat="server" />
        <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />


     <script type="text/javascript">

                var Products = {};

                //var objCart = { intTotalCount: 0, Products};
                var cartUrl = "http://localhost:10349/About.aspx";

                var intTotalCount = 0;


                function addToCart(intProductID, intTypeID,strImageUrl, decPrice, intAmount) {

                intTotalCount += 1;
                var strProductNumber = "" + intProductID;
                    var cartString;

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


                document.getElementById("cartCount").innerHTML = intTotalCount;

                //document.getElementById("testing").innerHTML =  Products;

                document.getElementById("<%= hdnCartItemsVariable.ClientID%>").value = ObjToString(Products);

                 cartString =  ObjToString(Products);                        
                document.getElementById("home").href = "http://localhost:10349/Default.aspx?cart=" + cartString;
                document.getElementById("allbands").href = "http://localhost:10349/AllBands.aspx?cart=" + cartString;
                document.getElementById("about").href = "http://localhost:10349/About.aspx?cart=" + cartString;
                document.getElementById("contact").href = "http://localhost:10349/Contact.aspx?cart=" + cartString;
                document.getElementById("sign").href = "http://localhost:10349/SignInOptions.aspx?cart=" + cartString; 

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

                window.onload = function ()
                {

                    var strCart = document.getElementById("<%= hdnPassedCartItemsVariable.ClientID%>").value;
                    var cartStringB = strCart;
                    var intId = 0;
                    var intTypeId = 0;
                    var strImage = "";
                    var decPrice = 0.00;
                    var intAmount = 0;
                    var intStartIndex = 0;
                    var intEndeIndex = 0;
                    var intCharctersToCopy = 0;

                    while (strCart.indexOf("{") != -1)
                    {

                        intStartIndex = strCart.indexOf("Id");
                        intEndIndex = strCart.indexOf(",", intStartIndex);
                        intCharctersToCopy = intEndIndex - intStartIndex - 3;
                        intId = strCart.substring(intStartIndex + 3, intEndIndex);

                        intStartIndex = strCart.indexOf("TypeId");
                        intEndIndex = strCart.indexOf(",", intStartIndex);
                        intCharctersToCopy = intEndIndex - intStartIndex - 7;
                        intTypeId = 1 * (strCart.substring(intStartIndex + 7, intEndIndex));

                        intStartIndex = strCart.indexOf("Image");
                        intEndIndex = strCart.indexOf(",", intStartIndex);
                        intCharctersToCopy = intEndIndex - intStartIndex - 6;
                        strImage = strCart.substring(intStartIndex + 6, intEndIndex);

                        intStartIndex = strCart.indexOf("Price");
                        intEndIndex = strCart.indexOf(",", intStartIndex);
                        intCharctersToCopy = intEndIndex - intStartIndex - 6;
                        decPrice = 1 * (strCart.substring(intStartIndex + 6, intEndIndex));

                        intStartIndex = strCart.indexOf("Amount");
                        intEndIndex = strCart.indexOf("}", intStartIndex);
                        intCharctersToCopy = intEndIndex - intStartIndex - 7;
                        intAmount = 1 * (strCart.substring(intStartIndex + 7, intEndIndex));

                        intTotalCount += 1 * intAmount;

                        Products[intId] = { Id: intId, TypeId: intTypeId, Image: strImage, Price: decPrice, Amount: intAmount };

                        strCart = strCart.substring(intEndIndex);
                    }

                    if (intTotalCount > 0)
                    {
                        document.getElementById("cartCount").innerHTML = intTotalCount;

                        document.getElementById("<%= hdnCartItemsVariable.ClientID%>").value = ObjToString(Products);

                        document.getElementById("home").href = "http://localhost:10349/Default.aspx?cart=" + cartStringB;
                        document.getElementById("allbands").href = "http://localhost:10349/AllBands.aspx?cart=" + cartStringB;
                        document.getElementById("about").href = "http://localhost:10349/About.aspx?cart=" + cartStringB;
                        document.getElementById("contact").href = "http://localhost:10349/Contact.aspx?cart=" + cartStringB;
                        document.getElementById("sign").href = "http://localhost:10349/SignInOptions.aspx?cart=" + cartStringB;
 

                    }
                }

                function ClearCart()
                {

                    if (intTotalCount > 0)
                    {
                        for (var member in Products) delete Products[member];
                        intTotalCount = 0;  
                        document.getElementById("cartCount").innerHTML = "";
                        document.getElementById("<%= hdnCartItemsVariable.ClientID%>").value = "";
                          
                        document.getElementById("home").href = "http://localhost:10349/Default.aspx?cart=" ;
                        document.getElementById("allbands").href = "http://localhost:10349/AllBands.aspx?cart=";
                        document.getElementById("about").href = "http://localhost:10349/About.aspx?cart=" ;
                        document.getElementById("contact").href = "http://localhost:10349/Contact.aspx?cart=";
                        document.getElementById("sign").href = "http://localhost:10349/SignInOptions.aspx?cart="; 
                    }
                }
                


                </script>

</asp:Content>
