<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploLetras.aspx.cs" Inherits="EjemploLetras" %>



<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>



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
            width: 322px;
        }
        .style3
        {
            width: 322px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" border="1" style="width: 41%;">
        <tr>
            <td class="style2">
                Ejemplo Control Composite</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">

                <cc1:Letras ID="Letras1" runat="server" />
                <cc1:Letras ID="Letras2" runat="server" />

                <cc1:Letras ID="Letras3" runat="server" />
                <cc1:Letras ID="Letras4" runat="server" />
                <cc1:Letras ID="Letras5" runat="server" />

            </td>
        </tr>
        <tr>
            <td class="style3">
                <cc1:MiFecha ID="MiFecha1" runat="server" />
                <cc1:MiFecha ID="MiFecha2" runat="server" />
            </td>
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
