using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using System.Collections;



public partial class ListadoMovimientos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //obtengo toda los movimientos sin filtrar de la base de datos
                Session["_listaTotal"] = Logica.FabricaLogica.GetLogicaMovimiento().ListarTodosLosMovimientos();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }


    protected void BtnFiltrar_Click(object sender, EventArgs e)//la idea de usar el linQ aca es no ir a la base de datos por cada filtro
    {
        List<EntidadesCompartidas.Movimiento> _listaTotal = (List<EntidadesCompartidas.Movimiento>)Session["_listaTotal"];
        //lo primero que hay q definir es que tipo de linQ vamos a usar
        //el cual tiene que estar acorde a como este nuestro sistema desarrollado
        //en nuestro caso no usamos archivos xml y como nuestro sistema se maneja con objetos
        //entonces lo ideal es usar linQToObject
        //el linQtoOBject lo usamos en una pagina donde se le muestra al usuario varias opciones para ver la misma inormacion
        //puede filtrarlo de varias maneras, puede ordenarlo, etc
        //ppara que este tipo de paginas de multiples filtros sea rapida no deberiamos ir por cada filtro a buscar la informacion a la base de datos
        //consecuentemente si se accede constantemente por cada filtro a la base de datos tambien tenemos un usuario que esta utilizando accesos a la base de datos
        //y no los esta haciendo por necesidad de accion, usando el LinqtoObject podemos traer la informacion de una sola vez y sobre esa misma informacion aplicar
        //repetidas veces filtros, y eso solo lo permite hacerlo el linq.
        //para que realmente funcione, es decir, que sea una ventaja usar ese linq necesitamos traer una sola vez esa informacion
        //desde la base de datos, luego hay que filtrar siempre bajando desde la session
        try
        {
            //en funcion de la seleccion del combo, se filtra y despliegan los datos
            if (DDLTipoBusqueda.SelectedIndex == -1)
            {
                LblError.Text = "Debe seleccionar algo en la lista de seleccion";
            }
            else if (DDLTipoBusqueda.SelectedIndex == 0)
            {
                //se muestra todo
                GVListar.DataSource = _listaTotal;
                GVListar.DataBind();
            }
            else if (DDLTipoBusqueda.SelectedIndex == 1)
            {
                //se filtra por el numero de cuenta ingresado en la caja de texto

                //verifico ingreso en la caja
                if (TxtFiltro.Text.Trim().Length == 0)
                {
                    GVListar.DataSource = null;
                    throw new Exception("No se ingreso el numero de cuenta en la caja de texto");
                }

                try { Convert.ToInt32(TxtFiltro.Text); }
                catch
                {
                    GVListar.DataSource = null;
                    throw new Exception("EL dato digitado no es numerico, no se filtra");
                }


                //si llego aca tengo datos para filtros.
                List<EntidadesCompartidas.Movimiento> _Resultado = (from UnMov in _listaTotal
                                                                    where UnMov.UnaCuenta.NumCta == Convert.ToInt32(TxtFiltro.Text)
                                                                    select UnMov).ToList<EntidadesCompartidas.Movimiento>();
                GVListar.DataSource = _Resultado;
                GVListar.DataBind();

            }
            else if (DDLTipoBusqueda.SelectedIndex == 3)
            {
                //se filtra por la fecha ingresada en la caja de texto

                //verifico ingreso en la caja
                try { Convert.ToDateTime(TxtFiltro.Text); }
                catch
                {
                    GVListar.DataSource = null;
                    throw new Exception("EL dato digitado no es una fecha valida, no se filtra");
                }


                //si llego aca tengo datos para filtros.
                List<EntidadesCompartidas.Movimiento> _Resultado = (from UnMov in _listaTotal
                                                                    where UnMov.FechaMov == Convert.ToDateTime(TxtFiltro.Text)
                                                                    select UnMov).ToList<EntidadesCompartidas.Movimiento>();
                GVListar.DataSource = _Resultado;
                GVListar.DataBind();
            }
            else if (DDLTipoBusqueda.SelectedIndex == 2)
            {
                //se filtra por el tipo de movimiento ingresado en la caja de texto

                //verifico ingreso en la caja
                if (TxtFiltro.Text.Trim().ToUpper() != "R" && TxtFiltro.Text.Trim().ToUpper() != "D")
                {
                    GVListar.DataSource = null;
                    throw new Exception("No se ingreso un tipo de Movimiento Correcto - No se filtra");
                }

                //si llego aca tengo datos para filtros.
                List<EntidadesCompartidas.Movimiento> _Resultado = (from UnMov in _listaTotal
                                                                    where UnMov.TipoMov == TxtFiltro.Text.Trim().ToUpper()
                                                                    select UnMov).ToList<EntidadesCompartidas.Movimiento>();
                GVListar.DataSource = _Resultado;
                GVListar.DataBind();
            }
            else if (DDLTipoBusqueda.SelectedIndex == 4)
            {
                //se despliega la cantidad de movimientos por cuenta 

                var _ResultadoLinQ = from UnMov in _listaTotal
                                     group UnMov by UnMov.UnaCuenta.NumCta
                                         into Auxiliar
                                         select new
                                         {
                                             Cuenta = Auxiliar.First().UnaCuenta.NumCta,
                                             Cantidad = Auxiliar.Count()
                                         };

                ArrayList _ResultadoFinal = new ArrayList();

                foreach (var unObj in _ResultadoLinQ)
                    _ResultadoFinal.Add(unObj);

                GVListar.DataSource = _ResultadoFinal;
                GVListar.DataBind();
            }
            else if (DDLTipoBusqueda.SelectedIndex == 5)
            {
                //se muestran ordenado por numero de cuenta y fecha
                List<EntidadesCompartidas.Movimiento> _Resultado = (from UnMov in _listaTotal
                                                                    orderby UnMov.UnaCuenta.NumCta, UnMov.FechaMov
                                                                    select UnMov).ToList<EntidadesCompartidas.Movimiento>();
                GVListar.DataSource = _Resultado;
                GVListar.DataBind();
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}