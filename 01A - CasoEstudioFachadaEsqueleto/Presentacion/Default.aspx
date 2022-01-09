<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</head>
<body bgcolor="#ffe1c1">
    <form id="form1" runat="server">
    <p class="style1">
        <asp:LinkButton ID="lbtnAgregar" runat="server" 
            PostBackUrl="~/AltaArticulo.aspx">Agregar Articulo</asp:LinkButton>
    </p>
    <p class="style1">
        <asp:LinkButton ID="lbtnEliminar" runat="server">Eliminar Articulo</asp:LinkButton>
    </p>
    <p class="style1">
        <asp:LinkButton ID="lbtnModificar" runat="server">Modificar Articulo</asp:LinkButton>
    </p>
    <p class="style1">
        <asp:LinkButton ID="lbtnListar" runat="server" 
            PostBackUrl="~/ListarArticulos.aspx">Listar Articulos</asp:LinkButton>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
