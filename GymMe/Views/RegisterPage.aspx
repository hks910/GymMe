<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="GymMe.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/CSS/RegisterPage.css" />

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
    <section class="container">
        <h1>Create Account</h1>
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
                <asp:Label class="label" ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="PasswordTxt" runat="server" placeholder="Enter password" TextMode="Password"></asp:TextBox>
            </div>

            <div class="input-box">
                <asp:Label class="label" ID="ConfirmationLbl" runat="server" Text="Confirmation Password"></asp:Label>
                <asp:TextBox ID="ConfirmationTxt" runat="server" placeholder="Enter confirmation password" TextMode="Password"></asp:TextBox>
            </div>

            <div class="input-box">
                <asp:Label class="label" ID="DOBLbl" runat="server" Text="Birth Date "></asp:Label>
                <asp:TextBox ID="DOBTxt" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <div class="ErrorLbl">
                <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
            </div>

            <div>
                <asp:Button class="button" ID="RegisterBtn" runat="server" Text="Submit" OnClick="RegisterBtn_Click" />
            </div>

            <div class="input-box">
                <asp:Label ID="LoginLbl" runat="server" Text="Already Have An Account?" Style="margin-right: 0px;"></asp:Label>
                <asp:LinkButton ID="LoginLink" runat="server" OnClick="LoginLink_Click">Login Here</asp:LinkButton>
            </div>
        </form>
    </section>
</body>
</html>
