<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BandSignIn.aspx.cs" Inherits="Merchbooth.SignIn" %>

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
        <asp:Button ID="btnBandSignIn" runat="server" CssClass="btn btn-primary" Text ="Sign In" OnClick="btnSigmInBand_Click"/> &nbsp; 
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false" />
    
    </div>

</asp:Content>
