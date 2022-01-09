using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;

public partial class LinqListados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Prestamo> prestamos = FabricaLogica.GetLogicaPrestamo().Listar();

            Session["Prestamos"] = prestamos;

            gvLista.DataSource = prestamos;
            gvLista.DataBind();
        }
    }
    protected void btnListar1_Click(object sender, EventArgs e)
    {
        List<Prestamo> prestamos = (List<Prestamo>)Session["Prestamos"];

        List<Prestamo> resultado = (from prestamo in prestamos
                                    where prestamo.Cliente.NumCli == Convert.ToInt32(txtCliente1.Text.Trim())
                                    select prestamo).ToList<Prestamo>();

        LimpiarControles();
        gvLista.DataSource = resultado;
        gvLista.DataBind();
        
    }
    protected void btnListar2_Click(object sender, EventArgs e)
    {
        List<Prestamo> prestamos = (List<Prestamo>)Session["Prestamos"];

        List<Prestamo> resultado = (from prestamo in prestamos
                                    where prestamo.Monto > Convert.ToDouble(txtMonto1.Text.Trim())
                                    select prestamo).ToList<Prestamo>();

        LimpiarControles();
        gvLista.DataSource = resultado;
        gvLista.DataBind();
    }
    protected void btnListar3_Click(object sender, EventArgs e)
    {
        List<Prestamo> prestamos = (List<Prestamo>)Session["Prestamos"];

        List<Prestamo> resultado = (from prestamo in prestamos
                                    where prestamo.Monto > Convert.ToDouble(txtMonto2.Text.Trim()) && prestamo.Cliente.NumCli == Convert.ToInt32(txtCliente2.Text.Trim())
                                    select prestamo).ToList<Prestamo>();

        LimpiarControles();
        gvLista.DataSource = resultado;
        gvLista.DataBind();
    }

    protected void LimpiarControles()
    {
        txtCliente1.Text = "";
        txtCliente2.Text = "";
        txtMonto1.Text = "";
        txtMonto2.Text = "";
    }
}