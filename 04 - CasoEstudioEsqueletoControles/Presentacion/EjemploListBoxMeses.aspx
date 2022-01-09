<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploListBoxMeses.aspx.cs" Inherits="EjemploListBoxMeses" %>

<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>

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
            width: 322px;
        }
        .style3
        {
        }
        .style4
        {
            width: 179px;
            text-align: center;
        }
        .style5
        {
            color: #FF6600;
            font-weight: bold;
        }
        .style6
        {
            color: #FF5050;
            font-weight: bold;
        }
        .style7
        {
            color: #FF0000;
        }
        .style8
        {
            height: 49px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" border="1" style="width: 55%;">
        <tr>
            <td class="style2" colspan="2">
                Ejemplo costum Control</td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" rowspan="3">
                <span class="style5">ListBox de Meses</span><br />
                <cc1:ListBoxMeses ID="LbMeses" runat="server" Height="105px" Width="105px">
                </cc1:ListBoxMeses>
            </td>
            <td class="style8">
                <span class="style6">Determine el mes a Seleccionar Con Nombre</span><br />
                <asp:TextBox ID="TxtMesString" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="BtnSeleccionString" runat="server" 
                    onclick="BtnSeleccionString_Click" Text="Seleccionar" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                <b><span class="style7">Mes Seleccionado con Nombre<br />
                <asp:TextBox ID="TxtMesRev" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="BtnRevisar" runat="server" onclick="BtnRevisar_Click" 
                    Text="Revisar" />
                </span></b>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <b><span class="style7"><span class="style6">Determine el mes a Seleccionar Con 
                Numero</span><br />
                <asp:TextBox ID="TxtMesInt" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="BtnSeleccionInt" runat="server" onclick="BtnSeleccionInt_Click" 
                    Text="Seleccionar" />
                </span></b>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <cc1:ListBoxnumeroMeses ID="LBlistboxnumeromeses" runat="server" Height="73px" 
                    Width="90px">
                </cc1:ListBoxnumeroMeses>
                <asp:TextBox ID="txtmes" runat="server"></asp:TextBox>
                <asp:Button ID="btnSeleccionarnumero" runat="server" 
                    onclick="btnSeleccionarnumero_Click" Text="SeleccionNumero" />
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <asp:Label ID="LblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" class="style3" colspan="2">
                <asp:LinkButton ID="LBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
                    style="text-align: center">Volver</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
