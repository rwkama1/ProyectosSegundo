<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Consulta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Repeater ID="RTCliente" runat="server"
    onitemcommand="RTCliente_ItemCommand">
    
      <ItemTemplate>
                <table>
                <tr bgcolor="#00FFCC">
                <td>
              NumCli<asp:TextBox ID="TxtId" runat="server"
                Text='<%# Bind("NumCli") %>'></asp:TextBox>
                <br />
                </td>
                <td>

             NomCli<asp:TextBox ID="TxtNombre" runat="server"
                Text='<%# Bind("NomCli") %>'></asp:TextBox>
                <br />
                </td>
                <td>
                <asp:Button id="Button1" runat="server"
                CommandName="Consultar" style="text-align: center" Text="Consultar" />
              
                </td>
                </tr>
                </table>
                </ItemTemplate>
                <AlternatingItemTemplate>
                <table>
                <tr bgcolor="#66FFFF">
                <td>
              NumCli<asp:TextBox ID="TxtId" runat="server"
                Text='<%# Bind("NumCli") %>'></asp:TextBox>
                <br />
                </td>
                <td>
NomCli<asp:TextBox ID="TxtNombre" runat="server"
                Text='<%# Bind("NomCli") %>'></asp:TextBox>
                <br />
                </td>
                <td>
                <asp:Button id="Button1" runat="server"
                CommandName="Consultar" style="text-align: center" Text="Consultar" />
              
                </td>
                </tr>
                </table>
                </AlternatingItemTemplate>
                 

    </asp:Repeater>
    
    <asp:Label ID="lblerror" runat="server"></asp:Label>
    <asp:Repeater ID="RTCuenta" runat="server" onitemcommand="RTCuenta_ItemCommand">
     <ItemTemplate>
                <table>
                <tr bgcolor="#FFFF99">
                <td>
              NumCta<asp:TextBox ID="TxtCuenta" runat="server"
                Text='<%# Bind("NumCta") %>'></asp:TextBox>
                <br />
                </td>
                <td>

             SaldoCuenta<asp:TextBox ID="TxtSaldo" runat="server"
                Text='<%# Bind("SaldoCuenta") %>'></asp:TextBox>
                <br />
                </td>
                <td>
                <asp:Button id="Button1" runat="server"
                CommandName="Consultar" style="text-align: center" Text="Consultar" />
              
                </td>
                </tr>
                </table>
                </ItemTemplate>
                <AlternatingItemTemplate>
                <table>
                <tr bgcolor="#FF9999">
                <td>
              NumCta<asp:TextBox ID="TxtCuenta" runat="server"
                Text='<%# Bind("NumCta") %>'></asp:TextBox>
                <br />
                </td>
                <td>
SaldoCuenta<asp:TextBox ID="TxtSaldo" runat="server"
                Text='<%# Bind("SaldoCuenta") %>'></asp:TextBox>
                <br />
                </td>
                <td>
                <asp:Button id="Button1" runat="server"
                CommandName="Consultar" style="text-align: center" Text="Consultar" />
              
                </td>
                </tr>
                </table>
                </AlternatingItemTemplate>
                 


    </asp:Repeater>
    
    </form>
</body>
</html>
