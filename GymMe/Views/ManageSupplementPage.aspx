<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSupplementPage.aspx.cs" Inherits="GymMe.Views.ManageSupplementPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/Styles/CSS/ManageSupplementPage.css" />

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
        <div>
                <div id="AdminNavbar" runat="server">
                    <header>
                        <h1 class="Logo">Gym Me</h1>
                        <nav>
                            <ul class="nav__links">
                                <li><a href="HomePage.aspx">Home</a></li>
                                <li><a href="ManageSupplementPage.aspx">Manage Supplement</a></li>
                                <li><a href="OrderQueue.aspx">Order Queue</a></li>
                                <li><a href="ProfilePage.aspx">Profile</a></li>
                                <li><a href="TransactionReport.aspx">Transaction Report</a></li>
                            </ul>
                        </nav>
                        <a class="LogoutButton" href="Logout.aspx">Logout</a>
                    </header>
                </div>
            <div class ="table-container">
               <div class="container">
                <h2>All Supplement List</h2>
                <div class="grid-view-container">
                    <asp:GridView ID="SupplementList" runat="server" AutoGenerateColumns="False" CssClass="grid-view"
                        OnRowEditing="EditSupplement" OnRowDeleting="DeleteSupplement">
                        <Columns>
                            <asp:BoundField DataField="SupplementID" HeaderText="SupplementID"></asp:BoundField>
                            <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" SortExpression="SupplementName"></asp:BoundField>
                            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Supplement Expiry Date" SortExpression="SupplementExpiryDate"></asp:BoundField>
                            <asp:BoundField DataField="SupplementPrice" HeaderText="Supplement Price" SortExpression="SupplementPrice"></asp:BoundField>
                            <asp:BoundField DataField="MsSupplementType.SupplementTypeName" HeaderText="Supplement Type Name" SortExpression="MsSupplementType.SupplementTypeName"></asp:BoundField>


                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" CssClass="command-button" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CssClass="command-button delete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <a href="InsertSupplementPage.aspx" class="insert-supplement">Insert Supplement</a>
                </div>
            </div>

            </div>

            <div>
                  <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
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
