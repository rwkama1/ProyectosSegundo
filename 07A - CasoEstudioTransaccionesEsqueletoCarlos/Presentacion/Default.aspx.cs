using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //atributos
    EntidadesCompartidas.Cliente ClienteSeleccionado;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //si es el primer ingreso a la pagina
            if (!IsPostBack)
            {
                Session["ClienteSel"] = null;
                CargoGrilla();
                LimpioPantalla();
            }
            else
            {
                //ya se esta trabajando
                if (Session["ClienteSel"] != null)
                    ClienteSeleccionado = (EntidadesCompartidas.Cliente)Session["ClienteSel"];
                else
                    ClienteSeleccionado = null;
             }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }

    protected void LimpioPantalla()
    {
        TxtCodigo.Text = "";
        TxtDireccion.Text = "";
        TxtNombre.Text = "";
        TxtTelefono.Text = "";
        LbTelefonos.Items.Clear();
        LbTelefonos.SelectedIndex = -1;
        LblError.Text = "";
        GVClientes.SelectedIndex = -1;
        ClienteSeleccionado = null;
        Session["ClienteSel"] = null;
    }

    protected void CargoCliente()
    {
        TxtCodigo.Text = ClienteSeleccionado.CodCLi.ToString();
        TxtDireccion.Text = ClienteSeleccionado.DirCli.ToString();
        TxtNombre.Text = ClienteSeleccionado.NomCli.ToString();
        LbTelefonos.DataSource = ClienteSeleccionado.LosTelefonos;
        LbTelefonos.DataTextField = "UnTelefono";
        LbTelefonos.DataBind();
        LbTelefonos.SelectedIndex = -1;
        LblError.Text = "";
    }

    protected void CargoGrilla()
    {
        GVClientes.DataSource = Logica.FabricaLogica.GetLogicaCLiente().Listo();
        GVClientes.DataBind();
    }

    protected void GVClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //busco el cliente seleccionado
            ClienteSeleccionado = Logica.FabricaLogica.GetLogicaCLiente().Busco(Convert.ToInt32(GVClientes.SelectedRow.Cells[0].Text));
            if (ClienteSeleccionado == null)
            {
                LblError.Text = "Error al buscar el cliente seleccionado";
                Session["ClienteSel"] = null;
                ClienteSeleccionado = null;
            }
            else
            {
                Session["ClienteSel"] = ClienteSeleccionado;
                CargoCliente();
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnBorrarTel_Click(object sender, EventArgs e)
    {
        //determino si hay una linea de la lista seleccionada
        if (LbTelefonos.SelectedIndex >= 0)
        {
            LbTelefonos.Items.RemoveAt(LbTelefonos.SelectedIndex);
            LblError.Text = "Eliminacion del Telefono de la Lista con Exito";
        }
        else
            LblError.Text = "Debe Seleccionar un telefono de la lista para eliminar";
    }

    protected void BtnRefrescar_Click(object sender, EventArgs e)
    {
        LimpioPantalla();
    }

    protected void BtnAgregarTel_Click(object sender, EventArgs e)
    {
        //verifico q se haya ingresado algo en la caja de texto de telefono
        if (TxtTelefono.Text.Trim().Length > 0)
        {
            LbTelefonos.Items.Add(TxtTelefono.Text.Trim());
            TxtTelefono.Text = "";
            LblError.Text = "Se agrego Correctamente el Telefono a la Lista";
        }
        else
            LblError.Text = "No Hay nada ingresado - No se agrega Telefono a la lista";
    }

    protected void BtnAgregarCliente_Click(object sender, EventArgs e)
    {
        try
        {
            //verifico que no haya un cliente seleccionado, ya q en ese caso seria modificacion
            if (ClienteSeleccionado == null)
            {
                //creo al cliente a dar de alta
                EntidadesCompartidas.Cliente unCliente = new EntidadesCompartidas.Cliente(0, TxtNombre.Text.Trim(), TxtDireccion.Text.Trim());
                foreach (ListItem unLugar in LbTelefonos.Items)
                    unCliente.AgregarTelefono(unLugar.Text.Trim());

                //doy de alta
                Logica.FabricaLogica.GetLogicaCLiente().Alta(unCliente);

                //si llego aca es pq no hubo errores
                LblError.Text = "Alta de Cliente + Telefonos en Transaccion Logica Correcta";
                CargoGrilla();
                LimpioPantalla();
            }
            else
                LblError.Text = "No puede ser un alta - Debe ser una Modificacion porque los datos provienen de un cliente seleccionado";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnModificarTelCliente_Click(object sender, EventArgs e)
    {
        try
        {
            //verifico que haya un cliente seleccionado, pq sino no lo podre modificar
            if (ClienteSeleccionado != null)
            {
                EntidadesCompartidas.Cliente unCliente;
       
                unCliente = new EntidadesCompartidas.Cliente(0, TxtNombre.Text.Trim(), TxtDireccion.Text.Trim());
                //elimino todos los telefonos que tenia antes el cliente
                ClienteSeleccionado.EliminarTodosTelefonos();

                //actualizo la lista de telefonos del cliente con los de la pantalla
                foreach (ListItem unLugar in LbTelefonos.Items)
                    ClienteSeleccionado.AgregarTelefono(unLugar.Text.Trim());

                //modifico los telefonos unicamente
                //Logica.FabricaLogica.GetLogicaCLiente().ModificarTelefonos(uncliente);
                Logica.FabricaLogica.GetLogicaCLiente().ModificarTelefonos(unCliente);

                //si llego aca es pq no hubo errores
                LblError.Text = "Modificacion de Telefonos en Transaccion Logica Correcta";
                CargoGrilla();
                LimpioPantalla();
            }
            else
                LblError.Text = "No puede ser un alta - Debe ser una Modificacion porque los datos provienen de un cliente seleccionado";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }

}