<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploColoresHost.aspx.cs" Inherits="EjemploColoresHost" %>

<%@ Register src="ColoresHost.ascx" tagname="ColoresHost" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">

        .style2
        {
            color: #990033;
            font-weight: bold;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" border="1" style="width: 38%;">
        <tr>
            <td class="style2">
                Ejemplo Basico de Seleccion de Colores con Manejo de elementos de la pagina Host</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <uc1:ColoresHost ID="ColoresHost1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <hr />
                <asp:TextBox ID="txtPrueba" runat="server">Escribe please</asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnPrueba" runat="server" Height="26px"  Text="Boton" />
                <br />
                <br />
                <asp:Label ID="lblPrueba" runat="server" style="text-align: center" 
                    Text="Un texto Cualquiera"></asp:Label>
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:LinkButton ID="LBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
                    style="text-align: center">Volver</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
