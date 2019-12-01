<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SalesByProduct.aspx.cs" Inherits="Merchbooth.Admin.Reports.SalesByProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true"></asp:ScriptManager>

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
                    <h1 class="reportTitle">Sales by Product</h1>
                </div>
            </div>
           

            <div class="row">
                   

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <asp:Label ID="lblSalesByTypes" runat="server" Text=""> </asp:Label>
                    
                    </div>
            </div>

            <div class="row">
                   
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <asp:Label ID="lblProductSalesByType" runat="server" Text=""> </asp:Label>
                    

                    </div>
            </div>
            

        </div>

        <div class="col-lg-1 col-sm-1">
                <asp:HiddenField ID="hdnSelecteType" value="" runat="server"/>
        </div>

    </div>

    <script type="text/javascript">

            function radioOnClick(radioButtonId,strTypeValue) {
                //document.getElementById(radioButtonId).checked = true;
                document.getElementById("<%= hdnSelecteType.ClientID%>").value = strTypeValue;
                __doPostBack('hfStartDate');
            }
    </script>


</asp:Content>
