<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DevolverPublicacion.aspx.cs" Inherits="DevolverPublicacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align: center" bgcolor="antiquewhite">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>
        Devolver Publicación</strong><br />
        <br />
        <table>
            <tr>
                <td style="width: 140px; height: 24px;">
                    Número de Préstamo:</td>
                <td style="width: 185px; height: 24px;">
                    <asp:DropDownList ID="cboPrestamos" runat="server" Width="160px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnDevolver" runat="server" Font-Bold="True" OnClick="btnDevolver_Click"
                        Text="Devolver!" /></td>
            </tr>
        </table>
        <br />
    
    </div>
        <asp:Label ID="lblError" runat="server"></asp:Label>&nbsp;<br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </form>
</body>
</html>
