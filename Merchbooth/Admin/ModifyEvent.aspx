<%@ Page Title="Modify Event" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ModifyEvent.aspx.cs" Inherits="Merchbooth.Admin.ModifyEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-lg-1 col-sm-1"></div>
        <div class="col-lg-10 col-sm-10">
            <ul class="breadcrumb pull-right">
                <li><a href="/Admin/Default/">Home</a></li>
                <li><a href="/Admin/Products/">Products</a></li>
                <li class= "active">Events</li>
                <li><a href="/Admin/BoothSalePoint/">Booth</a></li>
                <li><a href="/Admin/ModifyAccount/">Account</a></li>
                <li><a href="/Admin/Logout.aspx" >Logout</a></li>
            </ul>
        </div>
        <div class="col-lg-1 col-sm-1"></div>
    </div>
    <div class="form-wide">
        <div class="errormessage"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
       
        <h2 class="titleAdminDefualt"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Add a News Story"></asp:Literal></h2>
       
        <label for="EventTitle">
            Event Name* 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="EventTitle" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="EventTitle" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>

   

        <label for="Price">
             * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtPrice" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regPrice" ValidationExpression="^\d+(\.\d\d)?$" ControlToValidate="txtPrice" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtPrice" type="number" MaxLength="25" CssClass="form-control" runat="server"></asp:TextBox>

        <label for="Price to Band">
            Price to band* 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtPriceForBand" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="^\d+(\.\d\d)?$" ControlToValidate="txtPriceForBand" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtPriceForBand" type="number" MaxLength="25" CssClass="form-control" runat="server"></asp:TextBox>


        <label for="Quantity">
            Quantity * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtQuantity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^\d+$" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtQuantity" type="number" MaxLength="25" CssClass="form-control" runat="server"></asp:TextBox>
        
       
                                                                                    
        <label for="ProductImage">Service Image (JPG): </label>
        <asp:FileUpload ID="ProductImage" runat="server" />
        <strong>Current Image Path: <asp:Literal ID="ltrImagePath" runat="server"></asp:Literal></strong>
        <br /><br />
        <asp:Button ID="btnUpdateProduct" runat="server" CssClass="btn btn-primary" Text ="Update" OnClick="btnUpdateProduct_Click"/> &nbsp; 
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false" />
    </div>


</asp:Content>
