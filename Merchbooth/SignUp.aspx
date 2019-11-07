<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Merchbooth.WebForm1" %>

<asp:Content ID="HeaderImage1" ContentPlaceHolderID="HeaderImage" runat="server">
  
    <div class="headerImage">
         
   </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Sign up Now!</h1>
        <%--<p class="lead">Sign up Now!</p>--%>

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

        <div class="signup">

    </div>

      <br>

        <asp:Button ID="Signup" class="btn btn-primary btn-lg" Text="Donkeyface" OnClick="Signup" />
     
        SIGN UP
      

    </div>

</asp:Content>
