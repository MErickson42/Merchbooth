<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SalesByCustomer.aspx.cs" Inherits="Merchbooth.Admin.Reports.SaleByCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="row">
        <div class="col-lg-1 col-sm-1"></div>
        <div class="col-lg-10 col-sm-10">
            <ul class="breadcrumb pull-right">
                <li><a href="/Admin/Default/">Home</a></li>
                <li><a href="/Admin/Products/">Products</a></li>
                <li><a href="/Admin/BoothSalePoint/">Booth</a></li>
                <li><a href="/Admin/ModifyAccount/">Account</a></li>
            </ul>
        </div>
        <div class="col-lg-1 col-sm-1"></div>
    </div>


     <div class="row">
        
        
        
        <div class="col-lg-1 col-sm-1">
        </div>
        

        <div class="col-lg-10 col-sm-10">
            
            <div class="row">
                <div class="col-lg-12 col-sm-12">
                    <h1 class="reportTitle">Sales by Customer</h1>
                </div>
            </div>
           

            <div class="row">

                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                    <asp:Label ID="lblSalesByCustomer" runat="server" Text=""></asp:Label>
                </div>
            
            </div>
            

        </div>
        

        <div class="col-lg-1 col-sm-1"></div>
    </div>
</asp:Content>
