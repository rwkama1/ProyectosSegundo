<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploCalendario.aspx.cs" Inherits="EjemploCalendario" %>

<%@ Register src="Calendario.ascx" tagname="Calendario" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">


        .style2
        {
            color: #990033;
            font-weight: bold;
            text-align: center;
            width: 358px;
        }
        .style3
        {
            width: 358px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" border="1" style="width: 22%;">
        <tr>
            <td class="style2">
                Ejemplo Calendario Mejorado</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <uc1:Calendario ID="Calendario1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" class="style3">
                <asp:LinkButton ID="LBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
                    style="text-align: center">Volver</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
