<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product-Details.aspx.cs" Inherits="Merchbooth.Products.Product_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
    <%--<asp:Image ID="imgBand" ImageUrl="/" runat="server" />--%>

    <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="z-index:9999">
                <div class="col-md-12">
                    <h1><asp:Literal ID="ltrBandName" runat="server"></asp:Literal></h1>
                </div>
            </div>

    <asp:Literal ID="ltrProducts" runat="server"></asp:Literal>

</asp:Content>
