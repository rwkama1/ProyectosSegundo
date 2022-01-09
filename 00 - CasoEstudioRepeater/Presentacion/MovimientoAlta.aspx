<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MovimientoAlta.aspx.cs" Inherits="MovimientoAlta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


        .style2
        {
            text-align: center;
            color: #800000;
            text-decoration: underline;
            font-size: x-large;
        }
        .style8
        {
            text-align: center;
        }
        .style10
        {
            height: 22px;
        }
    </style>
</head>
<body>
    
    <div class="style2">
    
        <em><strong>Movimientos de Cuentas<br />
        <br />
        </strong></em></div>
    <form id="form1" runat="server">
    <table style="width: 32%;" border="1" align="center">
        <tr>
            <td colspan="1">
                Cuenta:</td>
            <td class="style10">
                <asp:DropDownList ID="DDLCuenta" runat="server">
                </asp:DropDownList>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style8" colspan="1">
                Monto:</td>
            <td>
                <asp:TextBox ID="TxtMonto" runat="server" Width="186px"></asp:TextBox>
            </td>
 
        </tr>
        <tr>
            <td class="style8" colspan="1">
                Tipo:</td>
            <td>
                <asp:RadioButton ID="RbtnRetiro" runat="server" Checked="True" Text="Retiro" 
                    GroupName="Tipo" />
&nbsp;<asp:RadioButton ID="RBTNDeposito" runat="server" Text="Deposito" GroupName="Tipo" />
            </td>
 
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <asp:Label ID="LblError" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8" colspan="2">
                <asp:Button ID="BtnAlta" runat="server" Text="Alta" 
                    onclick="BtnAlta_Click" style="text-align: center" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnRefresh" runat="server" onclick="BtnRefresh_Click" 
                    Text="Limpiar" />
            </td>
        </tr>
    </table>
    <p style="text-align: center">
        <asp:HyperLink ID="HLBVolver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
    </p>
    
    <div>
    
    </div>
    </form>
</body>
</html>
