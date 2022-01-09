<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClienteAbm.aspx.cs" Inherits="ClienteAbm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            text-align: center;
            color: #800000;
            text-decoration: underline;
            font-size: x-large;
        }
        .style3
        {
        }
        .style8
        {
            width: 65px;
        }
        .style9
        {
            width: 173px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style2">
    
        <em><strong>CLIENTES<br />
        <br />
        </strong></em></div>
    <table style="width: 32%;" border="1" align="center">
        <tr>
            <td class="style8" colspan="1">
                Numero:</td>
            <td colspan="3">
                <asp:TextBox ID="TxtNumero" runat="server"></asp:TextBox>
            </td>
            <td class="style9" colspan="1">
                <asp:Button ID="BtnBusco" runat="server" Text="Buscar" 
                    onclick="BtnBusco_Click" />
              </td>
        </tr>
        <tr>
            <td class="style8" colspan="1">
                Nombre:</td>
            <td colspan="3">
                <asp:TextBox ID="TxtNombre" runat="server" Width="186px"></asp:TextBox>
            </td>
                       <td class="style9" colspan="1">
              </td>
 
        </tr>
        <tr>
            <td class="style8" colspan="1">
                Direccion:</td>
            <td colspan="3">
                <asp:TextBox ID="TxtDireccion" runat="server" Width="186px"></asp:TextBox>
            </td>
                       <td class="style9" colspan="1">
              </td>
 
        </tr>
        <tr>
            <td class="style3" colspan="5">
                <asp:Label ID="LblError" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style1">
                <asp:Button ID="BtnAlta" runat="server" Text="Alta" Enabled="False" 
                    onclick="BtnAlta_Click" />
            </td>
            <td class="style1">
                <asp:Button ID="BtnBaja" runat="server" Text="Baja" Enabled="False" 
                    onclick="BtnBaja_Click" />
            </td>
            <td>
                <asp:Button ID="BtnModificar" runat="server" Text="Modificar" Enabled="False" 
                    onclick="BtnModificar_Click" />
            </td>
            <td class="style9" >
                <asp:Button ID="BtnRefresh" runat="server" onclick="BtnRefresh_Click" 
                    Text="Limpiar" />
            </td>
        </tr>
    </table>
    <p style="text-align: center">
        <asp:HyperLink ID="HLBVolver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
    </p>
    </form>
</body>
</html>
