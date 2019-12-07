<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Customer/Purchase.Master" AutoEventWireup="true" CodeBehind="CheckoutMain.aspx.cs" Inherits="Merchbooth.CheckoutMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderImage" runat="server">

    <div class="headerImage">
         
   </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <style type="text/css">
                .buttonClass
                {
                    padding: 5px 10px;
                    text-decoration: none;
                    /*border: solid 3px #cf6c0a;*/
                    background-color: #ed7f11;
                    z-index:50;
                    position:fixed;
                    right:0px;
                    top:185px;
                    color:#262422;
                    font-size: 20px;
                    border-radius:4px 4px 4px 4px;
                }
                .buttonClass:hover
                {
                    transition-duration:300ms;
                    font-size: 22px;
                    border-radius:30px;
                    padding:20px,10px;

                }
            </style>
    <asp:Literal  ID="ltrCartMain" runat="server">

    </asp:Literal>
    
    <asp:LinkButton ID="LnkButtion" CssClass="buttonClass" runat="server" Text="Purchase" OnClick="ButtonCustomerPurchase_Click"/>

    <asp:HiddenField ID="hdnPutchaseItemsVariable" value="" runat="server" />


</asp:Content>