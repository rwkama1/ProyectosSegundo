<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClienteListado.aspx.cs" Inherits="ClienteListado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            text-align: center;
        }
        .style1
        {
            color: #009933;
            text-decoration: underline;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span class="style1"><strong>Listado de Clientes</strong></span><br />
        <br />
        <br />
        <br />
        <table align="center" style="width: 39%;">
            <tr>
                <td style="text-align: left">
    
    <asp:GridView ID="DGVListado" runat="server" Height="194px" Width="511px" 
                        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NumCli" HeaderText="Numero"></asp:BoundField>
            <asp:BoundField DataField="NomCli" HeaderText="Nombre"></asp:BoundField>
            <asp:BoundField DataField="DirCli" HeaderText="Direccion"></asp:BoundField>
        </Columns>
    </asp:GridView>
   
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:HyperLink ID="HLBVolver" runat="server" NavigateUrl="~/Default.aspx">Volver</asp:HyperLink>
        <br />
    
   </div>

    </form>
</body>
</html>
