<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style4
        {
            width: 837px;
            text-align: center;
            color: #990033;
            font-weight: 700;
            font-style: italic;
            text-decoration: underline;
            font-size: xx-large;
        }
        .style5
        {
            color: #FF3399;
            font-weight: bold;
            font-style: italic;
            text-decoration: underline;
        }
        .style6
        {
            color: #FF3399;
            font-weight: bold;
            font-style: italic;
            text-decoration: underline;
            width: 238px;
        }
        .style7
        {
            width: 238px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server"> 
        <div style="height: 369px; width: 1015px" >
            <table align="left" style="width: 100%; height: 115px;">
                <tr>
                    <td class="style4">
                        Ejemplo Final&nbsp; 
                        -
                        Diseño de Aplicaciones Web<br />
                        Analista Programador</td>
                    <td style="text-align: right">
                        <br />
                        <asp:Login ID="Logueo" runat="server" DisplayRememberMe="False" 
                            LoginButtonText="Login" PasswordLabelText="" RenderOuterTable="False" 
                            TitleText="Ingreso" UserNameLabelText="" 
                            onauthenticate="Logueo_Authenticate">
                        </asp:Login>
                        <br />
                        <asp:Label ID="LblError" runat="server"></asp:Label>
                    </td>
                </tr>
                </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <table border="1" style="width:100%;">
                <tr>
                    <td class="style6">
                        Elementos de la Solucion</td>
                    <td class="style5">
                        Funcionalidad Incluida</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        Arquitectura</td>
                    <td>
                        1.- Capas<br />
                        2.- Sitio Web</td>
                </tr>
                <tr>
                    <td class="style7">
                        Patrones Aplicados</td>
                    <td>
                        1. Se aplicaron patrones a Logica y Persistencia<br />
                        2.- Patron Fabrica<br />
                        3.- Patron Singleton<br />
                        4.- Clase que se consume unicamente dentro del paquete - No se toma en cuenta en 
                        los patrones (Persistencia Telefonos)
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Elementos de Diseño</td>
                    <td>
                        1.- Manejo de Herencia a Nivel de Logica y Persistencia (Cuentas Bancarias)<br />
                        2.- Control Costumizado de tipo Composite Control (ManejoTelefonos)<br />
                        3.- Manejo de Eventos Manualmente (Control Costumizado)<br />
                        4.- Transaccion a&nbsp; nivel logico (por cada alta/modificacion de cliente, 
                        multiples altas de telefonos)<br />
                        5.- Manejo de Properties Virtuales en Herencia de Clases (Clase Cuentas y sus 
                        Derivadas)</td>
                </tr>
                <tr>
                    <td class="style7">
                        Base de Datos</td>
                    <td>
                        1.- Manejo de SP con y sin transacciones<br />
                        2.- Restricciones definidas a nivel de esquema</td>
                </tr>
                <tr>
                    <td class="style7">
                        Otros</td>
                    <td>
                        1.- Consultas de Linq</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        Pagina</td>
                    <td class="style5">
                        Funcionalidad Incluida</td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        Default</td>
                    <td>
                        1.- Manejo manual de controles de Logueo<br />
                        2.- OJO!!!!!!!!! Logueo de UNICO usuario</td>
                </tr>
                <tr>
                    <td class="style7">
                        Master Page</td>
                    <td>
                        1.- Manejo de Usuarios<br />
                        2.- Control de Navegacion (TreeView - Menu Principal)</td>
                </tr>
                <tr>
                    <td class="style7">
                        ABM Clientes</td>
                    <td>
                        1.- ABM y Consulta conjunta de un registro (Cliente)<br />
                        2.- Inclusion de elementos dependientes del registro principal (Telefonos)<br />
                        3.- Control Costumizado (manejo de los telefonos de un cliente)</td>
                </tr>
                <tr>
                    <td class="style7">
                        Listado Clientes</td>
                    <td>
                        1.- Uso de Repeater (muestra de clientes)<br />
                        2.- Uso de consulta en cascada (dado un cliente, se despliegan sus cuentas) </td>
                </tr>
                <tr>
                    <td class="style7">
                        AB Cuenta Corriente</td>
                    <td>
                        1.- Eliminacion de elemento apartir de la seleccion en Grilla (Cuenta)</td>
                </tr>
                <tr>
                    <td class="style7">
                        AMovimientos</td>
                    <td>
                        1.- Verificacion en logica de posibilidad de realizar accion (Verica en logica 
                        Movimiento si se puede realizar o no el mov)</td>
                </tr>
                <tr>
                    <td class="style7">
                        Listado Movimientos</td>
                    <td>
                        1.- Uso de LinQ para multiples filtros</td>
                </tr>
            </table>
            <br />
            </div>
    
    </form>
</body>
</html>
