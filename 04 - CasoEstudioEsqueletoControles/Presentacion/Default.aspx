<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            width: 132px;
        }
        .style2
        {
            width: 132px;
            color: #993399;
            font-weight: bold;
            font-style: italic;
        }
        .style3
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" style="width: 53%;">
        <tr>
            <td class="style2" style="text-align: center">
                UserControls</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" style="text-align: center">
                &nbsp;</td>
            <td class="style3">
                <asp:LinkButton ID="LBtnColoresHost" runat="server" 
                    PostBackUrl="~/EjemploColoresHost.aspx" style="text-align: center">Ejemplo 
                Colores Host</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style1" style="text-align: center">
                &nbsp;</td>
            <td class="style3">
                <asp:LinkButton ID="LBtnGrillaArticulos" runat="server" 
                    PostBackUrl="~/EjemploHostControl.aspx" style="text-align: center">Ejemplo 
                De Comunicacion host-control (Grilla de Articulos)</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style1" style="text-align: center">
                &nbsp;</td>
            <td class="style3">
                <asp:LinkButton ID="LBtnColoresHost1" runat="server" 
                    PostBackUrl="~/EjemploCalendario.aspx" style="text-align: center">Ejemplo 
                Calendario</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style2" style="text-align: center">
                CostumControl</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="text-align: center">
                &nbsp;</td>
            <td class="style3">
                <asp:LinkButton ID="LBtnColoresHost2" runat="server" 
                    PostBackUrl="~/EjemploListBoxMeses.aspx" style="text-align: center">Ejemplo 
                ListBox de Meses</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style2" style="text-align: center">
                CompositeControl</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="text-align: center">
                &nbsp;</td>
            <td class="style3">
                <asp:LinkButton ID="LBtnColoresHost3" runat="server" 
                    PostBackUrl="~/EjemploLetras.aspx" style="text-align: center">Ejemplo 
                Control Letras</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
    
</body>
</html>
