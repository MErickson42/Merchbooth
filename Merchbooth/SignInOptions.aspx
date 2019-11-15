<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignInOptions.aspx.cs" Inherits="Merchbooth.SignInOptions" %>


<asp:Content ID="HeaderImage1" ContentPlaceHolderID="HeaderImage" runat="server">
  
    <div class="headerImage">
         
   </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:200px"></div>
        <asp:Image ID="Image1" runat="server" ImageAlign="Right" Width="750" Height="350" ImageUrl="~/Images/download2.jpg" BorderStyle="Groove" />

    <h2>Sign IN:</h2>
    <br /><br />
    <a runat="server" href="~/BandSignIn">Sign In as Band</a><br /><br />
    <a runat="server" href="~/CustomerSignIn">Sign In as Customer</a><br />
    <br /><br />
    <h2>Sign UP:</h2>
    <br /><br />
    <a runat="server" href="~/BandSignUp">Sign up as Band</a><br /><br />
    <a runat="server" href="~/CustomerSignUp">Sign up as Customer</a><br /><br />

</asp:Content>
