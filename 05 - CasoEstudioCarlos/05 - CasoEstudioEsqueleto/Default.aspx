<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <table style="width:100%;">
            <tr>
                <td>
                    Nombre Usuario :</td>
                <td>
                    <asp:LoginName ID="LoginName1" runat="server" BackColor="#9999FF" 
                        Font-Bold="True" ForeColor="#993300" />
                </td>
                <td>
                    Accion Disponible para el usuario</td>
                <td>
                    <asp:LoginStatus ID="LoginStatus1" runat="server" /></td>
                <td>
                    Obtengo Informacion Manualmente:</td>
                <td>
                    <asp:Label ID="lblMembresia" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
        <br />
        <br />
        <br />
    
          <asp:LinkButton ID="lbtn3" runat="server" 
            PostBackUrl="~/03-ControlSiteMapPath.aspx">Ejemplo Control SiteMapPath</asp:LinkButton>
        <br />
            <asp:LinkButton ID="lbtn2" runat="server" 
            PostBackUrl="~/01-ControlTreeView.aspx">Ejemplo Control TreeView</asp:LinkButton>
          <br />
    
        <asp:LinkButton ID="lbtn1" runat="server" PostBackUrl="~/02-ControlMenu.aspx">Ejemplo 
        Control Menu</asp:LinkButton>
      
      
        <br />
        <asp:LinkButton ID="lbtn10" runat="server" 
            PostBackUrl="~/04-ExploracionManual.aspx">Ejemplo Exploracion Manual</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lbtn7" runat="server" 
            PostBackUrl="~/08-ControlSqlDataSource.aspx">Ejemplo Control SqlDataSource</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lbtn8" runat="server" 
            PostBackUrl="~/09-ControlObjectDataSource.aspx">Ejemplo Control ObjectDataSource</asp:LinkButton>
        <br />
                <asp:LinkButton ID="lbtn4" runat="server" 
            PostBackUrl="~/05-ControlDetailsView.aspx">Ejemplo Control DetailsView</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lbtn5" runat="server" 
            PostBackUrl="~/06-ControlFormView.aspx">Ejemplo Control FormView</asp:LinkButton>
        <br />
        <asp:LinkButton ID="lbtn6" runat="server" 
            PostBackUrl="~/07-ControlRepeater.aspx">Ejemplo Control Repeater</asp:LinkButton>
        <br />

        <br />
        &nbsp;&nbsp;&nbsp;
        
    
    </div>
    </form>
<p>
    &nbsp;</p>
</body>
</html>
