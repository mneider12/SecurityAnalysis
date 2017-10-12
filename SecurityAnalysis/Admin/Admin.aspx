<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SecurityAnalysis.Admin.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="btnCreateDatabase" Text="Create Database" OnClick="btnCreateDatabase_Click" />
        <asp:Button runat="server" ID="btnDeleteDatabase" Text="Delete Database" OnClick="btnDeleteDatabase_Click" />
        <asp:Button runat="server" ID="btnBackupDatabase" Text="Backup Database" OnClick="btnBackupDatabase_Click" />
    </div>
    <div>
        <asp:Button runat="server" ID="btnCreateTransactionsTable" Text="Create Transactions Table" OnClick="btnCreateTransactionsTable_Click" />
        <asp:Button runat="server" ID="btnCreatePricesTable" Text="Create Prices Table" OnClick="btnCreatePricesTable_Click" />
        <asp:Button runat="server" ID="btnCreateCalculatedStatisticsTable" Text="Create Calculated Statistics Table" OnClick="btnCreateCalculatedStatisticsTable_Click" />
    </div>
    </form>
</body>
</html>
