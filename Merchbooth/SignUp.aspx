<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Merchbooth.WebForm1" %>

<asp:Content ID="HeaderImage1" ContentPlaceHolderID="HeaderImage" runat="server">
  
    <div class="headerImage">
         
   </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Sign-Up</h1>
        <p class="lead">Sign up Now!</p>

        
    <div class="names">
        <div> <p> UserName(email) </p> </div>
        <div> <input type="text" name="UserName" value=""><br>  </div>
    </div>

    
    <div class="names">
        <div> <p> Password </p> </div>
        <div>  <input type="text" name="Password" value=""><br> </div>
    </div>

        <div class="signup">

    </div>

      

        <asp:Button ID="Signup" class="btn btn-primary btn-lg" Text="Donkeyface" OnClick="Signup" />
     
        SIGN UP
      

    </div>

</asp:Content>
