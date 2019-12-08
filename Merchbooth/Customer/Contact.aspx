<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Merchbooth.Customer.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
        <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomerContent" runat="server">
        <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />

        <div style="margin-top:200px"></div>
    <h2><%:Title %> info:</h2>
    
    <div id ="body">
        <h3>Location:</h3>
            <address>
                Merchbooth<br />
                Cincinnati, Oh 45223<br />
            </address>
        <h3>Email:</h3>
            <address>
                <strong>Support:</strong>   <a href="mailto:merchboothAPP@gmail.com">merchboothAPP@gmail.com</a><br />
            </address>
       </div>


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
