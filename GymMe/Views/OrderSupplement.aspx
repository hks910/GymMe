<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="GymMe.Views.OrderSupplement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/Styles/CSS/OrderSupplementPage.css" />

    <%-- Google Font --%>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Nunito:ital,wght@0,200..1000;1,200..1000&family=Permanent+Marker&family=Quicksand:wght@300..700&family=Shadows+Into+Light&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Edu+TAS+Beginner:wght@400..700&family=Nunito:ital,wght@0,200..1000;1,200..1000&family=Permanent+Marker&family=Quicksand:wght@300..700&family=Shadows+Into+Light&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Comme:wght@100..900&family=Edu+TAS+Beginner:wght@400..700&family=Nunito:ital,wght@0,200..1000;1,200..1000&family=Permanent+Marker&family=Quicksand:wght@300..700&family=Shadows+Into+Light&display=swap" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div id="CustomerNavBar" runat="server">
                <header>
                    <h1 class="Logo">Gym Me</h1>
                    <nav>
                        <ul class="nav__links">
                            <li><a href="OrderSupplement.aspx">Order Supplement</a></li>
                            <li><a href="CustomerTransaction.aspx">History</a></li>
                            <li><a href="Profile.aspx">Profile</a></li>
                        </ul>
                    </nav>
                    <a class="LogoutButton" href="Logout.aspx">Logout</a>
                </header>
            </div>
        <div class="table-container">

  
            <div class="container">

                    <h2>All Supplement List</h2>
                    <asp:GridView ID="SupplementList" runat="server" AutoGenerateColumns="false" OnRowCommand="SupplementList_RowCommand" CssClass="grid-view">
                        <Columns>
                            <asp:BoundField DataField="SupplementID" HeaderText="SupplementID"></asp:BoundField>
                            <asp:BoundField DataField="SupplementName" HeaderText="SupplementName" SortExpression="SupplementName"></asp:BoundField>
                            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Supplement Expiry Date" SortExpression="SupplementExpiryDate"></asp:BoundField>
                            <asp:BoundField DataField="SupplementPrice" HeaderText="SupplementPrice" SortExpression="SupplementPrice"></asp:BoundField>
                            <asp:BoundField DataField="MsSupplementType.SupplementTypeName" HeaderText="Supplement Type Name" SortExpression="MsSupplementType.SupplementTypeName"></asp:BoundField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
                                    <%--<input id="TextBox1" name="TextBox1" type="number" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                           <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="EditButton" runat="server" CommandName="AddToCart" CommandArgument='<%# Container.DataItemIndex %>' Text="Add Cart" CssClass="command-button" />
                                </ItemTemplate>
                           </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            <div class="cart" >
                <div class="text-message">
                     <asp:Label ID="Message2" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <h2>Your carts List : </h2>
                    <asp:GridView ID="CheckOutList" runat="server" AutoGenerateColumns="false" CssClass="grid-view">
                        <Columns>
                            <asp:BoundField DataField="CartID" HeaderText="Cart ID" SortExpression="CartID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="MsUser.UserName" HeaderText="User Name" SortExpression="UserID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="MsSupplement.SupplementName" HeaderText="Supplement Name" SortExpression="MsSupplement.SupplementName"></asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                       
                             <asp:TemplateField HeaderText="SubTotal">
                                <ItemTemplate>
                                    <asp:Label ID="SubTotal" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                       
                        </Columns>
                    </asp:GridView>
                </div>
                  <div class="text-message">
                      Total Price = <asp:Label ID="TotalPriceLabel" runat="server" Text=""></asp:Label>
                  </div>
                <div>
                    <asp:Button ID="CheckOut" runat="server" Text="CheckOut" OnClick="CheckOut_Click" CssClass="command-button checkout"/>
                    <asp:Button ID="ClearCart" runat="server" Text="Clear Cart" OnClick="ClearCart_Click" CssClass="command-button clear" />
                </div>

                <div>
                     <asp:Label ID="Message" runat="server" Text="" CssClass="text-message"></asp:Label>
                </div>
            </div>
            </div>      

        </div>


    </form>
</body>
<script type="text/javascript">
    function incrementQuantity(element) {
        var input = element.parentNode.querySelector('input[type="number"]');
        input.stepUp();
    }
    function decrementQuantity(element) {
        var input = element.parentNode.querySelector('input[type="number"]');
        input.stepDown();
    }
</script>
</html>
