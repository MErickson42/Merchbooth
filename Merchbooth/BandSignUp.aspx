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
        <!-- Added image to make it pretty  -->
                <h1 style=" color:blue">Welcome to the music's world </h1>

        <asp:Image ID="Image1" runat="server" ImageAlign="Right" Height="300" Width="650" ImageUrl="~/Images/download3.jpg" BorderStyle="Groove" />
        <h2 class="form-signin-heading"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Band Sign Up"></asp:Literal></h2>
        <label for="BandName">
            Band Name * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtBandName" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtBandName" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>

        <label for="Email">
            Email * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <%--<asp:RegularExpressionValidator ID="regPrice" ValidationExpression="^\d+(\.\d\d)?$" ControlToValidate="txtPrice" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>--%>    
        </label>
        <asp:TextBox ID="txtEmail"  type="Email" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
 
        <label for="Password">
            Password * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtPassword" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtPassword" Type="Password" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>

        <label for="Phone">
            Phone * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtPhone" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <%--from "Ehsan" from:stackoverflow.com/questions/18585613/how-do-you-validate-phone-number-in-asp-net  --%>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"  ControlToValidate="txtPhone" runat="server" ErrorMessage="Enter A Valid Phone Number Only"></asp:RegularExpressionValidator>--%>    
        </label>
        <asp:TextBox ID="txtPhone" type="Phone" MaxLength="25" CssClass="form-control" runat="server"></asp:TextBox>
        
        <label for="State">
            State * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtState" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtState" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
              
        <label for="City">
            City*  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtCity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtCity" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
                  
        <label for="Address">
            Address* 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtAddress" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
       <%--            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ValidationExpression="^\d+$" ControlToValidate="txtZip" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    --%>
            </label>
        <asp:TextBox ID="txtAddress" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
        

        <label for="Zip">
            Zip* 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtZip" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

        </label>
        <asp:TextBox ID="txtZip" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
     
                                                                                                    
        <label for="BandHeaderImage">Header Image (JPG): </label>
        <asp:FileUpload ID="BandHeaderImage" runat="server" />
        <strong>Current Image Path: <asp:Literal ID="ltrHeaderImagePath" runat="server"></asp:Literal></strong>
        <br /><br />

        <label for="BandBackgroundImage">Background Image (JPG): </label>
        <asp:FileUpload ID="BandBackgroundImage" runat="server" />
        <strong>Current Image Path: <asp:Literal ID="ltrBackgroundImagePath" runat="server"></asp:Literal></strong>
        <br /><br />
        
        <asp:Button ID="btnBandSignUp" runat="server" CssClass="btn btn-primary" Text ="Sign Up" OnClick="btnSigmUpBand_Click"/> &nbsp; 
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false" />
    
    </div>

</asp:Content>
