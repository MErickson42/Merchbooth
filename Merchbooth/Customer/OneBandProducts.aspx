<%@ Page Title="Band Product" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="OneBandProducts.aspx.cs" Inherits="Merchbooth.Customer.OneBandProducts" %>
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

    <asp:Literal ID="ltrOneBandProducts" runat="server"></asp:Literal>



         <script type="text/javascript">

             var intTotalCount = 0;

             window.onload = function () {

                 var cartString = document.getElementById("<%= hdnPassedCartItemsVariable.ClientID%>").value;
                 var intStartIndex = 0;
                 var intEndIndex = 0;
                 var intEndIndex = 0;

                 if (cartString.indexOf("{") != -1) {
                     document.getElementById("home").href = "http://localhost:10349/Customer/Default.aspx?cart=" + cartString;
                     document.getElementById("allbands").href = "http://localhost:10349/Customer/AllBands.aspx?cart=" + cartString;
                     document.getElementById("about").href = "http://localhost:10349/Customer/About.aspx?cart=" + cartString;
                     document.getElementById("contact").href = "http://localhost:10349/Customer/Contact.aspx?cart=" + cartString;
                     document.getElementById("account").href = "http://localhost:10349/Customer/Account.aspx?cart=" + cartString;



                     while (cartString.indexOf("{") != -1) {
                         intStartIndex = cartString.indexOf("Amount");
                         intEndIndex = cartString.indexOf("}", intStartIndex);
                         intAmount = 1 * (cartString.substring(intStartIndex + 7, intEndIndex));

                         intTotalCount += 1 * intAmount;

                         cartString = cartString.substring(intEndIndex);

                     }

                     document.getElementById("cartCountCustomer").innerHTML = intTotalCount;

                 }
  }
                function ClearCart()
                {

                    if (intTotalCount > 0)
                    {
                        intTotalCount = 0;  
                        document.getElementById("cartCountCustomer").innerHTML = "";
                        document.getElementById("<%= hdnPassedCartItemsVariable.ClientID%>").value = "";
                          
                        document.getElementById("home").href="http://localhost:10349/Customer/Default"; 
                        document.getElementById("allbands").href="http://localhost:10349/Customer/AllBands"; 
                        document.getElementById("about").href="http://localhost:10349/Customer/About"; 
                        document.getElementById("contact").href="http://localhost:10349/Customer/Contact"; 
                        document.getElementById("account").href="http://localhost:10349/Customer/Account"; 
                    }
                }
           



    </script>
</asp:Content>
