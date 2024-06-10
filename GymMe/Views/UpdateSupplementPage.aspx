<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSupplementPage.aspx.cs" Inherits="GymMe.Views.UpdateSupplementPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/CSS/UpdateSupplementPage.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

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
        <a href="ManageSupplementPage.aspx" class="back_btn">        
            <i class="bi bi-arrow-left-circle back_btn"></i>
        </a>
        <h1>Update Supplement</h1>
        <form class="form" runat="server">

            <div class="input-box">
                <asp:Label class="label" ID="SupplementNameLbl" runat="server" Text="Supplement Name"></asp:Label>
                <asp:TextBox ID="SupplementNameTxt" placeholder="Enter Supplement Name" runat="server"></asp:TextBox>
            </div>

            <div class="input-box">
                <asp:Label class="label" ID="SupplementExpiryDateLbl" runat="server" Text="Supplement Expiry Date"></asp:Label>
                <asp:TextBox ID="SupplementExpiryDateTxt" runat="server" TextMode="Date" placeholder="Enter Expiry Date"></asp:TextBox>
            </div>

            <div class="input-box">
                <asp:Label class="label" ID="SupplementPriceLbl" runat="server" Text="Supplement Price"></asp:Label>
                <asp:TextBox ID="SupplementPriceTxt" runat="server" TextMode="Number" placeholder="Enter Supplement Price"></asp:TextBox>
            </div>
            <div class="input-box">
                <asp:Label class="label" ID="Label1" runat="server" Text="Supplement Type"></asp:Label>
                <asp:DropDownList ID="SupplementTypeList" runat="server"></asp:DropDownList>
            </div>

            <div class="ErrorLbl">
                <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
            </div>

            <div>
                <asp:Button class="button" ID="UpdateSupplementBtn" runat="server" Text="Submit" OnClick="UpdateSupplement_Click" />
            </div>

        </form>
    </section>
</body>
</html>
