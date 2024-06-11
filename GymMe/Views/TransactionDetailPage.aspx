<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="GymMe.Views.TransactionDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:GridView ID="DetailGv" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionId"></asp:BoundField>
                     <asp:BoundField DataField="SupplementID" HeaderText="Supplement ID" SortExpression="TransactionId"></asp:BoundField>
                    <asp:BoundField DataField="MsSupplement.SupplementName" HeaderText="Supplement" SortExpression="MsSupplement.SupplementName"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
       
    </form>
</body>
</html>
