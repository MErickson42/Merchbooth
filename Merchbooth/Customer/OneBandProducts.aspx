<%@ Page Title="Band Product" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="OneBandProducts.aspx.cs" Inherits="Merchbooth.Customer.OneBandProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
    <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomerContent" runat="server">

        <div class="row" style="z-index:100">
                <div class="col-md-12">
                    <h1><asp:Literal ID="ltrBandName" runat="server"></asp:Literal></h1>
                </div>
            </div>

    <asp:Literal ID="ltrOneBandProducts" runat="server"></asp:Literal>

</asp:Content>
