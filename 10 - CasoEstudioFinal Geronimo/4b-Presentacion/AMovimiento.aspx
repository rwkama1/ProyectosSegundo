<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="AMovimiento.aspx.cs" Inherits="AMovimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
                <em><strong>Movimientos de Cuentas</strong></em>
    <table style="width: 55%;" border="1" align="center">
        <tr>
            <td colspan="1">
                Cuenta:</td>
            <td class="style10">
                <asp:TextBox ID="TxtCuentaN" runat="server" Width="105px" 
                    ></asp:TextBox>
            &nbsp;&nbsp;<asp:Button ID="BtnBuscarCuenta" runat="server" Text="Buscar" 
                    onclick="BtnBuscarCuenta_Click" />
                <br />
                &nbsp;
                <asp:Label ID="LblCuenta" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style8" colspan="1">
                Monto:</td>
            <td>
                <asp:TextBox ID="TxtMonto" runat="server" Width="110px"></asp:TextBox>
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
                <asp:Button ID="BtnAlta" runat="server" Text="       Alta             " 
                    onclick="BtnAlta_Click" style="text-align: center" />
            &nbsp;&nbsp;
                <asp:Button ID="BtnRefresh" runat="server" Text="       Limpiar     " 
                   style="text-align: center" onclick="BtnRefresh_Click" />
            </td>
        </tr>
    </table>
    </p>
</asp:Content>

