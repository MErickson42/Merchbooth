<%@ Page Title="All Bands" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllBands.aspx.cs" Inherits="Merchbooth.AllBands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
    <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div style="margin-top:200px;"></div>
    <div style="z-index:9999;">
        <h1>All Bands</h1>
        <h2>Below is a list of all bands that currently have merchandice for sale</h2>
        <asp:Literal ID="ltrBands" runat="server"></asp:Literal>
    </div>
</asp:Content>
