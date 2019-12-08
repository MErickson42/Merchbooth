<%@ Page Title="Modify Product" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ModifyProduct.aspx.cs" Inherits="Merchbooth.Admin.ModifyProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-1 col-sm-1"></div>
        <div class="col-lg-10 col-sm-10">
            <ul class="breadcrumb pull-right">
                <li><a href="/Admin/Default/">Home</a></li>
                <li><a href="/Admin/Products/">Products</a></li>
                <li><a href="/Admin/BoothSalePoint/">Booth</a></li>
                <li><a href="/Admin/ModifyAccount/">Account</a></li>
                <li><a href="/Admin/Logout.aspx" >Logout</a></li>
            </ul>
        </div>
        <div class="col-lg-1 col-sm-1"></div>
    </div>
    <div class="form-wide">
        <div class="errormessage"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
       
        <%-- changed the class to fit the other admin pages Ben 11_27--%>
        <%--<h2 class="form-signin-heading"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Add a News Story"></asp:Literal></h2>--%>
        <h2 class="titleAdminDefualt"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Add a News Story"></asp:Literal></h2>
       
        <label for="ProductTitle">
            Title * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="ProductTitle" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="ProductTitle" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>

        <%-- MDE - Added dropdownlist for  product base type --%>
        <label for="ProductBaseType">
            Product Base Type *
            <asp:RequiredFieldValidator ID="rfvProductBaseType" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="ddlProductBaseType" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:DropDownList ID="ddlProductBaseType" runat="server"></asp:DropDownList>
        <br />

        <%-- MDE - Added Product Color dropdown --%>
        <label for="ProductColor">
            Product Color *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlColor" runat="server" Display="Dynamic" Font-Bold="True" ForeColor="Red" ErrorMessage="[REQUIRED]"></asp:RequiredFieldValidator>
        </label>
        <asp:DropDownList ID="ddlColor" runat="server"></asp:DropDownList>
        <br />

        <%-- MDE added Size dropdown --%>
        <label for="ProductSize">
            Product Size *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlSize" runat="server" Display="Dynamic" Font-Bold="True" ForeColor="Red" ErrorMessage="[REQUIRED]"></asp:RequiredFieldValidator>
        </label>
        <asp:DropDownList ID="ddlSize" runat="server"></asp:DropDownList>
        <br />
         <%-- MDE added Gender dropdown --%>
        <label for="ProductGender">
            Product Gender*
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlGender" runat="server" Display="Dynamic" Font-Bold="True" ForeColor="Red" ErrorMessage="[REQUIRED]"></asp:RequiredFieldValidator>
        </label>
        <asp:DropDownList ID="ddlGender" runat="server"></asp:DropDownList>
        <br />

        <label for="Price">
            Price * 
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
