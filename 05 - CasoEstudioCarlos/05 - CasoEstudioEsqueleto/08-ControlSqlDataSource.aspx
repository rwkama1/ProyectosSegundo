<%@ Page Language="C#" AutoEventWireup="true" CodeFile="08-ControlSqlDataSource.aspx.cs" Inherits="_08_ControlSqlDataSource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            color: #FF0000;
            font-weight: bold;
            text-align: center;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <p class="style1">
        Ejemplo de Uso de SqlDataSource</p>
    <br />
    <table style="width: 36%;">
        <tr>
            <td>
                Codigo:                 <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" 
                    onclick="BtnEliminar_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="BtnConsulta" runat="server" onclick="BtnConsulta_Click" 
        Text="Consultar a Base de Datos" />
    <p>
        <asp:GridView ID="GVArticulos" runat="server" DataSourceID="SdsArticulos">
        </asp:GridView>
        <asp:SqlDataSource ID="SdsArticulos" runat="server" 
            ConnectionString="Data Source=. ;Initial Catalog = Ventas; Integrated Security=true" 
            DeleteCommand="Delete from Articulos where CodArt=@codigo" 
            ProviderName="System.Data.SqlClient" SelectCommand="select * from Articulos">
            <DeleteParameters>
                <asp:ControlParameter ControlID="txtCodigo" DefaultValue="0" Name="codigo" 
                    PropertyName="Text" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </p>
    <asp:Label ID="LblError" runat="server"></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="LBtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </form>
</body>
</html>
