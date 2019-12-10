<%@ Page Title="Sales By Customer" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SalesByCustomer.aspx.cs" Inherits="Merchbooth.Admin.Reports.SaleByCustomer" %>
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
        
        
            <div class="row">
                <div class="col-lg-12 col-sm-12">
                    <h1 class="reportTitle">Sales by Customer</h1>
                </div>
            </div>
           

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label ID="lblSalesByCustomer" runat="server" Text=""></asp:Label>
                </div>
            
            </div>


            <div class="row">
                   
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <asp:Label ID="lblSelectedCustomerPurchases" runat="server" Text=""> </asp:Label>
                    

                    </div>
            </div>

             <asp:HiddenField ID="hdnSelecteCustomer" value="" runat="server"/>


        </div>
        
        <script type="text/javascript">

            function radioOnClick(radioButtonId,intCustomerID) {
                //document.getElementById(radioButtonId).checked = true;
                document.getElementById("<%= hdnSelecteCustomer.ClientID%>").value = intCustomerID;
                postBack();
            }
            function postBack() {
                 __doPostBack('hfStartDate');
            }
        </script>


</asp:Content>
