<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="GymMe.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/CSS/LoginPage.css" />

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
    <main>
        <h1 class="Title">Gym Me</h1>
        <%--<img class="GymMe-Logo" src="<%= ResolveUrl("~/Styles/Img/GymMe-Logo-removebg.png") %>" />--%>
        <form class="form-div" runat="server">

            <img class="GymMe-Logo" src="<%= ResolveUrl("~/Styles/Img/GymMe-Logo-removebg.png") %>" />
            <div id="form-input">
                <h1 class="LoginTitle">Login</h1>

                <asp:TextBox class="input" ID="UsernameTxt" placeholder="Username" runat="server"></asp:TextBox>

                <asp:TextBox class="input" ID="PasswordTxt" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>

                <div class="remember-me">
                    <asp:CheckBox class="checkBox" ID="CheckBoxBtn" runat="server" Text=" Remember Me" />
                </div>
                <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>

                <br />
                <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />

                <div class="line">
                    <span class="arrow"></span>
                    <span class="content">OR</span>
                    <span class="arrow"></span>
                </div>

                <asp:Label class="Register-Text" ID="RegisterLbl" runat="server" Text="Don't have an account?"></asp:Label>
                <asp:LinkButton class="Register-Text" ID="RegisterLink" runat="server" OnClick="RegisterLink_Click">Register Here</asp:LinkButton>
            </div>
        </form>
    </main>

</body>
</html>
