<%@ Page Title="About" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Merchbooth.Customer.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
        <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomerContent" runat="server">
        <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />

    <div style="margin-top:200px"></div>
  
    <h2><%: Title %></h2>

    <h3>What is Merchbooth?</h3>
        <p>
	        Merchbooth is a centralized Inventory Management system and ecommerce solution for bands.<br />
	    </p>
    <h3>What Can Merchbooth do?</h3>
        <p>
	        Provides bands with easy to use UI to design and manage an inventory system that fits their unique needs.	<br />
	        Provides bands with e-commerce and in-person merchandise sales options.<br />
	        Connects all sales to one centralized inventory system.<br />
	        Efficiently manages sales tracking in the hectic environment of merch sales.<br />
	        Centralizes all inventory changes and provides valuable data analysis features to account admins.<br />
        </p>

    <h3>Who is Merchbooth for?</h3>
        <p>
	        Bands / Band Managers / Small businesses:<br />
		        Use UI to save their inventory. <br />
		        Use UI to deploy custom e-commerce websites.<br />
		        Create unique accounts for sales personell and team managers.<br />
		        Analyze sales data to know which products and different markets perform best.
                Manage inventory and stock reorders.<br />
                Analyze overall performance.<br />
	        Band members / Sales Personal:<br />
		        Make sales easy by scanning items with your smartphone's Camera (feature coming soon!) <br />
	        Customers (e-commerce):
		        View order history.<br />
		        Purchase new items.<br />
        </p>



    <script type="text/javascript">

        var intTotalCount = 0;

        window.onload = function () {

            var cartString = document.getElementById("<%= hdnPassedCartItemsVariable.ClientID%>").value;
            var intStartIndex = 0;
            var intEndIndex = 0;
            var intEndIndex = 0;

            if (cartString.indexOf("{") != -1) {
                document.getElementById("home").href = "http://localhost:10349/Customer/Default.aspx?cart=" + cartString;
                document.getElementById("allbands").href = "http://localhost:10349/Customer/AllBands.aspx?cart=" + cartString;
                document.getElementById("about").href = "http://localhost:10349/Customer/About.aspx?cart=" + cartString;
                document.getElementById("contact").href = "http://localhost:10349/Customer/Contact.aspx?cart=" + cartString;
                document.getElementById("account").href = "http://localhost:10349/Customer/Account.aspx?cart=" + cartString;



                while (cartString.indexOf("{") != -1) {
                    intStartIndex = cartString.indexOf("Amount");
                    intEndIndex = cartString.indexOf("}", intStartIndex);
                    intAmount = 1 * (cartString.substring(intStartIndex + 7, intEndIndex));

                    intTotalCount += 1 * intAmount;

                    cartString = cartString.substring(intEndIndex);

                }

                document.getElementById("cartCountCustomer").innerHTML = intTotalCount;

            }
            }
                function ClearCart()
                {

                    if (intTotalCount > 0)
                    {
                        intTotalCount = 0;  
                        document.getElementById("cartCountCustomer").innerHTML = "";
                        document.getElementById("<%= hdnPassedCartItemsVariable.ClientID%>").value = "";
                          
                        document.getElementById("home").href="http://localhost:10349/Customer/Default"; 
                        document.getElementById("allbands").href="http://localhost:10349/Customer/AllBands"; 
                        document.getElementById("about").href="http://localhost:10349/Customer/About"; 
                        document.getElementById("contact").href="http://localhost:10349/Customer/Contact"; 
                        document.getElementById("account").href="http://localhost:10349/Customer/Account"; 
                    }
                }
        



    </script>
</asp:Content>
