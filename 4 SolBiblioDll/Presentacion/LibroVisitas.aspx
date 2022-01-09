<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="LibroVisitas.aspx.cs" Inherits="LibroVisitas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Libro de Visitas</title>
</head>
<body style="text-align: center" bgcolor="antiquewhite">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span>Libro de Visitas<br />
            <br />
        </span></strong>
    
    </div>
        <table style="width: 419px; height: 82px">
            <tr>
                <td style="width: 187px; text-align: right">
                    Nombre:</td>
                <td style="width: 9px">
                </td>
                <td style="text-align: left; width: 263px;">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="vertical-align: top; width: 187px; height: 107px; text-align: right">
                    <asp:Label ID="lblComentario" runat="server" Text="Comentario:"></asp:Label></td>
                <td style="width: 9px; height: 107px">
                </td>
                <td style="height: 107px; text-align: left; width: 263px;">
                    <asp:TextBox ID="txtComentario" runat="server" Height="90px" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar"
                        Width="64px" /></td>
            </tr>
        </table>
        <br />
        &nbsp;
        <asp:Label ID="lblError" runat="server" Width="224px"></asp:Label><br />
        <br />
        <br />
        <br />
        <asp:GridView ID="gdLibro" runat="server" AutoGenerateColumns="False" Width="648px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" />
                <asp:BoundField DataField="Comentario" HeaderText="Comentario" ReadOnly="True" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </form>
</body>
</html>
