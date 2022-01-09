<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GrillasArticulos.ascx.cs" Inherits="GrillasArticulos" %>
<table style="width: 100%; height: 124px;">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:GridView ID="GVarticulos" runat="server" AutoGenerateColumns="False" 
                Height="215px" Width="291px">
                <Columns>
                    <asp:BoundField DataField="CodArt" Visible="False" />
                    <asp:BoundField DataField="NomArt" HeaderText="Nombre" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

