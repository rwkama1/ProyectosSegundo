<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgregarPublicacionPapel.aspx.cs" Inherits="AgregarPublicacionPapel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align: center" bgcolor="antiquewhite">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>
        Agregar Publicaci�n en Papel</strong><br />
        <br />
        <table>
            <tr>
                <td style="width: 61px; height: 21px">
                    ISBN:</td>
                <td style="width: 100px; height: 21px">
                    <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 61px">
                    T�tulo:</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 61px">
                    Peso:</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" Font-Bold="True" OnClick="btnAgregar_Click"
                        Text="Agregar!" /></td>
            </tr>
        </table>
        <br />
    
    </div>
        <asp:Label ID="lblError" runat="server"></asp:Label>&nbsp;<br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </form>
</body>
</html>
