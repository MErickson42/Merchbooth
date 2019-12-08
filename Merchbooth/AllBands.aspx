<%@ Page Title="All Bands" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllBands.aspx.cs" Inherits="Merchbooth.AllBands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
    <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div style="margin-top:200px;"></div>
    <div style="z-index:9999;">
        <h1>All Bands</h1>
        <h2>Below is a list of all bands that currently have merchandice for sale</h2>
        <asp:Literal ID="ltrBands" runat="server"></asp:Literal>
    </div>

            <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />

    <script type="text/javascript">

        var intTotalCount = 0;

        window.onload = function () {

            var cartString = document.getElementById("<%= hdnPassedCartItemsVariable.ClientID%>").value;
            var intStartIndex = 0;
            var intEndIndex = 0;
            var intEndIndex = 0;

            if (cartString.indexOf("{") != -1) {
                document.getElementById("home").href = "http://localhost:10349/Default.aspx?cart=" + cartString;
                document.getElementById("allbands").href = "http://localhost:10349/AllBands.aspx?cart=" + cartString;
                document.getElementById("about").href = "http://localhost:10349/About.aspx?cart=" + cartString;
                document.getElementById("contact").href = "http://localhost:10349/Contact.aspx?cart=" + cartString;
                document.getElementById("sign").href = "http://localhost:10349/SignInOptions.aspx?cart=" + cartString;



                while (cartString.indexOf("{") != -1) {
                    intStartIndex = cartString.indexOf("Amount");
                    intEndIndex = cartString.indexOf("}", intStartIndex);
                    intAmount = 1 * (cartString.substring(intStartIndex + 7, intEndIndex));

                    intTotalCount += 1 * intAmount;

                    cartString = cartString.substring(intEndIndex);

                }

                document.getElementById("cartCount").innerHTML = intTotalCount;

            }
        }

        function ClearCart()
        {

            if (intTotalCount > 0)
            {
                intTotalCount = 0;  
                document.getElementById("cartCount").innerHTML = "";
                document.getElementById("<%= hdnPassedCartItemsVariable.ClientID%>").value = "";
                          
                document.getElementById("home").href = "http://localhost:10349/Default.aspx?cart=" ;
                document.getElementById("allbands").href = "http://localhost:10349/AllBands.aspx?cart=";
                document.getElementById("about").href = "http://localhost:10349/About.aspx?cart=" ;
                document.getElementById("contact").href = "http://localhost:10349/Contact.aspx?cart=";
                document.getElementById("sign").href = "http://localhost:10349/SignInOptions.aspx?cart=";
            }
        }
       



    </script>
</asp:Content>
