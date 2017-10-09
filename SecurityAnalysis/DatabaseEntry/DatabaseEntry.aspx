<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabaseEntry.aspx.cs" Inherits="SecurityAnalysis.DatabaseViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>   <%-- Data Entry Section --%>
                <div> <%-- Date Section --%>
                    <asp:Label runat="server" ID="lblDate" Text="Date:" AssociatedControlID="lblDate"/>
                    <asp:TextBox runat="server" ID="txtDate" TextMode="Date"  />
                </div>
                <div> <%-- Ticker section --%>
                    <asp:Label runat="server" ID="lblTicker" Text="Ticker:" AssociatedControlId="txtTicker" />
                    <asp:TextBox runat="server" ID="txtTicker" />
                </div>
                <div> <%-- Number of shares section --%>
                    <asp:Label runat="server" ID="lblNumberOfShares" Text="Shares" AssociatedControlID="txtNumberOfShares" />
                    <asp:TextBox runat="server" ID="txtNumberOfShares" />
                </div>
                <div> <%-- Total cost section --%>
                    <asp:Label runat="server" ID="lblTotalCost" Text="Total Cost" AssociatedControlID="txtTotalCost" />
                    <asp:TextBox runat="server" ID="txtTotalCost" />
                </div>
            </div>
            <div>   <%-- Control buttons --%>
                <asp:Button runat="server" ID="btnClear" Text="Clear" disabled="true" CausesValidation="false" />
                <asp:Button runat="server" ID="btnSend" Text="Enter" CausesValidation="true" Enabled="true" OnClick="btnSend_Click" />
            </div>
        </div>
        <asp:ScriptManager ID="SMgr" runat="server">
            <Scripts>
                <asp:ScriptReference Path="./DatabaseEntryBehavior.js" />
            </Scripts>
        </asp:ScriptManager>
    </form>
    
</body>
</html>
