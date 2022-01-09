<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="antiquewhite">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-size: 11pt; line-height: 115%; font-family: 'Calibri','sans-serif';
            mso-fareast-font-family: Calibri; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: ES-UY;
            mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><strong>Página Principal</strong><br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/AgregarPublicacionPapel.aspx">Agregar Publicación en Papel</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/AgregarPublicacionDigital.aspx">Agregar Publicación Digital</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/ListarPublicaciones.aspx">Listar Publicaciones</asp:LinkButton><br />
            <br />
            <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/IngresarPrestamo.aspx">Ingresar Préstamo</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/DevolverPublicacion.aspx">Devolver Publicación</asp:LinkButton><br />
            <br />
            <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/ListarTodosLosPrestamos.aspx">Listar Todos los Préstamos</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="~/ListarPrestamosVencidos.aspx">Listar Préstamos Vencidos</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="~/LibroVisitas.aspx">Libro de Visitas (XML)</asp:LinkButton><br />
            <br />
            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="~/Libro">Prueba de Error no existe la pagina</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="LinkButton10" runat="server" PostBackUrl="~/EjemploCompletoGrilla.aspx">Ejemplo Grillas y Colecciones</asp:LinkButton><br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </span>
    
    </div>
    </form>
</body>
</html>
