<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <br />
        <br />
        <br />
        <table style="width: 36%;" align="center">
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        PostBackUrl="~/EjemploLinqToObject.aspx">Ejemplo LinQ to Object</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                        PostBackUrl="~/EjemploLinqToXML.aspx">Ejemplo LinQ to XML</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton3" runat="server" 
                        PostBackUrl="~/EjemploLinqToAdo.aspx">Ejemplo LinQ to Ado (DataSet)</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
