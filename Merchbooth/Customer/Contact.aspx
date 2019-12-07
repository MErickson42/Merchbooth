<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Merchbooth.Customer.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
        <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomerContent" runat="server">

        <div style="margin-top:200px"></div>
    <h2><%:Title %> info:</h2>
    
    <div id ="body">
        <h3>Location:</h3>
            <address>
                Merchbooth<br />
                Cincinnati, Oh 45223<br />
            </address>
        <h3>Email:</h3>
            <address>
                <strong>Support:</strong>   <a href="mailto:merchboothAPP@gmail.com">merchboothAPP@gmail.com</a><br />
            </address>
       </div>

</asp:Content>
