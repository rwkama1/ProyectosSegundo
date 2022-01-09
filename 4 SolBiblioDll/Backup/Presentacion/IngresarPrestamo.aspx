<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IngresarPrestamo.aspx.cs" Inherits="IngresarPrestamo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align: center" bgcolor="antiquewhite">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>
        Ingresar Préstamo<br />
        </strong>
        <br />
        <table>
            <tr>
                <td style="width: 146px">
                    Publicación a Prestar:</td>
                <td style="width: 151px">
                    <asp:DropDownList ID="cboPublicaciones" runat="server" Width="176px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 146px">
                    Días de Préstamo:</td>
                <td style="width: 151px">
                    <asp:TextBox ID="txtDias" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 146px">
                    Fecha de Prestamo</td>
                <td style="width: 151px">
                    <asp:Calendar ID="clnFechaPrestado" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="width: 146px">
                    Nombre de Usuario:</td>
                <td style="width: 151px">
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 26px">
                    <asp:Button ID="btnAgregar" runat="server" Font-Bold="True" OnClick="btnAgregar_Click"
                        Text="Agregar!" /></td>
            </tr>
        </table>
    
    </div>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </form>
</body>
</html>
