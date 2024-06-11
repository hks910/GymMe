<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="GymMe.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                      <li><a href="ProfilePage.aspx">Profile</a></li>
              
                  </ul>
              </nav>
              <a class="LogoutButton" href="Logout.aspx">Logout</a>
          </header>
      </div>

         <div>
             <h2>Supplement Name</h2>
                <asp:Label ID="SupplementName" runat="server" Text="Label"></asp:Label>
       
        </div>
    </form>
</body>
</html>
