<%@ Page Title="Band Sign Up" Language="C#" MasterPageFile="~/Sign.Master" AutoEventWireup="true" CodeBehind="BandSignUp.aspx.cs" Inherits="Merchbooth.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
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

        <h2 class="form-signin-heading"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Band Sign Up"></asp:Literal></h2>
        <label for="BandName">
            Band Name * 
            <asp:RequiredFieldValidator ID="rfvBandName" runat="server" ErrorMessage="Please enter your Band's name" SetFocusOnError="True" ControlToValidate="txtBandName" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtBandName" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>

        <label for="Email">
            Email * 
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please enter your Band's email address" SetFocusOnError="True" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
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
            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ErrorMessage="Please enter a phone number for your Band" SetFocusOnError="True" ControlToValidate="txtPhone" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ID="regPhoneNumber" runat="server" ErrorMessage="Please enter a 10 digit phone number" SetFocusOnError="True" ControlToValidate="txtPhone" Display="Dynamic" Font-Bold="True" ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$"></asp:RegularExpressionValidator> 
        </label>
        <asp:TextBox ID="txtPhone" type="Phone" MaxLength="25" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        <label for="State">
            State * 
            <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Please select a state from the drop down list" SetFocusOnError="True" ControlToValidate="ddlState" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:DropDownList ID="ddlState" runat="server" DataSourceID="SqlDataSource1" DataTextField="strStateName" DataValueField="intStateID" AutoPostBack="False" AppendDataBoundItems="True" Height="20px" Width="200px">
                	        <asp:ListItem Value=""> Select your State</asp:ListItem>
       </asp:DropDownList>
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CPDM_EricksonMConnectionString %>" SelectCommand="SELECT [intStateID], [strStateName] FROM [TStates]"></asp:SqlDataSource>
              
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
        <asp:TextBox ID="txtZip" MaxLength="10" CssClass="form-control" runat="server" Text =""></asp:TextBox>
     
                                                                                                    
        <label for="BandHeaderImage">Header Image (JPG): </label>
        <asp:FileUpload ID="BandHeaderImage" runat="server" />
        <strong>Current Image Path: <asp:Literal ID="ltrHeaderImagePath" runat="server"></asp:Literal></strong>
        <br /><br />

        <label for="BandBackgroundImage">Background Image (JPG): </label>
        <asp:FileUpload ID="BandBackgroundImage" runat="server" />
        <strong>Current Image Path: <asp:Literal ID="ltrBackgroundImagePath" runat="server"></asp:Literal></strong>
        <br /><br />
        
        <asp:Button ID="btnBandSignUp" runat="server" CssClass="btn btn-primary" Text ="Sign Up" OnClick="btnSignUpBand_Click"/> &nbsp; 
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false" />
    
    </div>

</asp:Content>
