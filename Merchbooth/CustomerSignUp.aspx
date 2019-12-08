<%@ Page Title="Customer Sign Up" Language="C#" MasterPageFile="~/Sign.Master" AutoEventWireup="true" CodeBehind="CustomerSignUp.aspx.cs" Inherits="Merchbooth.CustomerSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
        <div class="errormessage"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
        <!-- Added image to make it pretty  -->
                <h1 style=" color:blue">Welcome to the music's world </h1>

        <asp:Image ID="Image1" runat="server" ImageAlign="Right" Height="300" Width="650" ImageUrl="~/Images/download3.jpg" BorderStyle="Groove" />
        <h2 class="form-signin-heading"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Customer Sign Up"></asp:Literal></h2>
        <label for="FirstName">
            First Name * 
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Please enter your first name" SetFocusOnError="True" ControlToValidate="txtFirstName" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

        </label>
        <asp:TextBox ID="txtFirstName" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>

        <label for="LastName">
            Last Name * 
            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Please enter your last name" SetFocusOnError="True" ControlToValidate="txtLastName" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtLastName" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>

        <label for="Email">
            Email * 
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please enter an email address" SetFocusOnError="True" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regEmail" runat="server" ErrorMessage="Please enter a valid email address" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="True" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </label>
        <asp:TextBox ID="txtEmail"  type="Email" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
 
        <label for="Password">
            Password * 
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please enter a password" SetFocusOnError="True" ControlToValidate="txtPassword" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtPassword" Type="Password" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>

        <label for="Phone">
            Phone * 
            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ErrorMessage="Please enter a phone number" SetFocusOnError="True" ControlToValidate="txtPhone" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regPhoneNumber" runat="server" ErrorMessage="Please enter a 10 digit phone number" SetFocusOnError="True" ControlToValidate="txtPhone" Display="Dynamic" Font-Bold="True" ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$"></asp:RegularExpressionValidator> 
        </label>
        <asp:TextBox ID="txtPhone" type="Phone" MaxLength="25" CssClass="form-control" runat="server"></asp:TextBox>
        
        <label for="State">
            <br />

            <%--I added a dropdown list to state and connected to the database   --%>

            State * 
            <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Please select a state from the drop down list" SetFocusOnError="True" ControlToValidate="ddlState" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>

        <asp:DropDownList ID="ddlState" runat="server" DataSourceID="SqlDataSource1" DataTextField="strStateName" DataValueField="intStateID" AutoPostBack="False" AppendDataBoundItems="True" Height="20px" Width="200px">
                	        <asp:ListItem Value=""> Select your State</asp:ListItem>
       </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CPDM_EricksonMConnectionString %>" SelectCommand="SELECT [intStateID], [strStateName] FROM [TStates]"></asp:SqlDataSource>
        <br />
        <br />


              
        <label for="City">
            City*  
            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Please enter your city name" SetFocusOnError="True" ControlToValidate="txtCity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtCity" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
                  
        <label for="Address">
            Address* 
            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please enter your address" SetFocusOnError="True" ControlToValidate="txtAddress" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
       
            </label>
        <asp:TextBox ID="txtAddress" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
        

        <label for="Zip">
            Zip* 
            <asp:RequiredFieldValidator ID="rfvZip" runat="server" ErrorMessage="Please enter your zip code" SetFocusOnError="True" ControlToValidate="txtZip" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regZip" ValidationExpression="\d{5}-?(\d{4})?$" SetFocusOnError="True" ControlToValidate="txtZip" Display="Dynamic" runat="server"  Font-Bold="True" ForeColor="Red" ErrorMessage="Please enter 5 or 9 digit zip code"></asp:RegularExpressionValidator>
        </label>
        <asp:TextBox ID="txtZip"  MaxLength="10" CssClass="form-control" runat="server" Text =""></asp:TextBox>
        
          
        <label for="Gender">
            <br />
        <br />

<%--I added a dropdown list to gender and connected to the database   --%>
            
            Gender* 
            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ErrorMessage="Please select your gender from the drop down list" SetFocusOnError="True" ControlToValidate="ddlGender" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

        <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="False" DataSourceID="SqlDataSource2" DataTextField="strGender" DataValueField="intGenderID" AppendDataBoundItems="True" Height="20px" Width="200">
       
                            	        <asp:ListItem Value=""> Select your Gender</asp:ListItem>

            
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CPDM_EricksonMConnectionString %>" SelectCommand="SELECT [intGenderID], [strGender] FROM [TGenders]" OnSelecting="SqlDataSource2_Selecting"></asp:SqlDataSource>

        </label>
        
        <br /><br />
        
        <br />
        <br />
        
        <asp:Button ID="btnCustomerSignUp" runat="server" Text="Sign Up" CssClass="btn btn-primary" OnClick="btnSignUpCustomer_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="Cancel" runat="server" Text="Cancel" CausesValidation="False" CssClass="btn btn-primary" OnClick="btnCancel_Click" />
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
