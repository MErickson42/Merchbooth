<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Customer/Purchase.Master" AutoEventWireup="true" CodeBehind="CheckoutMain.aspx.cs" Inherits="Merchbooth.CheckoutMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="server">

    <div class="headerImage">
         
   </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <style type="text/css">
                .buttonClass
                {
                    /*padding: 5px 10px;*/
                    text-decoration: none;
                    /*border: solid 3px #cf6c0a;*/
                    background-color: #ed7f11;
                    z-index:50;
                    position:fixed;
                    left:65vw;
                    top:190px;
                    color:#262422;
                    font-size: 45px;
                    padding:20px 10px;
                    border-radius:4px 4px 4px 4px;
                }
                .buttonClass:hover
                {
                    /*transition-duration:300ms;
                    font-size: 22px;
                    border-radius:30px;
                    padding:20px,10px;*/

                }
            </style>
    <asp:Literal  ID="ltrCartMain" runat="server">

    </asp:Literal>
        <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />

    <asp:LinkButton ID="LnkButtion" CssClass="buttonClass" runat="server" Text="Purchase" OnClick="ButtonCustomerPurchase_Click"/>

    <asp:HiddenField ID="hdnPutchaseItemsVariable" value="" runat="server" />


         <script type="text/javascript">

             //var intTotalCount = 0;

             window.onload = function () {

                 var cartString = document.getElementById("<%= hdnPassedCartItemsVariable.ClientID%>").value;
                 var intStartIndex = 0;
                 var intEndIndex = 0;
                 var intEndIndex = 0;

                 if (cartString.indexOf("{") != -1) {
                     document.getElementById("home").href = "http://localhost:10349/Customer/Default.aspx?cart=" + cartString;
                     document.getElementById("allbands").href = "http://localhost:10349/Customer/AllBands.aspx?cart=" + cartString;
                     //document.getElementById("about").href = "http://localhost:10349/Customer/About.aspx?cart=" + cartString;
                     //document.getElementById("contact").href = "http://localhost:10349/Customer/Contact.aspx?cart=" + cartString;
                     document.getElementById("account").href = "http://localhost:10349/Customer/Account.aspx?cart=" + cartString;



                     //while (cartString.indexOf("{") != -1) {
                     //    intStartIndex = cartString.indexOf("Amount");
                     //    intEndIndex = cartString.indexOf("}", intStartIndex);
                     //    intAmount = 1 * (cartString.substring(intStartIndex + 7, intEndIndex));

                     //    intTotalCount += 1 * intAmount;

                     //    cartString = cartString.substring(intEndIndex);

                     //}

                     //document.getElementById("cartCountCustomer").innerHTML = intTotalCount;

                 }
             }

              //  function ClearCart()
               // {

                    //if (intTotalCount > 0)
                    //{
                        //intTotalCount = 0;  
                        //document.getElementById("cartCountCustomer").innerHTML = "";
                        //document.getElementById("< %= hdnPassedCartItemsVariable.ClientID%>").value = "";
                          
                       // document.getElementById("home").href="http://localhost:10349/Customer/Default"; 
                        //document.getElementById("allbands").href="http://localhost:10349/Customer/AllBands"; 
                        //document.getElementById("about").href="http://localhost:10349/Customer/About"; 
                        //document.getElementById("contact").href="http://localhost:10349/Customer/Contact"; 
                        //document.getElementById("account").href="http://localhost:10349/Customer/Account"; 
                //    }
                //}
             

             

    </script>

</asp:Content>