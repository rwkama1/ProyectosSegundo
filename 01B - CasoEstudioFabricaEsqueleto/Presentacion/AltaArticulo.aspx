<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaArticulo.aspx.cs" Inherits="AltaArticulo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            color: #FF0000;
            font-weight: bold;
        }
    </style>
</head>
<body bgcolor="#ffe1c1">
    <form id="form1" runat="server">
    <div class="style1">
        <span class="style2">Alta de Articulos</span><br />
        <br />
        Codigo
        <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
        <br />
        Nombre<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        Precio
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
            Text="Agregar" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="386px"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </div>
    </form>
</body>
</html>
