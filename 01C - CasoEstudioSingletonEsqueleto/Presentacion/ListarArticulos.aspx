<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarArticulos.aspx.cs" Inherits="ListarArticulos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            color: #FF0000;
            font-weight: bold;
        }
        .style2
        {
            text-align: center;
        }
    </style>
</head>
<body bgcolor="#ffe1c1">
    <form id="form1" runat="server">
    <div class="style2">
        <span class="style1">Listado Completo de Articulos<br />
        <br />
        </span><br />
    </div>
    <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False" 
        Height="197px"  
        style="text-align: center" Width="456px">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
        </Columns>
    </asp:GridView>
    <p>
        &nbsp;</p>
    <p style="text-align: center">
        <asp:Label ID="lblError" runat="server" ForeColor="Red" 
            style="text-align: center" Width="386px"></asp:Label>
    </p>
    <p style="text-align: center">
        <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </p>
    </form>
</body>
</html>
