using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EjemploLinqToAdo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnCargaInicial_Click(object sender, EventArgs e)
    {
        System.Data.DataSet _ds = new System.Data.DataSet(); //el adaptador es el bluetooth que trae todo a los datatables.
        System.Data.SqlClient.SqlDataAdapter _da = new System.Data.SqlClient.SqlDataAdapter("TodasLasMascotas", "Data Source= .; Initial Catalog = Veterinaria; Integrated Security = true");
        _da.Fill(_ds,"Mascotas");
        ViewState["Mascotas"] = _ds.Tables["Mascotas"];

        GVMostrarDesdeBD.DataSource = (System.Data.DataTable)ViewState["Mascotas"];
        GVMostrarDesdeBD.DataBind();

    }



    protected void BtnFiltrar1_Click(object sender, EventArgs e)
    {
        //1origen de datos
        System.Data.DataTable _MiTabla = (System.Data.DataTable)ViewState["Mascotas"];

        //2 consulta
        var resultado = from unRegistro in _MiTabla.Select()
                        where (int)unRegistro["EdadMas"] > 5
                        select unRegistro;

        //3 ejecucion
        LBResultado.Items.Clear();
        foreach (var unReg in resultado)
        {
            LBResultado.Items.Add(unReg["NomMas"].ToString() + " - " + unReg["RazaMas"].ToString() + " - " + unReg["EdadMas"].ToString());
        }
    }



    protected void BtnFiltrar2_Click(object sender, EventArgs e)
    {
        //1 origen de datos
        System.Data.DataTable _miTabla = (System.Data.DataTable)ViewState["Mascotas"];

        //2 consulta
        var resultado = (from unRegistro in _miTabla.Select()
                         orderby unRegistro["EdadMas"]
                         select unRegistro).Last();

        //3 despliegue de resultado
        LBResultado.Items.Clear();
        LBResultado.Items.Add(resultado["NomMas"].ToString() + " - " + resultado["RazaMas"].ToString() + " - " + resultado["EdadMas"].ToString());
    }



    protected void BtnFiltrar3_Click(object sender, EventArgs e)
    {
        //1 origen de datos
        System.Data.DataTable _miTabla = (System.Data.DataTable)ViewState["Mascotas"];

        //2 consulta
        var resultado = (from unRegistro in _miTabla.Select()
                         where (int)unRegistro["EdadMas"] == 15
                         select unRegistro).Any();

        //3 despliegue de resultado
        LBResultado.Items.Clear();
        LBResultado.Items.Add(resultado.ToString());
   
    }


    protected void BtnFiltrar4_Click(object sender, EventArgs e)
    {
        //Cuando quiero hacer JOIN dentro de un LinQ To ADO tengo que asegurarme que las tablas provengan del mismo DataSet
        //de lo contrario me va a dar error.
        System.Data.DataSet _ds = new System.Data.DataSet();
        System.Data.DataTable _tablaDueños = null;
        System.Data.DataTable _tablaMascotas = null;

        //obtengo origen de datos dueños y lo muestro
        System.Data.SqlClient.SqlDataAdapter _daD = new System.Data.SqlClient.SqlDataAdapter("Select * From Dueños", "Data Source=. ;Initial Catalog=Veterinaria; Integrated Security = true");
        _daD.Fill(_ds, "Dueños");
        _tablaDueños = _ds.Tables["Dueños"];
        GVMostrarDesdeBD.DataSource = _tablaDueños;
        GVMostrarDesdeBD.DataBind();

        //obtengo orign de datos mascotas
        System.Data.SqlClient.SqlDataAdapter _daM = new System.Data.SqlClient.SqlDataAdapter("Select * From Mascotas", "Data Source=.;Initial Catalog=Veterinaria;INtegrated Security = true");
        _daM.Fill(_ds, "Mascotas");
        _tablaMascotas= _ds.Tables["Mascotas"];

        //genero la consulta
        var resultado = from unRegistroD in _tablaDueños.Select() //en un join comun el orden en que traiga los registros no me afecta, pero si voy a agrupar tengo que tomar en cuenta que voy a poder agrupar por los registros del "from", no de la clausula "join", o sea que sí importa el orden en el caso que vayamos a agrupar, en l
                        join unRegistroM in _tablaMascotas.Select() //en la condicion del join, o sea, 
                        on unRegistroD["IdDueño"] equals unRegistroM["IdDueño"] //el "ON", sí importa el orden en que comparo datos, eso significa que primero etngo que poner el elemento proveniente del "from" y después el proveniente del "join".
                        group unRegistroD by unRegistroD["NomDueño"] //los grupos se pueden individualizar, eso significa que yo dado un grupo puedo recorrerlo y sacar individualmente lo que hay adentro (dibujo de 2 foreachs que con uno recorro el conjunto de conjuntos y con el otro foreach cada conjunto)
                        into TablaRes //si no le pongo un INTO a un GROUP BY, no lo guardo en ningun lado y se pierde.
                        select new
                        {
                            NomDueño = TablaRes.First()["NomDueño"], //en este caso equivale a =TablaRes.Key
                            CantidaM = TablaRes.Count()
                        };
        //ejecucion
        LBResultado.Items.Clear();
        foreach (var unReg in resultado)
        {
            LBResultado.Items.Add(unReg.NomDueño.ToString() + " (" + unReg.CantidaM.ToString() + " )");
        }

    }


    protected void BtnFiltrar5_Click(object sender, EventArgs e)
    {
        //1 origen de datos
        System.Data.DataTable _miTabla = (System.Data.DataTable)ViewState["Mascotas"];

        //2genero la consulta
        var resultado = from unRegistroD in _miTabla.Select()
                         group unRegistroD by unRegistroD["IdDueño"]
                         into TablaRes
                         select TablaRes; //da error!

        //ejecucion de consulta
        LBResultado.Items.Clear();
        foreach (var unReg in resultado)
        {
            LBResultado.Items.Add(unReg.First()["NomDueño"].ToString() + " - " + unReg.Count());
        }
    }


}