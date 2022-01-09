<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ABMPrestamos.aspx.cs" Inherits="ABMPrestamos" %>

<%@ Register assembly="ControlesWeb" namespace="ControlesWeb" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <em><strong>Prestamos<br />
        <br /></strong></em>
        <table align="center" border="1" style="width: 74%;">
            <tr>
                <td class="style5" colspan="1">
                    Codigo:</td>
                <td colspan="3" class="style5">
                    <asp:TextBox ID="txtCodigo" runat="server" Width="183px" 
                        ValidationGroup="Codigo"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtCodigo" 
                        ErrorMessage="Error en el formato del codigo ingresado" style="color: #FF0000" 
                        ValidationExpression="[0-9]{9,20}" ValidationGroup="Codigo"></asp:RegularExpressionValidator>
                </td>
                <td class="style5" colspan="1">
                    <asp:Button ID="BtnBuscar" runat="server" onclick="BtnBusco_Click" 
                    Text="Buscar" ValidationGroup="Codigo" />
            &nbsp;<br /></td>
            </tr>
            <tr>
                <td class="style8" colspan="1">
                    Cliente:</td>
                <td colspan="3">
                    <asp:TextBox ID="txtCliente" runat="server" Width="186px" Enabled="False"></asp:TextBox>
                </td>
                <td class="style9" colspan="1">
                </td>
            </tr>
            <tr>
                <td class="style8" colspan="1">
                    Fecha:</td>
                <td colspan="3">
                    <asp:TextBox ID="txtFecha" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                </td>
                <td class="style9" colspan="1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8" colspan="1">
                    Monto:</td>
                <td colspan="3">
                    <asp:TextBox ID="txtMonto" runat="server" Width="106px" Enabled="False"></asp:TextBox>
                </td>
                <td class="style9" colspan="1">
                </td>
            </tr>
            <tr>
                <td class="style8" colspan="1">
                    Cuotas:</td>
                <td colspan="3">
                    <asp:TextBox ID="txtCuotas" runat="server" Width="55px" Enabled="False"></asp:TextBox>
                </td>
                <td class="style9" colspan="1">
                &nbsp;</td>
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
                    <asp:Button ID="btnAlta" runat="server" Enabled="False" onclick="BtnAlta_Click" 
                    Text="Alta" Height="26px" Width="36px" />
                </td>
                <td class="style1">
                    <asp:Button ID="btnBaja" runat="server" Enabled="False" onclick="BtnBaja_Click" 
                    Text="Baja" />
                </td>
                <td>
                    <asp:Button ID="btnModificar" runat="server" Enabled="False" 
                    onclick="BtnModificar_Click" Text="Modificar" />
                </td>
                <td class="style9">
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar Pantalla" />
                </td>
            </tr>
        </table>
    <p style="text-align: center">
        &nbsp;</p>
</asp:Content>

