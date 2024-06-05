<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GymMe.Views.HomePage" %>

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
        <div id="CustomerNavBar" runat="server">
            <header>
                <h1 class="Logo">Gym Me</h1>
                <nav>
                    <ul class="nav__links">
                        <li><a href="OrderSupplement.aspx">Order Supplement</a></li>
                        <li><a href="Transactions.aspx">History</a></li>
                        <li><a href="Profile.aspx">Profile</a></li>
                    </ul>
                </nav>
                <a class="LogoutButton" href="Logout.aspx">Logout</a>
            </header>
        </div>

        <div id="AdminNavbar" runat="server">
            <header>
                <h1 class="Logo">Gym Me</h1>
                <nav>
                    <ul class="nav__links">
                        <li><a href="HomePage.aspx">Home</a></li>
                        <li><a href="ManageSupplement.aspx">Manage Supplement</a></li>
                        <li><a href="OrderQueue.aspx">Order Queue</a></li>
                        <li><a href="Profile.aspx">Profile</a></li>
                        <li><a href="TransactionReport.aspx">Transaction Report</a></li>
                    </ul>
                </nav>
                <a class="LogoutButton" href="Logout.aspx">Logout</a>
            </header>
        </div>

        <div>
            <asp:Label ID="RoleLbl" runat="server" Text=""></asp:Label>
        </div>


    </form>
</body>
</html>
