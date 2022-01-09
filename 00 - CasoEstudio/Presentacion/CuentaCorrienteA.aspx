<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CuentaCorrienteA.aspx.cs" Inherits="CuentaCorrienteA" %>

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
        .style9
        {
            width: 324px;
        }
        .style10
        {
            text-align: left;
            width: 114px;
        }
        </style>
    <link href="MiCss.css" rel="stylesheet" type="text/css" />
</head>
<body class="SkinFile">
    <form id="form1" runat="server">
    <div>
    
    <div class="style2">
    
        <em><strong class="MiCss">CUENTA CORRIENTE<br />
        <br />
        </strong></em></div>
    <table style="width: 63%;" border="1" align="center">
        <tr>
            <td class="style10" colspan="1">
                Cliente:</td>
            <td class="style9">
                <asp:TextBox ID="TxtCliente" runat="server" Width="117px"></asp:TextBox>
            &nbsp;<asp:Button ID="BtnBuscarCliente" runat="server" Text="Buscar" 
                    style="text-align: center" Width="58px" onclick="BtnBuscarCliente_Click" 
                    CssClass="MiCss" />
            &nbsp;<asp:Label ID="LblCliente" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style10" colspan="1">
                Monto Minimo:</td>
            <td class="style9">
                <asp:TextBox ID="TxtMinimo" runat="server" Width="186px"></asp:TextBox>
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
                    onclick="BtnAlta_Click" style="text-align: center" Width="58px" 
                    CssClass="MiCss" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnRefresh" runat="server" onclick="BtnRefresh_Click" 
                    Text="Limpio" CssClass="MiCss" />
            </td>
        </tr>
    </table>
    <p style="text-align: center">

          <asp:GridView ID="GrVCuentas" runat="server" Width="423px" 
              onselectedindexchanged="GrVCuentas_SelectedIndexChanged">
              <Columns>
                  <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
              </Columns>
          </asp:GridView>

    </p>   
    <p style="text-align: center">
        <asp:HyperLink ID="HLBVolver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
    </p>
    
    </div>
    </form>
</body>
</html>
