using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Consulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            RTCliente.DataSource = Logica.LogicaCliente.ClienteListar();
             RTCliente.DataBind();
           
           
        }

    }
    protected void RTCliente_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Consultar")//La propiedad CommandName del argumento del evento ItemCommand viene cargado con el nombre que se le asigno
        //a dicha propiedad del boton que provoco el evento
        {
            try
            {
                int _resultado=Logica.LogicaCliente
                //int _resultado = Persistencia.EliminarFam(Convert.ToInt32(((TextBox)(e.Item.Controls[1])).Text));
                //en la propiedad Item del argumento del evento
                //vienen cargados todos los controles pertenecientes a la linea donde esta incluido el boton que se hizo click
                //, ahi adentro de la Propiedad Control
                //podemos buscar los datos que queramos, tomar en cuenta que los literales ocupan un lugar
                if (_resultado == 1)
                    LblError.Text = "Eliminacion Correcta";
                else
                    LblError.Text = "Error";
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }
    protected void RTCuenta_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}