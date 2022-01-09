<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 69px;
        }
        .style2
        {
            color: #FF0000;
            text-decoration: underline;
        }
        .style3
        {
        }
        .style4
        {
            width: 138px;
        }
    </style>
</head>
<body bgcolor="#ffffcc">
    <form id="form1" runat="server">
    <div>
    
        <br />
        <p style="text-align: center; color: #009933; text-decoration: underline; font-style: italic; font-weight: 700; font-size: xx-large"> Muestra de Transacciones a Nivel de Logica de un Sistema</p>
        <table style="width:100%;">
            <tr>
                <td class="style3">
        <table align="center" style="width: 26%;">
            <tr>
                <td class="style1">
                    Codigo</td>
                <td>
                    <asp:TextBox ID="TxtCodigo" runat="server" ReadOnly="True" Width="170px" 
                        Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Nombre</td>
                <td>
                    <asp:TextBox ID="TxtNombre" runat="server" Width="170px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Direccion</td>
                <td>
                    <asp:TextBox ID="TxtDireccion" runat="server" Width="170px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <strong>TELEFONOS</strong></td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="BtnBorrarTel" runat="server" onclick="BtnBorrarTel_Click" 
                        Text="Borrar Tel" Width="80px" />
                </td>
                <td>
                    <asp:ListBox ID="LbTelefonos" runat="server" Width="151px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="BtnAgregarTel" runat="server" Text="Agregar Tel" Width="80px" 
                        onclick="BtnAgregarTel_Click" />
                </td>
                <td>
                    <asp:TextBox ID="TxtTelefono" runat="server" Width="145px"></asp:TextBox>
                </td>
            </tr>
        </table>
    
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="GVClientes" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" 
                        onselectedindexchanged="GVClientes_SelectedIndexChanged" Width="483px">
                        <Columns>
                            <asp:BoundField DataField="CodCli" HeaderText="Codigo" />
                            <asp:BoundField DataField="NomCli" HeaderText="Nombre" />
                            <asp:BoundField DataField="DirCli" HeaderText="Direccion" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Button ID="BtnAgregarCliente" runat="server" Text="Agregar Cliente" 
                        Width="125px" onclick="BtnAgregarCliente_Click" />
&nbsp;&nbsp;
                    <asp:Button ID="BtnModificarTelCliente" runat="server" 
                        Text="Modificar Los Telefonos de un Cliente" Width="228px" 
                        onclick="BtnModificarTelCliente_Click" />
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnRefrescar" runat="server" Text="Limpiar Todo" Width="92px" 
                        onclick="BtnRefrescar_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="3">
                    <asp:Label ID="LblError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
