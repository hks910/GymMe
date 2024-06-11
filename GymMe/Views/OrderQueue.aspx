<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="GymMe.Views.OrderQueue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

     <title>Gym Me</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/CSS/OrderSupplementPage.css" />

 <%-- Google Font --%>
 <link rel="preconnect" href="https://fonts.googleapis.com" />
 <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
 <link href="https://fonts.googleapis.com/css2?family=Nunito:ital,wght@0,200..1000;1,200..1000&family=Permanent+Marker&family=Quicksand:wght@300..700&family=Shadows+Into+Light&display=swap" rel="stylesheet" />

 <link rel="preconnect" href="https://fonts.googleapis.com" />
 <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
 <link href="https://fonts.googleapis.com/css2?family=Edu+TAS+Beginner:wght@400..700&family=Nunito:ital,wght@0,200..1000;1,200..1000&family=Permanent+Marker&family=Quicksand:wght@300..700&family=Shadows+Into+Light&display=swap" rel="stylesheet" />

 <link rel="preconnect" href="https://fonts.googleapis.com" />
 <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
 <link href="https://fonts.googleapis.com/css2?family=Comme:wght@100..900&family=Edu+TAS+Beginner:wght@400..700&family=Nunito:ital,wght@0,200..1000;1,200..1000&family=Permanent+Marker&family=Quicksand:wght@300..700&family=Shadows+Into+Light&display=swap" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <div id="AdminNavbar" runat="server">
    <header>
        <h1 class="Logo">Gym Me</h1>
        <nav>
            <ul class="nav__links">
                <li><a href="HomePage.aspx">Home</a></li>
                <li><a href="ManageSupplementPage.aspx">Manage Supplement</a></li>
                <li><a href="OrderQueue.aspx">Order Queue</a></li>
                 <li><a href="HandledPage.aspx">Completed Order</a></li>
                <li><a href="ProfilePage.aspx">Profile</a></li>
                <li><a href="TransactionReport.aspx">Transaction Report</a></li>
            </ul>
        </nav>
        <a class="LogoutButton" href="Logout.aspx">Logout</a>
    </header>
</div>

        <div>
            <br />
            <asp:Label ID="RoleLbl" runat="server" Text=""></asp:Label>
        </div>
        <div class ="table-container">
            <div class="container">
                    <br />
                    <br />
                    <asp:GridView ID="UnhandledOrderGv" runat="server" AutoGenerateColumns="false" OnRowEditing="UnhandledOrderGv_RowEditing" OnRowDeleting="UnhandledOrderGv_RowDeleting" CssClass="grid-view">
                        <Columns>
                            <asp:BoundField DataField="TransactionId" HeaderText=" Transaction Id" SortExpression="TransactionId"></asp:BoundField>
                            <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserId"></asp:BoundField>
                            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate"></asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                            <asp:CommandField ShowDeleteButton="True" ShowHeader="True" HeaderText="View Detail" DeleteText="View Detail"></asp:CommandField>
                            <asp:CommandField EditText="Handle" ShowCancelButton="False" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Handle"></asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </div>
        </div>

       
    </form>
</body>
</html>
