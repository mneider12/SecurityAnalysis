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
    </form>
</body>
</html>
