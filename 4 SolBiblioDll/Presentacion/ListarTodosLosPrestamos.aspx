<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarTodosLosPrestamos.aspx.cs" Inherits="ListarTodosLosPrestamos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="antiquewhite">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>
        Listado de Préstamos</strong><br />
        <br />
        <asp:ListBox ID="lstPrestamos" runat="server" Height="352px" Width="712px"></asp:ListBox><br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton></div>
    </form>
</body>
</html>
