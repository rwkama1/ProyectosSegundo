<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ABCC.aspx.cs" Inherits="ABCC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 519px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
          <em><strong>CUENTA CORRIENTE<br />
        <br />
        </strong></em></div>
    <table style="width: 77%;" border="1" align="center">
        <tr>
            <td class="style10" colspan="2">
                Cliente:</td>
            <td class="style9" colspan="2">
                <asp:TextBox ID="TxtCliente" runat="server" Width="117px"></asp:TextBox>
            &nbsp;<asp:Button ID="BtnBuscarCliente" runat="server" Text="Buscar" 
                    style="text-align: center" Width="58px" onclick="BtnBuscarCliente_Click" />
            &nbsp;<asp:Label ID="LblCliente" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style10" colspan="2">
                Monto Minimo:</td>
            <td class="style9" colspan="2">
                <asp:TextBox ID="TxtMinimo" runat="server" Width="186px"></asp:TextBox>
            </td>
 
        </tr>
        <tr>
            <td class="style3" colspan="4">
                <asp:Label ID="LblError" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8">
            &nbsp;</td>
            <td class="style5" colspan="2">
                <asp:Button ID="BtnAlta" runat="server" Text="Alta" 
                    onclick="BtnAlta_Click" style="text-align: center" Width="58px" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnRefresh" runat="server" onclick="BtnRefresh_Click" 
                    Text="Limpiar" />
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
    </table>
    <p style="text-align: center">

          <asp:GridView ID="GrVCuentas" runat="server" Width="423px" 
              onselectedindexchanged="GrVCuentas_SelectedIndexChanged">
              <Columns>
                  <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
              </Columns>
          </asp:GridView>

    </p>   
    <br />
</asp:Content>

