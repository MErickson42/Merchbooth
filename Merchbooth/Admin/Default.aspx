<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Merchbooth.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-1 col-sm-1"></div>
        <div class="col-lg-10 col-sm-10">
            <ul class="breadcrumb pull-right">
                <li class= "active">Home</li>
                <li><a href="/Admin/Products/">Products</a></li>
                <li><a href="/Admin/BoothSalePoint/">Booth</a></li>
                <li><a href="/Admin/ModifyAccount/">Account</a></li>
                <li><a href="/Admin/Logout.aspx" >Logout</a></li>
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
                    <h1 class="titleAdminDefualt">Manager</h1>
                </div>
            </div>
           
            <div class="row">
                <div class="col-lg-12 col-sm-12" style="text-align: center;">
                    <asp:Label ID="lblMessage" runat="server" CssClass="errormessage" Text="">

                    </asp:Label>

                </div>

            </div>
            
            <div class="row">
                <div class="col-lg-3 col-md-5 col-sm-6 col-xs-12">         
                   <asp:Label ID="lblLowInventory" runat="server" Text=""></asp:Label>
                    <%-- *added user entered low threshhold //EH 11.29.19 --%>
                    <asp:Label ID="lbllowInventoryThreshold" runat="server" Text="Low Inventory Threshold:"></asp:Label>
                    <asp:TextBox ID="lowInventoryThreshold" type="text" MaxLength="25" CssClass="form-control" runat="server" Text="50" Width="80%"></asp:TextBox>                
                </div>
                <div class="col-lg-3 col-md-5 col-sm-6 col-xs-12">
                    <asp:Label ID="lblSales" runat="server" Text="Reports"></asp:Label>
                </div>
                <div class="col-lg-3 col-md-5 col-sm-6 col-xs-12">
                    <asp:Label ID="lblReports" runat="server" Text="Sales"></asp:Label>
                </div>
                <div class="col-lg-3 col-md-5 col-sm-6 col-xs-12">
                    <asp:Label ID="lblUpcoming" runat="server" Text=""></asp:Label>
                </div>
            </div>



        </div>
        

        <div class="col-lg-1 col-sm-1"></div>
    </div>

        <script type="text/javascript">
        var deleteLinks = document.querySelectorAll('.delete');

        for (var i = 0; i < deleteLinks.length; i++) {
            deleteLinks[i].addEventListener('click', function (event) {
                event.preventDefault();

                var choice = confirm(this.getAttribute('data-confirm'));

                if (choice) {
                    window.location.href = this.getAttribute('href');
                }
            });
        }
    </script>
</asp:Content>
