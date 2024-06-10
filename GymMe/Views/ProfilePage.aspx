<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="GymMe.Views.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/CSS/ProfilePage.css"/>

    <!-- Google Font -->
    <link href="https://fonts.googleapis.com/css2?family=Nunito:ital,wght@0,200..1000;1,200..1000&family=Permanent+Marker&family=Quicksand:wght@300..700&family=Shadows+Into+Light&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Edu+TAS+Beginner:wght@400..700&family=Nunito:ital,wght@0,200..1000;1,200..1000&family=Permanent+Marker&family=Quicksand:wght@300..700&family=Shadows+Into+Light&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Comme:wght@100..900&family=Edu+TAS+Beginner:wght@400..700&family=Nunito:ital,wght@0,200..1000;1,200..1000&family=Permanent+Marker&family=Quicksand:wght@300..700&family=Shadows+Into+Light&display=swap" rel="stylesheet" />
</head>
<body>
    <div id="CustomerNavBar" runat="server">
        <header>
            <h1 class="Logo">Gym Me</h1>
            <nav>
                <ul class="nav__links">
                    <li><a href="OrderSupplement.aspx">Order Supplement</a></li>
                    <li><a href="Transactions.aspx">History</a></li>
                    <li><a href="ProfilePage.aspx">Profile</a></li>
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
                    <li><a href="ManageSupplementPage.aspx">Manage Supplement</a></li>
                    <li><a href="OrderQueue.aspx">Order Queue</a></li>
                    <li><a href="ProfilePage.aspx">Profile</a></li>
                    <li><a href="TransactionReport.aspx">Transaction Report</a></li>
                </ul>
            </nav>
            <a class="LogoutButton" href="Logout.aspx">Logout</a>
        </header>
    </div>

    <div class="bodies">
        <section class="container">
            <h1>Your Information</h1>
            <form class="form" runat="server">

                <div class="input-box">
                    <asp:Label class="label" ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="UsernameTxt" placeholder="Enter username" runat="server"></asp:TextBox>
                </div>

                <div class="input-box">
                    <asp:Label class="label" ID="EmailLbl" runat="server" Text="Email "></asp:Label>
                    <asp:TextBox ID="EmailTxt" runat="server" placeholder="Enter email address" TextMode="Email"></asp:TextBox>
                </div>

                <div class="gender-box">
                    <asp:Label class="label" ID="GenderLbl" runat="server" Text="Gender" Style="margin-right: 10px;"></asp:Label>
                    <div class="gender-option">
                        <div class="gender">
                            <asp:RadioButton class="genderText" ID="radioMale" runat="server" AutoPostBack="true" Text=" Male" OnCheckedChanged="radioMale_CheckedChanged" GroupName="gender" />
                        </div>

                        <div class="gender">
                            <asp:RadioButton class="genderText" ID="radioFemale" runat="server" AutoPostBack="true" Text=" Female" OnCheckedChanged="radioFemale_CheckedChanged" GroupName="gender" />
                        </div>
                    </div>

                </div>

                <div class="input-box">
                    <asp:Label class="label" ID="DOBLbl" runat="server" Text="Birth Date "></asp:Label>
                    <asp:TextBox ID="DOBTxt" runat="server" TextMode="Date"></asp:TextBox>
                </div>

                <div class="ErrorLbl">
                    <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
                </div>

                <div>
                    <asp:Button class="button" ID="UpdateBtn" runat="server" Text="Update Profile" OnClick="UpdateBtn_Click" />
                </div>

                <%--Update Password--%> 
                <div class="input-box">
                    <asp:Label class="label" ID="OldPasswordLbl" runat="server" Text="Old Password"></asp:Label>
                    <asp:TextBox ID="OldPasswordTxt" runat="server" placeholder="Enter your old password" TextMode="Password"></asp:TextBox>
                </div>

                <div class="input-box">
                    <asp:Label class="label" ID="NewPasswordLbl" runat="server" Text="New Password"></asp:Label>
                    <asp:TextBox ID="NewPasswordTxt" runat="server" placeholder="Enter your new password" TextMode="Password"></asp:TextBox>
                </div>

                <div class="ErrorLbl">
                    <asp:Label ID="PassErrorLbl" runat="server" Text=""></asp:Label>
                </div>

                <div>
                    <asp:Button class="button" ID="Button1" runat="server" Text="Update Password" OnClick="UpdatePassBtn_Click" />
                </div>
            </form>
        </section>
    </div>
</body>
</html>
