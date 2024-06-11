<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandledPage.aspx.cs" Inherits="GymMe.Views.HandledPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gym Me</title>
    <link href="../Styles/CSS/NavBar.css" rel="stylesheet" />

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
                        <li><a href="ManageSupplement.aspx">Manage Supplement</a></li>
                        <li><a href="OrderQueue.aspx">Order Queue</a></li>
                        <li><a href="HandledPage.aspx">Completed Order</a></li>
                        <li><a href="Profile.aspx">Profile</a></li>
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

        <div>
            <br />
            <asp:GridView ID="HandledGv" runat="server" AutoGenerateColumns="false" OnRowEditing="HandledGv_RowEditing">
                <Columns>
                    
                    <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" SortExpression="TransactionId"></asp:BoundField>
                    <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID"></asp:BoundField>
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate"></asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                    <asp:CommandField ShowCancelButton="False" EditText="View Detail" ShowEditButton="True" ShowHeader="True" HeaderText="View Detail"></asp:CommandField>
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
