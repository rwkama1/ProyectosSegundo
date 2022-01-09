<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
            color: #FF0000;
        }
        .style2
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style2">
    
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem Text="Mantenimiento" Value="Mantenimiento">
                    <asp:MenuItem NavigateUrl="~/ClienteAbm.aspx" Text="ABM Cliente" 
                        Value="ABM Cliente"></asp:MenuItem>
                    <asp:MenuItem Text="Alta Cuenta Corriente" Value="Alta Cuenta Corriente" 
                        NavigateUrl="~/CuentaCorrienteA.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Alta Movimiento" Value="Alta Movimiento" 
                        NavigateUrl="~/MovimientoAlta.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Listados" Value="Listados">
                    <asp:MenuItem NavigateUrl="~/ClienteListado.aspx" Text="Todos los Clientes" 
                        Value="Todos los Clientes"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <div class="style2">
            <br />
            <br />
            <strong>
            <span class="style1">Bienvenidos<br />
            <br />
            Analista Programador .Net<br />
            Diseño de Aplicaciones Web</span><br class="style1" />
            <br class="style1" />
            <span class="style1">Caso de Estudio&nbsp;para</span><br class="style1" />
            <span class="style1">Repaso General</span></strong></div>
    
    </div>
    </form>
</body>
</html>
