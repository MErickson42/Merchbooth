<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Merchbooth.Contact" %>



<asp:Content ID="HeaderImage1" ContentPlaceHolderID="HeaderImage" runat="server">
  
    <div class="headerImage">
         
   </div>

</asp:Content>



<asp:Content ID="contactFooter" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:200px"></div>
    <h2><%:Title %> info:</h2>
    
    <div id ="body">
        <h3>Location:</h3>
            <address>
                Merchbooth<br />
                Cincinnati, Oh 45223<br />
            </address>
        <h3>Email:</h3>
            <address>
                <strong>Support:</strong>   <a href="mailto:merchboothAPP@gmail.com">merchboothAPP@gmail.com</a><br />
            </address>
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
                          
                    document.getElementById("home").href = "http://localhost:10349/Default.aspx?cart=";
                    document.getElementById("allbands").href = "http://localhost:10349/AllBands.aspx?cart=";
                    document.getElementById("about").href = "http://localhost:10349/About.aspx?cart=";
                    document.getElementById("contact").href = "http://localhost:10349/Contact.aspx?cart=";
                    document.getElementById("sign").href = "http://localhost:10349/SignInOptions.aspx?cart=";
                }
            }


       



    </script>
</asp:Content>
