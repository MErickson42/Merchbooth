<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Merchbooth.WebForm1" %>

<asp:Content ID="HeaderImage1" ContentPlaceHolderID="HeaderImage" runat="server">
<%--  
    <div class="headerImage">
         
   </div>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="form-wide">
        <div class="errormessage"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
        <h2 class="form-signin-heading"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Add a News Story"></asp:Literal></h2>
        <label for="ProductTitle">
            Band Name * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="ProductTitle" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="ProductTitle" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>

        <label for="Price">
            Email * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtPrice" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regPrice" ValidationExpression="^\d+(\.\d\d)?$" ControlToValidate="txtPrice" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtPrice" type="number" MaxLength="25" CssClass="form-control" runat="server" Text =""></asp:TextBox>

        <label for="Quantity">
            Phone * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtQuantity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^\d+$" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtQuantity" type="number" MaxLength="25" CssClass="form-control" runat="server" Text =""></asp:TextBox>
        



        
        <label for="Quantity">
            State * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtQuantity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="^\d+$" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtState" type="number" MaxLength="25" CssClass="form-control" runat="server" Text =""></asp:TextBox>
        
       
        
        <label for="City">
            City * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtQuantity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationExpression="^\d+$" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtCity" type="number" MaxLength="25" CssClass="form-control" runat="server" Text =""></asp:TextBox>
        
       

        
        <label for="Address">
            Address * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtQuantity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationExpression="^\d+$" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtAddress" type="number" MaxLength="25" CssClass="form-control" runat="server" Text =""></asp:TextBox>
        

        <label for="Zip">
            Zip * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtQuantity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ValidationExpression="^\d+$" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtZip" type="number" MaxLength="25" CssClass="form-control" runat="server" Text =""></asp:TextBox>
        
       
        <label for="Password">
            Password * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtQuantity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ValidationExpression="^\d+$" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    
        </label>
        <asp:TextBox ID="txtPassword" type="number" MaxLength="25" CssClass="form-control" runat="server" Text =""></asp:TextBox>
        



       
                                                                                    
        <label for="ProductImage">Service Image (JPG): </label>
        <asp:FileUpload ID="ProductImage" runat="server" />
        <label for="ProductImage">Header Image (JPG): </label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <label for="ProductImage">Background Image (JPG): </label>
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <strong>Current Image Path: <asp:Literal ID="ltrImagePath" runat="server"></asp:Literal></strong>
        <br /><br />
        
        <asp:Button ID="btnBandSignUp" runat="server" CssClass="btn btn-primary" Text ="Sign Up" OnClick="btnUpdateProduct_Click"/> &nbsp; 
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false" />
    
    </div>

</asp:Content>
