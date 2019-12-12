  <%@ Page Title="Band Sign In" Language="C#" MasterPageFile="~/Sign.Master" AutoEventWireup="true" CodeBehind="BandSignIn.aspx.cs" Inherits="Merchbooth.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />

    <div class="row">
        <div class="col-lg-1 col-sm-1"></div>
        <div class="col-lg-10 col-sm-10">
            <ul class="breadcrumb pull-right">
                <li><a href="/">Merchbooth</a></li>
                <li><a href="About.aspx">About</a></li>
                <li><a href="Contact.aspx">Contact</a></li>
            </ul>
        </div>
        <div class="col-lg-1 col-sm-1"></div>
    </div>
    
    <div class="form-wide">
                        <asp:Image ID="Image1" runat="server" ImageAlign="Right" Height="300" Width="550" ImageUrl="~/Images/download1.jpg" />

        <div class="errormessage"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
        <h2 class="form-signin-heading"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Band Sign In"></asp:Literal></h2>
        <label for="Email">
            Email 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <%--<asp:RegularExpressionValidator ID="regPrice" ValidationExpression="^\d+(\.\d\d)?$" ControlToValidate="txtPrice" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>--%>    
        </label>
        <asp:TextBox ID="txtEmail"  type="Email" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>

        <label for="Password">
            Password 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtPassword" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtPassword" Type="Password" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
            
        <br>
        <asp:Button ID="btnBandSignIn" runat="server" CssClass="btn btn-primary" Text ="Sign In" OnClick="btnSignInBand_Click"/> &nbsp; 
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false" />
        
        <%-- Added link to band sign up page to increase site mobility. EH 12/11/2019 --%>
        <br /><br /><a runat="server" href="~/BandSignUp">Sign up as Band</a><br /><br />

          <%-- Added link to customer sign in page to increase site mobility. EH 12/11/2019 --%>
        <a runat="server" href="~/CustomerSignIn">Sign in as Customer</a><br /><br />


    </div>
    
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
