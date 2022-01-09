<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoCuentaCorrienteporcliente.aspx.cs" Inherits="ListadoCuentaCorrienteporcliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 143px;
        }
    </style>
</head>
<body class="SkinFile">
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table style="width: 112%; height: 378px;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblcorrienteporcliente" runat="server" Font-Bold="True" 
                    Font-Size="XX-Large" Text="Listado Cuenta Corriente por Cliente"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gdrcuentacorrienteporcliente" runat="server" Height="267px" 
                    Width="632px">
                </asp:GridView>
                <asp:TextBox ID="txtcorriente" runat="server" Height="29px" Width="245px"></asp:TextBox>
                <asp:Button ID="btnBuscarCorriente" runat="server" Height="28px" 
                    onclick="btnBuscarCorriente_Click" Text="Buscar" Width="94px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblerror" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
