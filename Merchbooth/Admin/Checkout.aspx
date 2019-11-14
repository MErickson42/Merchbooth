<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Admin/AdminMasterB.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Merchbooth.Checkout" %>

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
    <asp:Literal  ID="ltrCart" runat="server">

    </asp:Literal>
    
    <asp:LinkButton ID="LnkButtion" CssClass="buttonClass" runat="server" Text="Purchase" OnClick="LinkButtonPurchase_Click"/>

    <asp:HiddenField ID="hdnPutchaseItemsVariable" value="" runat="server" />


</asp:Content>

