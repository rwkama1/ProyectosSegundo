<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="SeleccionarXML.ascx" TagName="SeleccionarXML" TagPrefix="uc2" %>

<%@ Register Src="Calendario.ascx" TagName="Calendario" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
            <table style="width: 569px">
                <tr>
                    <td>
                        <b><span style="color: #cc0066">Ejemplo de uso del Calendario</span></b></td>
                    <td>
                        <span style="color: #ffffff">
                      aaaaa</span>
                    </td>
                    <td>
                        <b><span style="color: #009900">Ejemplo de uso de SeleccionarXML</span></b>
                        </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="width: 90px">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 314px">
        <uc1:Calendario ID="Calendario" runat="server" />
                        <br />
        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
        <asp:Button ID="btnVer" runat="server" OnClick="btnVer_Click" Text="Ver Fecha" /></td>
                    <td style="width: 90px">
                    </td>
                    <td>
                        <uc2:SeleccionarXML ID="SeleccionarXML1" runat="server" />
                        <br />
                        <asp:Button ID="BtnCrearXML" runat="server" Text="Actualizar XML" OnClick="BtnCrearXML_Click" /></td>
                </tr>
            </table>
        <br />
        <br />
        &nbsp;<br />
        <br />
    
    </div>
    </form>
</body>
</html>
