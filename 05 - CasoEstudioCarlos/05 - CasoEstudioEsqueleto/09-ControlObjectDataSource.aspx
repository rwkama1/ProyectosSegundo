﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="09-ControlObjectDataSource.aspx.cs" Inherits="_09_ControlObjectDataSource" %>

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
    <div>
    
    <p class="style1">
        Ejemplo de Uso de ObjectDataSource</p>
    <br />
            <p>
                <asp:ObjectDataSource ID="OdsArticulos" runat="server" 
                    DeleteMethod="EliminarArt" SelectMethod="ListarArt" TypeName="Persistencia">
                </asp:ObjectDataSource>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" AutoGenerateDeleteButton="True" 
                    DataKeyNames="Codigo" DataSourceID="OdsArticulos" Height="147px" PageSize="1" 
                    Width="184px">
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" 
                            SortExpression="Codigo" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                            SortExpression="Nombre" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" 
                            SortExpression="Precio" />
                    </Columns>
                </asp:GridView>
        </p>
    <asp:Label ID="LblError" runat="server"></asp:Label>
    
    </div>
        <p>
            <asp:LinkButton ID="LBtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
        </p>
    </form>
</body>
</html>