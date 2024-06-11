<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="GymMe.Views.TransactionDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/Styles/CSS/OrderSupplementPage.css"/>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="table-container">
            <div class="container">
                <a href="CustomerTransaction.aspx" class="back_btn">        
                 <i class="bi bi-arrow-left-circle back_btn"></i>
                </a>
                <br />
                <asp:GridView ID="DetailGv" runat="server" AutoGenerateColumns="false" CssClass="grid-view">
                    <Columns>
                        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionId"></asp:BoundField>
                         <asp:BoundField DataField="SupplementID" HeaderText="Supplement ID" SortExpression="TransactionId"></asp:BoundField>
                        <asp:BoundField DataField="MsSupplement.SupplementName" HeaderText="Supplement" SortExpression="MsSupplement.SupplementName"></asp:BoundField>
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
       
    </form>
</body>
</html>
