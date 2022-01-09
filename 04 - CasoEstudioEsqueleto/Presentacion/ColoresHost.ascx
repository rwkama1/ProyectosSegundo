<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColoresHost.ascx.cs" Inherits="ColoresHost" %>
<style type="text/css">
    .style1
    {
        width: 809px;
    }
    .style2
    {
        width: 809px;
        height: 23px;
    }
    .style3
    {
        height: 23px;
    }
</style>

<table style="width: 100%; height: 103px;">
    <tr>
        <td class="style1">
            <asp:Label ID="lbltitulo" runat="server" 
                Text="Ejemplo con Manejo de Host del control"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Button ID="btnatras" runat="server" onclick="btnatras_Click" 
                Text="&lt;&lt;" Width="42px" />
            <asp:TextBox ID="txtcolor" runat="server" Height="25px" Width="154px"></asp:TextBox>
            <asp:Button ID="btnadelante" runat="server" onclick="btnadelante_Click" 
                Text="&gt;&gt;" Width="45px" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="btnaplicar" runat="server" Height="26px" 
                onclick="btnaplicar_Click" Text="Aplicame" Width="107px" />
            <asp:Button ID="btnaplicarhost" runat="server" onclick="btnaplicarhost_Click" 
                Text="Aplicar Host" Width="114px" />
        </td>
        <td class="style3">
        </td>
        <td class="style3">
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="lblerror" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <br />
        </td>
    </tr>
</table>

