<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SeleccionarXML.ascx.cs" Inherits="SeleccionarXML" %>
<table>
    <tr>
        <td colspan="3" align = "center">
            <asp:Label ID="lblTituloGeneral" runat="server" Font-Size="X-Large" ForeColor="#0000C0"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 183px">
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td style="width: 183px">
            <asp:Label ID="lblTituloOrigen" runat="server"></asp:Label></td>
        <td>
        </td>
        <td>
            <asp:Label ID="lblTituloDestino" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 183px">
            <asp:ListBox ID="lstOrigen" runat="server" Height="250px" Width="180px"></asp:ListBox></td>
        <td align = "center">
            <asp:Button ID="btnSeleccionarTodos" runat="server" Text="----->>>" OnClick="btnSeleccionarTodos_Click" /><br />
            <br />
            <asp:Button ID="btnSelecionarUno" runat="server" Text="----->" OnClick="btnSelecionarUno_Click" /><br />
            <br />
            <asp:Button ID="btnDesSeleccionarUno" runat="server" Text="<-----" OnClick="btnDesSeleccionarUno_Click" /><br />
            <br />
            <asp:Button ID="btnDesSeleccionarTodos" runat="server" Text="<<<------" OnClick="btnDesSeleccionarTodos_Click" />
        </td>
        <td>
            <asp:ListBox ID="lstDestino" runat="server" Height="250px" Width="180px"></asp:ListBox></td>
    </tr>
    <tr>
        <td style="width: 183px">
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
</table>
