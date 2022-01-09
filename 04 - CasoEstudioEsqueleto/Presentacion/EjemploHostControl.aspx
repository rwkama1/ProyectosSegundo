<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploHostControl.aspx.cs" Inherits="EjemploHostControl" %>


<%@ Register src="GrillasArticulos.ascx" tagname="GrillasArticulos" tagprefix="uc1" %>


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
        .style3
        {
            width: 72px;
        }
        .style4
        {
            height: 172px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" border="1" style="width: 29%;">
        <tr>
            <td class="style2" colspan="3">
                Ejemplo Basico de Seleccion de Colores con Manejo de elementos de la pagina Host</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" class="style4">
                <uc1:GrillasArticulos ID="GrillasArticulos1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                Codigo:
                <br />
                Nombre:
                <br />
                Precio:
            </td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtprecio" runat="server" ></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="BtnCarga" runat="server" Text="Cargar Articulos" 
                    onclick="BtnCarga_Click" style="text-align: left" />
                <br />
                <asp:Button ID="BtnMuestra" runat="server" 
                    Text="Mostrar Articulo Seleccionado" onclick="BtnMuestra_Click" 
                    Width="189px" />
                <br />
            </td>
            </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Width="384px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="3">
                <asp:LinkButton ID="LBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
                    style="text-align: center">Volver</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
