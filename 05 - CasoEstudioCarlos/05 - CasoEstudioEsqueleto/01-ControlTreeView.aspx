<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01-ControlTreeView.aspx.cs" Inherits="_01_ControlTreeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" 
        ExpandDepth="1" Height="159px" Width="129px">
    </asp:TreeView>
    </form>
</body>
</html>
