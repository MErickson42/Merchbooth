zz<%@ Page Title="Band Product" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="OneBandProducts.aspx.cs" Inherits="Merchbooth.Customer.OneBandProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
    <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomerContent" runat="server">
        <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />

        <div class="row" style="z-index:100">
                <div class="col-md-12">
                    <h1><asp:Literal ID="ltrBandName" runat="server"></asp:Literal></h1>
                </div>
            </div>
            <asp:HiddenField ID="hdnCartItemsVariable" value="" runat="server" />
        <asp:HiddenField ID="HiddenField1" value="" runat="server" />
            <asp:LinkButton ID="LnkButtion" CssClass="buttonClass" runat="server" Text="Checkout" OnClick="checkout1_Click"/>

    <asp:Literal ID="ltrOneBandProducts" runat="server"></asp:Literal>

        <style type="text/css">
 
                .buttonClass
                {

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

                document.getElementById("cartCountCustomer").innerHTML = intTotalCount;
                document.getElementById("<%= hdnCartItemsVariable.ClientID%>").value = ObjToString(Products);

                 cartString =  ObjToString(Products);                        

                     document.getElementById("home").href = "http://localhost:10349/Customer/Default.aspx?cart=" + cartString;
                     document.getElementById("allbands").href = "http://localhost:10349/Customer/AllBands.aspx?cart=" + cartString;
                     document.getElementById("about").href = "http://localhost:10349/Customer/About.aspx?cart=" + cartString;
                     document.getElementById("contact").href = "http://localhost:10349/Customer/Contact.aspx?cart=" + cartString;
                     document.getElementById("account").href = "http://localhost:10349/Customer/Account.aspx?cart=" + cartString;
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

                         document.getElementById("home").href = "http://localhost:10349/Customer/Default.aspx?cart=" + cartStringB;
                         document.getElementById("allbands").href = "http://localhost:10349/Customer/AllBands.aspx?cart=" + cartStringB;
                         document.getElementById("about").href = "http://localhost:10349/Customer/About.aspx?cart=" + cartStringB;
                         document.getElementById("contact").href = "http://localhost:10349/Customer/Contact.aspx?cart=" + cartStringB;
                         document.getElementById("account").href = "http://localhost:10349/Customer/Account.aspx?cart=" + cartStringB;
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
                        document.getElementById("account").href="http://localhost:10349/Customer/Account"; 
                    }
                }
                


                </script>
</asp:Content>
