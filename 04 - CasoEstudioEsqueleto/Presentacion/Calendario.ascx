<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calendario.ascx.cs" Inherits="Calendario" %>
<style type="text/css">
    .style1
    {
        width: 328px;
    }
</style>

<table style="width:100%;">
    <tr>
        <td class="style1">
            <asp:Button ID="btnañoatras" runat="server" Height="26px" Text="&lt;Año" 
                Width="91px" onclick="btnañoatras_Click" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:LinkButton ID="lbtnenero" runat="server" onclick="lbtnenero_Click">1</asp:LinkButton>
            <asp:LinkButton ID="lbtnfebrero" runat="server">2</asp:LinkButton>
            <asp:LinkButton ID="lbtnmarzo" runat="server">3</asp:LinkButton>
            <asp:LinkButton ID="lbtnabril" runat="server">4</asp:LinkButton>
            <asp:LinkButton ID="lbtnmayo" runat="server">5</asp:LinkButton>
            <asp:LinkButton ID="lbtnjunio" runat="server">6</asp:LinkButton>
            <asp:LinkButton ID="lbtnjulio" runat="server" onclick="LinkButton7_Click">7</asp:LinkButton>
            <asp:LinkButton ID="lbtnagosto" runat="server">8</asp:LinkButton>
            <asp:LinkButton ID="lbtnsetiembre" runat="server">9</asp:LinkButton>
            <asp:LinkButton ID="lbtnoctubre" runat="server">10</asp:LinkButton>
            <asp:LinkButton ID="lbtnnoviembre" runat="server">11</asp:LinkButton>
            <asp:LinkButton ID="lbtndiciembre" runat="server" onclick="LinkButton12_Click">12</asp:LinkButton>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Button ID="btnañoadelante" runat="server" Height="29px" Text="Año&gt;" 
                Width="96px" onclick="btnañoadelante_Click" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Calendar ID="cfecha" runat="server"></asp:Calendar>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

