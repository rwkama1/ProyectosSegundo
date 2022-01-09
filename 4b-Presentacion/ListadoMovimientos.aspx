<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ListadoMovimientos.aspx.cs" Inherits="ListadoMovimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 252px;
        }
        .style6
        {
            width: 252px;
            height: 31px;
        }
        .style7
        {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <table border="1" style="width:100%;">
            <tr>
                <td class="style6">
                    Seleccione Tipo de Busqueda:</td>
                <td class="style7">
                    <asp:DropDownList ID="DDLTipoBusqueda" runat="server" Height="30px" 
                        Width="294px">
                        <asp:ListItem>Sin Filtro</asp:ListItem>
                        <asp:ListItem>Filtrar por Numero de Cuenta</asp:ListItem>
                        <asp:ListItem>Filtrar por Tipo Movimiento</asp:ListItem>
                        <asp:ListItem>Filtrar por Fecha</asp:ListItem>
                        <asp:ListItem>Cantidad de Movimientos por Cuenta</asp:ListItem>
                        <asp:ListItem>Ordenar por numero de Cuenta</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Dato para Filtro:</td>
                <td>
                    <asp:TextBox ID="TxtFiltro" runat="server" Width="286px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Button ID="BtnFiltrar" runat="server" onclick="BtnFiltrar_Click" 
                        Text="     Aplicar Filtro    " />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Label ID="LblError" runat="server"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GVListar" runat="server" Height="151px" Width="580px" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
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
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

