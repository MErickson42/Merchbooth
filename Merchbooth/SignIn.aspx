<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Merchbooth.SignIn" %>

<asp:Content ID="HeaderImage1" ContentPlaceHolderID="HeaderImage" runat="server">
  
    <div class="headerImage">
         
   </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Sign-In</h1>
        <%--<p class="lead">Sign in</p>--%>

        <br>
    <div class="names password">
        <div> <p> User Name (email) </p> </div>
        <div> <input type="text" name="UserName" value="">  </div>
    </div>

    <br>
    
    <div class="names password">
        <div> <p> Password </p> </div>
        <div>  <input type="text" name="Password" value=""> </div>
    </div>

        <div class="signin">

    </div>

      
        <br>

        <asp:Button ID="signin" class="btn btn-primary btn-lg" Text="Donkeyface" OnClick="Signin" />
     
        SIGN IN
      

    </div>

</asp:Content>
