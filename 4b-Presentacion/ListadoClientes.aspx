<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ListadoClientes.aspx.cs" Inherits="ListadoClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <strong><em>Todos Los Clientes</em></strong></p>
    <p>
        <asp:Repeater ID="RpClientes" runat="server" 
            onitemcommand="RpClientes_ItemCommand" >
           
          <ItemTemplate>
                        <table>
                            <tr bgcolor="#6666FF">
                                 <td> Num:  <asp:TextBox ID="TxtNumero" runat="server" Text = '<%# Bind("NumCli") %>'></asp:TextBox> <br /> </td>
                                <td> Nom:  <asp:TextBox ID="TxtNombre" runat="server" Text='<%# Bind("NomCli") %>'></asp:TextBox> <br /> </td>
                                <td> Dir:  <asp:TextBox ID="TxtDireccion" runat="server" Text = '<%# Bind("DirCli") %>'></asp:TextBox> <br /> </td>
                                <td> Usu:  <asp:TextBox ID="TxtUsuario" runat="server" Text='<%# Bind("UsuCli") %>'></asp:TextBox> <br /> </td>
                                <td> <asp:Button ID="Button2" runat="server" CommandName="Listar" style="text-align: center" Text="Listar Cuentas" /> </td>
                              </tr>
                        </table>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <table>
                            <tr bgcolor="#333377">
                                 <td> Num:  <asp:TextBox ID="TxtNumero" runat="server" Text = '<%# Bind("NumCli") %>'></asp:TextBox> <br /> </td>
                                <td> Nom:  <asp:TextBox ID="TxtNombre" runat="server" Text='<%# Bind("NomCli") %>'></asp:TextBox> <br /> </td>
                                <td> Dir:  <asp:TextBox ID="TxtDireccion" runat="server" Text = '<%# Bind("DirCli") %>'></asp:TextBox> <br /> </td>
                                <td> Usu:  <asp:TextBox ID="TxtUsuario" runat="server" Text='<%# Bind("UsuCli") %>'></asp:TextBox> <br /> </td>
                                <td> <asp:Button ID="Button2" runat="server" CommandName="Listar" style="text-align: center" Text="Listar Cuentas" /> </td>
                           </tr>
                        </table>
                    </AlternatingItemTemplate>
        </asp:Repeater>
    </p>
    <p>
        <asp:Label ID="LblError" runat="server"></asp:Label>
    </p>
    <p>
        <strong><em>Cuentas del Cliente Seleccionado</em></strong></p>
    <p>
        <asp:GridView ID="GVCuentas" runat="server" AutoGenerateColumns="False" 
            Width="199px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" 
            BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="NumCta" HeaderText="Numero" />
                <asp:BoundField DataField="SaldoCuenta" HeaderText="Saldo" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

