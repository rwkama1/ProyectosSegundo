<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EjemploLinqToXML.aspx.cs" Inherits="EjemploLinqToXML" %>

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
    
        <strong><em><span class="style2">Ejemplo de LinQ to XML</span></em></strong></div>
    <form id="form1" runat="server">
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
    4) Determinar si alguna Mascota tiene 45 años exactamente&nbsp;
    <asp:Button ID="BtnFiltrar3" runat="server" Text="Filtrar y Mostar" onclick="BtnFiltrar3_Click"  
        />
    <br />
    <br />
    <table style="width: 80%;">
        <tr>
            <td>
    <asp:GridView ID="GVMascotas" runat="server" 
        style="text-align: left" Width="250px">
    </asp:GridView>
    &nbsp;&nbsp;
            </td>
            <td>
&nbsp;&nbsp;
                </td>
        </tr>
    </table>
                <asp:ListBox ID="LBResultado" runat="server" Height="108px" 
        Width="830px">
                </asp:ListBox>
    <br />
    </form>
</body>
</html>
