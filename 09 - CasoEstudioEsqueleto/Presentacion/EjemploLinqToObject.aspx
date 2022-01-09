<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploLinqToObject.aspx.cs" Inherits="EjemploLinqToObject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            text-decoration: underline;
            font-size: xx-large;
            color: #660033;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        <strong><em><span class="style2">Ejemplo de LinQ to Object</span></em></strong></div>
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    <br />
    <br />
    1) Cargar en memoria todos los&nbsp; Dueños de Mascotas - Mostrarlos en la 
    grilla&nbsp;
    <asp:Button ID="BtnCargaInicial" runat="server" onclick="BtnCargaInicial_Click" 
        Text="Cargar y Mostar" />
    <br />
    2) Filtrar los dueños: solo mostrar aquellos que tienen mas de 3 mascotas
    en el listbox&nbsp;
    <asp:Button ID="BtnFiltrar1" runat="server" Text="Filtrar y Mostar" 
        onclick="BtnFiltrar1_Click" />
    <br />
    3) Filtrar los dueños: solo mostrar aquellos menos de 6 caracteres en su nombre&nbsp;
    <asp:Button ID="BtnFiltrar2" runat="server" Text="Filtrar y Mostar" onclick="BtnFiltrar2_Click" 
        />
    <br />
    <br />
    <table style="width: 55%;">
        <tr>
            <td>
    <asp:GridView ID="GVDueños" runat="server" AutoGenerateColumns="False" 
        style="text-align: left" Width="250px">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="CantMascotas" HeaderText="Total de Mascotas" />
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;
            </td>
            <td>
&nbsp;&nbsp;
                <asp:ListBox ID="LBResultadoDueño" runat="server" Height="108px" Width="210px">
                </asp:ListBox>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    1) Cargar en memoria todas las Mascotas - Mostrarlas en la 
    grilla&nbsp;
    <asp:Button ID="BtnCargaInicialMAscota" runat="server" 
        Text="Cargar y Mostar" onclick="BtnCargaInicialMAscota_Click" />
    <br />
    2) Filtrar las mascotas: solo mostrar aquellas que tienen mas de 10 años en el listbox&nbsp; 
     <asp:Button ID="BtnFiltrar3" runat="server" Text="Filtrar y Mostar" onclick="BtnFiltrar3_Click" 
        />
    <br />
   3) 
    Solo mostrar las mascotas que son perritos en la grilla&nbsp;
    <asp:Button ID="BtnFiltrar4" runat="server" Text="Filtrar y Mostar" onclick="BtnFiltrar4_Click"  
        />
    <br />
    <br />
    <table style="width: 55%;">
        <tr>
            <td>
    <asp:GridView ID="GVMascota" runat="server" AutoGenerateColumns="False" 
        style="text-align: left" Width="335px">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Raza" HeaderText="Raza" />
            <asp:BoundField DataField="Edad" HeaderText="Edad" />
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;
            </td>
            <td>
&nbsp;&nbsp;
                <asp:ListBox ID="LBResultadoMascota" runat="server" Height="108px" 
                    Width="247px">
                </asp:ListBox>
            </td>
        </tr>
    </table>
    <br />
    </form>
</body>
</html>
