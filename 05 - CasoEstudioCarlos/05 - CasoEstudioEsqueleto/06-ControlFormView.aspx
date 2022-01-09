<%@ Page Language="C#" AutoEventWireup="true" CodeFile="06-ControlFormView.aspx.cs" Inherits="_06_ControlFormView" %>

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
    <form id="form2" runat="server">
    <div>
    
    <div>
    
    <p class="style1">
        Ejemplo de Uso de FormView</p>
                <asp:SqlDataSource ID="SdsArticulos" runat="server" 
                    ConnectionString="Data Source=. ;Initial Catalog = Ventas; Integrated Security=true" 
                    DeleteCommand="Delete from Articulos where CodArt=@codigo" 
                    ProviderName="System.Data.SqlClient" SelectCommand="select * from Articulos">
                    <DeleteParameters>
                        <asp:ControlParameter ControlID="FVArticulos" DefaultValue="0" Name="codigo" 
                            PropertyName="SelectedValue" />
                    </DeleteParameters>
                </asp:SqlDataSource>
    <asp:Label ID="LblError" runat="server"></asp:Label>
    
        <asp:FormView ID="FVArticulos" runat="server" AllowPaging="True" 
            Caption="Articulo" DataKeyNames="CodArt" DataSourceID="SdsArticulos">
            <ItemTemplate>
                <asp:Label ID="lblcodigo" runat="server" Text="Codigo"></asp:Label>
                <asp:TextBox ID="txtcodigo" runat="server" Text='<%# Bind("CodArt") %>'></asp:TextBox>
                <br />
                <asp:Label ID="lblnombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtnombre" runat="server" Text='<%# Bind("NomArt") %>'></asp:TextBox>
                <br />
                <asp:Label ID="lblprecio" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox ID="txtprecio" runat="server" Text='<%# Bind("PreArt") %>'></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Borrar" />
            </ItemTemplate>
        </asp:FormView>
    
    </div>
        <p>
            <asp:LinkButton ID="LBtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
        </p>
    
    </div>
    </form>

</body>
</html>
