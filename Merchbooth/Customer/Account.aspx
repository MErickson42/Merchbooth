<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Merchbooth.Customer.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
        <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomerContent" runat="server">

    <div class="form-wide">
        <div class="errormessage"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
       
        <h2 class="titleAdminDefualt"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Account Information"></asp:Literal></h2>
       

        <label for="FirstName">
            Band Name * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtFirstName" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtFirstName" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
        
        <label for="LastName">
            Band Name * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtLastName" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtLastName" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>


        <label for="Email">
            Email * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            <%--<asp:RegularExpressionValidator ID="regPrice" ValidationExpression="^\d+(\.\d\d)?$" ControlToValidate="txtPrice" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>--%>    
        </label>
        <asp:TextBox ID="txtEmail"  type="Email" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
 
        <label for="Password">
            Password * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtPassword" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtPassword" Type="Password" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>

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
        <asp:TextBox ID="txtState" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
              
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
        <asp:TextBox ID="txtAddress" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
        

        <label for="Zip">
            Zip* 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtZip" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

        </label>
        <asp:TextBox ID="txtZip" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
     
        <label for="Gender">
            Gender * 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtGender" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </label>
        <asp:TextBox ID="txtGender" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                             
        
        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text ="Update" OnClick="btnUpdateCustomerAccount_Click"/> &nbsp; 
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false" />
    </div>


</asp:Content>
