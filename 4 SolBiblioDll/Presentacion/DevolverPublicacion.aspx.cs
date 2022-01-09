using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Logica;
using EntidadesCOmpartidas;



public partial class DevolverPublicacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<Prestamo> oPrestamosActivos = LogicaPrestamos.ListarPrestamosNoDevueltos();
            cboPrestamos.DataSource = oPrestamosActivos;
            cboPrestamos.DataTextField = "Numero";
            cboPrestamos.DataValueField = "Numero";
            cboPrestamos.DataBind();
        }
        catch (ApplicationException ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnDevolver_Click(object sender, EventArgs e)
    {
        //no se verifica si los datos se ingresaron correctamente porque solo se pueden
        //seleccionar los numeros de prestamos no devueltos
        int numero = Convert.ToInt32(cboPrestamos.SelectedValue);
        if (LogicaPrestamos.Devolver(numero))
        {
            lblError.Text = "Se devolvio correctamente el prestamo numero: " + numero;
        }
        else
        {
            lblError.Text = "No se encontro el prestamo numero: " + numero;
        }
    }
}
