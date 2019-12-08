<%@ Page Title="Account" Language="C#" MasterPageFile="~/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Merchbooth.Customer.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderImage" runat="server">
        <div class="headerImage">
         
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomerContent" runat="server">



    <div class="row" style="margin-top:200px;">
        
        
        
 <%--       <div class="col-lg-1 col-sm-1">
        </div>
        

        <div class="col-lg-10 col-sm-10">--%>
            
<%--            <div class="row">
                <div class="col-lg-12 col-sm-12">
                    <h1 class="reportTitle">Sales by Date</h1>
                </div>
            </div>--%>
           

<%--        <div class="row">--%>



            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" style="border: 1px solid #52527a; position:relative; left:-7vw; padding-bottom:20px;">

                <%--herecopied--%>
                <div class="form-wide">
                    <div class="errormessage"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
       
                    <h2 class="titleCustomerDefualt"><asp:Literal ID="FormHeader" runat="server" EnableViewState="True" Text="Account"></asp:Literal></h2>
       

                    <label for="FirstName">
                        Band Name * 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtFirstName" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtFirstName" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
        
                    <label for="LastName">
                        Band Name * 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtLastName" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtLastName" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>


                    <label for="Email">
                        Email * 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="regPrice" ValidationExpression="^\d+(\.\d\d)?$" ControlToValidate="txtPrice" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>--%>    
                    </label>
                    <asp:TextBox ID="txtEmail"  type="Email" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
 
                    <label for="Password">
                        Password * 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtPassword" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtPassword" Type="Password" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>

                    <label for="Phone">
                        Phone * 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtPhone" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <%--from "Ehsan" from:stackoverflow.com/questions/18585613/how-do-you-validate-phone-number-in-asp-net  --%>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"  ControlToValidate="txtPhone" runat="server" ErrorMessage="Enter A Valid Phone Number Only"></asp:RegularExpressionValidator>--%>    
                    </label>
                    <asp:TextBox ID="txtPhone" type="Phone" MaxLength="25" CssClass="form-control" runat="server"></asp:TextBox>
        
                    <label for="State">
                        State * 
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Please select a state from the drop down list" SetFocusOnError="True" ControlToValidate="ddlState" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                    <asp:DropDownList ID="ddlState" runat="server" DataSourceID="SqlDataSource1" DataTextField="strStateName" DataValueField="intStateID" AutoPostBack="False" AppendDataBoundItems="True" Height="20px" Width="200px">
                	                    <asp:ListItem Value=""> Select your State</asp:ListItem>
                   </asp:DropDownList>
                    <br />
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CPDM_EricksonMConnectionString %>" SelectCommand="SELECT [intStateID], [strStateName] FROM [TStates]"></asp:SqlDataSource>
    
                    <label for="City">
                        City*  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtCity" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtCity" MaxLength="255" CssClass="form-control" runat="server" Text =""></asp:TextBox>
                  
                    <label for="Address">
                        Address* 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtAddress" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                   <%--            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ValidationExpression="^\d+$" ControlToValidate="txtZip" runat="server" ErrorMessage="Enter A Number only"></asp:RegularExpressionValidator>    --%>
                        </label>
                    <asp:TextBox ID="txtAddress" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
        

                    <label for="Zip">
                        Zip* 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="[REQUIRED]" SetFocusOnError="True" ControlToValidate="txtZip" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                    </label>
                    <asp:TextBox ID="txtZip" MaxLength="255" CssClass="form-control" runat="server"></asp:TextBox>
     
                    <label for="Gender">
                        Gender * 
                        <asp:RequiredFieldValidator ID="rfvGeder" runat="server" ErrorMessage="Please select a gender from the drop down list" SetFocusOnError="True" ControlToValidate="ddlGender" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                    <asp:DropDownList ID="ddlGender" runat="server" DataSourceID="SqlDataSource2" DataTextField="strGender" DataValueField="intGenderID" AutoPostBack="False" AppendDataBoundItems="True" Height="20px" Width="200px">
                	                    <asp:ListItem Value=""> Select your Gender</asp:ListItem>
                   </asp:DropDownList>
                    <br />
                    <br />                                                                                 
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CPDM_EricksonMConnectionString %>" SelectCommand="SELECT [intGenderID], [strGender] FROM [TGenders]"></asp:SqlDataSource>

                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text ="Update" OnClick="btnUpdateCustomerAccount_Click"/> &nbsp; 
                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="false" />
        
                </div>



            </div>
            
            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" style=" position:relative; left:-4vw;">
                
                
                <asp:Label ID="lblCustomerOrders" runat="server" CssClass="errormessage" Text="">



                </asp:Label>

            </div>

            </div>
            
            <asp:HiddenField ID="hdnPassedCartItemsVariable" value="" runat="server" />

      <%--  </div>
        

        <div class="col-lg-1 col-sm-1"></div>
    </div>--%>




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
