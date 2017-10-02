<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SecurityAnalysis.Admin.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblDatabaseLocation" Text="Database Location: " AssociatedControlID="txtDatabaseLocation" />
        <asp:TextBox runat="server" ID="txtDatabaseLocation" />
    </div>
    </form>
</body>
</html>
