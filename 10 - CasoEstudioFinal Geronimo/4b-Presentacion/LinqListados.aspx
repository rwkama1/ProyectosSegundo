<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="LinqListados.aspx.cs" Inherits="LinqListados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>
        Listado de Prestamos</h1>
    <p>
        Filtrar prestamos por cliente:
        <asp:TextBox ID="txtCliente1" runat="server" ValidationGroup="Cliente"></asp:TextBox>
&nbsp;<asp:Button ID="btnListar1" runat="server" onclick="btnListar1_Click" 
            Text="Listar" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtCliente1" 
                        ErrorMessage="Error, el codigo de cliente no es valido" style="color: #FF0000" 
                        ValidationExpression="[0-9]{1,11}" ValidationGroup="Cliente"></asp:RegularExpressionValidator>
                </p>
    <p>
        Filtrar prestamos por monto: Mayor a
        <asp:TextBox ID="txtMonto1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnListar2" runat="server" onclick="btnListar2_Click" 
            Text="Listar" />
    </p>
    <p>
        Filtrar prestamos por cliente y monto: Cliente:
        <asp:TextBox ID="txtCliente2" runat="server" ValidationGroup="Cliente"></asp:TextBox>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtCliente2" 
                        ErrorMessage="Error, el codigo de cliente no es valido" style="color: #FF0000" 
                        ValidationExpression="[0-9]{1,11}" ValidationGroup="Cliente"></asp:RegularExpressionValidator>
                Monto:
        <asp:TextBox ID="txtMonto2" runat="server"></asp:TextBox>
        <asp:Button ID="btnListar3" runat="server" onclick="btnListar3_Click" 
            style="height: 26px" Text="Listar" />
    </p>
    <p>
        <asp:GridView ID="gvLista" runat="server">
        </asp:GridView>
    </p>
</asp:Content>

