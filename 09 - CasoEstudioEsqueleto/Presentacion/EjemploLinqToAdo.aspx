<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploLinqToAdo.aspx.cs" Inherits="EjemploLinqToAdo" %>

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
    <div class="style1">
    
        <strong><em><span class="style2">Ejemplo de LinQ to ADO (DataSet)</span></em></strong></div>
    <form id="form2" runat="server">
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    <br />
    <br />
    1) Cargar en memoria todas las Mascotas - Mostrarlas en la 
    grilla&nbsp;
    <asp:Button ID="BtnCargaInicial" runat="server" onclick="BtnCargaInicial_Click" 
        Text="Cargar y Mostar" />
    <br />
    2) Filtrar: solo mostrar aquellas 
    mascotas que tienen mas de 5 años en el listbox&nbsp;
    <asp:Button ID="BtnFiltrar1" runat="server" Text="Filtrar y Mostar" onclick="BtnFiltrar1_Click" 
        />
    <br />
    3) Filtrar: solo mostrar la Mascota mas 
    viejita en el ListBox&nbsp;
    <asp:Button ID="BtnFiltrar2" runat="server" Text="Filtrar y Mostar" onclick="BtnFiltrar2_Click"  
        />
    <br />
    4) Determinar si alguna Mascota tiene 15 años exactamente&nbsp;
    <asp:Button ID="BtnFiltrar3" runat="server" Text="Filtrar y Mostar" onclick="BtnFiltrar3_Click"  
        />
    <br />
    5) Ejemplo con Join de tablas: se levanta por separado las tablas de dueños y 
    mascotas, y se muestran los dueños con mascotas unicamente
    <asp:Button ID="BtnFiltrar4" runat="server" Text="Filtrar y Mostar" onclick="BtnFiltrar4_Click"   
        />
    <br />
    6) Ejemplo contar: se muestran los dueños con su cantidad de mascotas&nbsp;
    <asp:Button ID="BtnFiltrar5" runat="server" Text="Filtrar y Mostar" onclick="BtnFiltrar5_Click" 
        />
    &nbsp;<br />
    <br />
    <table style="width: 55%;">
        <tr>
            <td>
    <asp:GridView ID="GVMostrarDesdeBD" runat="server" 
        style="text-align: left" Width="653px">
    </asp:GridView>
    &nbsp;&nbsp;
            </td>
            <td>
&nbsp;&nbsp;
                <asp:ListBox ID="LBResultado" runat="server" Height="108px" Width="210px">
                </asp:ListBox>
            </td>
        </tr>
    </table>
    </form>
   
</body>
</html>
