<%@ Page Title="Sign In Options" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignInOptions.aspx.cs" Inherits="Merchbooth.SignInOptions" %>


<asp:Content ID="HeaderImage1" ContentPlaceHolderID="HeaderImage" runat="server">
  
    <div class="headerImage">
         
   </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />

    <div style="margin-top:200px"></div>
        <asp:Image ID="Image1" runat="server" ImageAlign="Right" Width="750" Height="350" ImageUrl="~/Images/download2.jpg" BorderStyle="Groove" />
        <asp:Literal  ID="ltrSignInOptions" runat="server"></asp:Literal>

<%--    <h2>Sign IN:</h2>
    <br /><br />
    <a id="signInBand" runat="server" href="~/BandSignIn">Sign In as Band</a><br /><br />
    <a id="signInCst" runat="server" href="~/CustomerSignIn">Sign In as Customer</a><br />
    <br /><br />
    <h2>Sign UP:</h2>
    <br /><br />
    <a id="signUpBand" runat="server" href="~/BandSignUp">Sign up as Band</a><br /><br />
    <a id="signUpCst" runat="server" href="~/CustomerSignUp">Sign up as Customer</a><br /><br />--%>


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

        $(window).bind("load", function() {

                  var cartString = document.getElementById("<%= hdnPassedCartItemsVariable.ClientID%>").value;

                document.getElementById("signInBand").href = "http://localhost:10349/BandSignIn.aspx?cart=" + cartString;
                document.getElementById("signInCst").href = "http://localhost:10349/CustomerSignIn.aspx?cart=" + cartString;
                document.getElementById("signUpBand").href = "http://localhost:10349/BandSignUp.aspx?cart=" + cartString;
                document.getElementById("signUpCst").href = "http://localhost:10349/CustomerSignUp.aspx?cart=" + cartString;
        });


         
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
