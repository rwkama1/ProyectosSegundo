using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ABMPrestamos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Prestamo"] = null;
        }
    }
    private void LimpiarControles()
    {
        txtCodigo.Text = "";
        txtCodigo.Enabled = true;
        txtCliente.Text = "";
        txtCliente.Enabled = false;
        txtCuotas.Text = "";
        txtCuotas.Enabled = false;
        txtMonto.Text = "";
        txtMonto.Enabled = false;
        txtFecha.Enabled = false;
        txtFecha.Text = "";

        btnAlta.Enabled = false;
        btnModificar.Enabled = false;
        btnBaja.Enabled = false;

        BtnBuscar.Enabled = true;
    }
    protected void BtnBusco_Click(object sender, EventArgs e)
    {
        try
        {
            Prestamo prestamo = null;

            string codigo = txtCodigo.Text.Trim();

            if (FabricaLogica.GetLogicaPrestamo().Buscar(txtCliente.Text = codigo.Substring(8, codigo.Length - 8)) == null)
            {
                throw new Exception("No existe el Numero de cliente al final del codigo");
            }

            prestamo = FabricaLogica.GetLogicaPrestamo().Buscar(codigo);

            LimpiarControles();

            if (prestamo == null)
            {
                btnAlta.Enabled = true;
                txtCodigo.Enabled = false;
                BtnBuscar.Enabled = false;
                txtCliente.Enabled = false;
                txtCliente.Text = codigo.Substring(8,codigo.Length - 8);
                txtCuotas.Enabled = true;
                txtFecha.Enabled = false;
                txtFecha.Text = codigo.Substring(0, 4) + "/" + codigo.Substring(4, 2) + "/" + codigo.Substring(6, 2);
                txtMonto.Enabled = true;
            }
            else
            {

                btnModificar.Enabled = true;
                btnBaja.Enabled = true;
                Session["Prestamo"] = prestamo;
                txtCodigo.Text = prestamo.Codigo;
                txtCliente.Text = prestamo.Cliente.NumCli.ToString();
                txtMonto.Text = prestamo.Monto.ToString();
                txtCuotas.Text = prestamo.Cuotas.ToString();
                txtFecha.Text = prestamo.Codigo.Substring(0, 4) + "/" + prestamo.Codigo.Substring(4, 2) + "/" + prestamo.Codigo.Substring(6, 2);
                txtCliente.Enabled = false;
                txtCuotas.Enabled = true;
                txtFecha.Enabled = false;
                txtMonto.Enabled = true;
                txtCodigo.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            Prestamo prestamo = null;
            prestamo = new Prestamo(txtFecha.Text.Trim().Substring(0, 4) + txtFecha.Text.Trim().Substring(5, 2) + txtFecha.Text.Trim().Substring(8, 2) + txtCliente.Text, FabricaLogica.GetLogicaCliente().Buscar(Convert.ToInt32(txtCliente.Text)), Convert.ToDouble(txtMonto.Text), Convert.ToInt32(txtCuotas.Text));
            
            Logica.FabricaLogica.GetLogicaPrestamo().Alta(prestamo);
            
            this.LimpiarControles();

            LblError.Text = "Alta con exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Prestamo prestamo = (Prestamo)Session["Prestamo"];
            
            Logica.FabricaLogica.GetLogicaPrestamo().Baja(prestamo);
           
            this.LimpiarControles();

            LblError.Text = "Baja con exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Prestamo prestamo = (Prestamo)Session["Prestamo"];

            prestamo.Monto = Convert.ToDouble(txtMonto.Text.Trim());
            prestamo.Cuotas = Convert.ToInt32(txtCuotas.Text.Trim());
            
            Logica.FabricaLogica.GetLogicaPrestamo().Modificacion(prestamo);
            
            this.LimpiarControles();

            LblError.Text = "Modificado con exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpiarControles();
    }
}