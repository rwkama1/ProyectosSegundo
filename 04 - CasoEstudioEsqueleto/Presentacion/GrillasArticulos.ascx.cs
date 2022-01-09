using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class GrillasArticulos : System.Web.UI.UserControl
{
    //atributos 
    private int _indiceSeleccionado;
    private DataTable _dt;
    //El user control va tener propiedades y operaciones para que una pagina lo use, lo vamos a cargar desde afuera, lo vamos a consultar desde afuera
    //El atributo DataTable,va ser el conjunto de registro que muestra el control,
    //el indice seleccionado es si el usuario me selecciona algo con la grilla, mantengo la posicion de la seleccion
    protected void Page_Load(object sender, EventArgs e)
    {
        //asigno evento a la seleccion de liunea de la grilla
        GVarticulos.SelectedIndexChanged += new System.EventHandler(this.SeleccionGrilla);
        if (!IsPostBack)
        {
            _indiceSeleccionado = -1;
            _dt = null;
            ViewState["_dt"] = _dt;
            ViewState["_indiceSeleccionado"] = _indiceSeleccionado;
        }
        else
        {
            //manejo la el estado de la propia pagina para almacenar entre postback
            _indiceSeleccionado = Convert.ToInt32(ViewState["_indiceSeleccionado"].ToString());
            _dt = (DataTable)(ViewState["_dt"]);
        }

    }
    private void SeleccionGrilla(object Sender, EventArgs e)
    {
        _indiceSeleccionado = GVarticulos.SelectedIndex;
        ViewState["_indiceSeleccionado"] = _indiceSeleccionado;
    }
    //cuando se selecciona algo, yo guardo la posicion seleccionada,ya que despues para saber cual es el registro seleccionado,
    //sabiendo la posicion voy al DataTable y saco el registro
    //Los ViewState si hay que recargarlos siempre, la session no son necesarios de cargarlos
    public void CargoArticulo()
    {
        try
        {
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Articulos", "Data Source = .; Initial Catalog = Ventas; Integrated Security = true");
            DataSet _ds = new DataSet();
            _da.Fill(_ds);
            _dt = _ds.Tables[0];
            GVarticulos.DataSource = _dt;
            GVarticulos.DataBind();
            ViewState["_dt"] = _dt;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        //propiedad del control de usuario que permite saber cual es el registro del articulo seleccionado en la grilla
        public DataRow ArticuloSeleccionado
        {
            get{return _dt.Rows[_indiceSeleccionado];}
        }
    
}