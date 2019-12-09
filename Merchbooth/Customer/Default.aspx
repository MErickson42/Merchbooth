<%@ Page Title="Customer Home" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Merchbooth.Customer.Default" %>
<asp:Content ID="HeaderImage1" ContentPlaceHolderID="HeaderImage" runat="server">
  
    <div class="headerImage">
         
   </div>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomerContent" runat="server">
    <%--<div style="margin-top:200px"></div>--%>
    <asp:Literal  ID="ltrProducts" runat="server"></asp:Literal>
   
    <%--Added ben 11/30--%>
    <asp:HiddenField ID="hdnCartItemsVariable" value="" runat="server" />
    <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />
    <asp:LinkButton ID="LnkButtion" CssClass="buttonClass" runat="server" Text="Checkout" OnClick="checkoutMain_Click"/>


    <style type="text/css">
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


                document.getElementById("cartCountCustomer").innerHTML = intTotalCount;

                //document.getElementById("testing").innerHTML =  Products;

                document.getElementById("<%= hdnCartItemsVariable.ClientID%>").value = ObjToString(Products);

                 cartString =  ObjToString(Products);                        
                document.getElementById("home").href="http://localhost:10349/Customer/Default.aspx?cart=" + cartString; 
                document.getElementById("allbands").href="http://localhost:10349/Customer/AllBands.aspx?cart="+cartString; 
                document.getElementById("about").href="http://localhost:10349/Customer/About.aspx?cart="+cartString; 
                document.getElementById("contact").href="http://localhost:10349/Customer/Contact.aspx?cart="+cartString; 
                document.getElementById("account").href="http://localhost:10349/Customer/Account.aspx?cart="+cartString; 


                    var intIndex = 0;
                    var strBandID = 0;
                    for (intIndex = 1; intIndex <= 20; intIndex += 1)
                    {
                        strBandID = "band" + intIndex;
                        var linkToBand = document.getElementById(strBandID);

                        if (linkToBand)
                        {
                            linkToBand.href = "/Customer/OneBandProducts/?ck=" + intIndex +"&cart=" +cartString;
                        }
                    }
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
                        document.getElementById("cartCountCustomer").innerHTML = intTotalCount;

                        document.getElementById("<%= hdnCartItemsVariable.ClientID%>").value = ObjToString(Products);
                       
                        document.getElementById("home").href="http://localhost:10349/Customer/Default.aspx?cart=" + cartStringB; 
                        document.getElementById("allbands").href="http://localhost:10349/Customer/AllBands.aspx?cart="+cartStringB; 
                        document.getElementById("about").href="http://localhost:10349/Customer/About.aspx?cart="+cartStringB; 
                        document.getElementById("contact").href="http://localhost:10349/Customer/Contact.aspx?cart="+cartStringB; 
                        document.getElementById("account").href="http://localhost:10349/Customer/Account.aspx?cart="+cartStringB; 

                        var intIndex = 0;
                        var strBandID = 0;
                        for (intIndex = 1; intIndex <= 20; intIndex += 1)
                        {
                            strBandID = "band" + intIndex;
                            var linkToBand = document.getElementById(strBandID);

                            if (linkToBand)
                            {
                            linkToBand.href = "/Customer/OneBandProducts/?ck=" + intIndex +"&cart=" +cartStringB;
                            }
                        }
                    }
                }

                function ClearCart()
                {

                    if (intTotalCount > 0)
                    {
                        for (var member in Products) delete Products[member];
                        intTotalCount = 0;  
                        document.getElementById("cartCountCustomer").innerHTML = "";
                        document.getElementById("<%= hdnCartItemsVariable.ClientID%>").value = "";
                          
                        document.getElementById("home").href="http://localhost:10349/Customer/Default"; 
                        document.getElementById("allbands").href="http://localhost:10349/Customer/AllBands"; 
                        document.getElementById("about").href="http://localhost:10349/Customer/About"; 
                        document.getElementById("contact").href="http://localhost:10349/Customer/Contact"; 
                        document.getElementById("account").href = "http://localhost:10349/Customer/Account";


                        var intIndex = 0;
                        var strBandID = 0;
                        for (intIndex = 1; intIndex <= 20; intIndex += 1)
                        {
                            strBandID = "band" + intIndex;
                            var linkToBand = document.getElementById(strBandID);

                            if (linkToBand)
                            {
                                linkToBand.href = "/Customer/OneBandProducts/?ck=" + intIndex;
                            }
                        }
                    }
                }
                


                </script>


</asp:Content>
