using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EjemploLinqToXML : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void BtnCargaInicial_Click(object sender, EventArgs e)
    {
        //Cuando un DataSet lee un archivo XML va a crear un objeto DataTable por cada nodo primario diferente que encuentre, 
        //y cada vez que se repita dicho nodo será un registro más para el DataTable
        //Cuando yo asigno un DataSet directamente a una grilla, automáticamente me va a mostrar el primer DataTable que contiene.
        System.Data.DataSet _unDataset = new System.Data.DataSet();
        _unDataset.ReadXml(Server.MapPath("~/Mascotas.XML"));
        GVMascotas.DataSource = _unDataset;
        GVMascotas.DataBind();
    }


    protected void BtnFiltrar1_Click(object sender, EventArgs e)
    {
        //1 origen de datos
        System.Xml.Linq.XElement _origenDatos = System.Xml.Linq.XElement.Load(Server.MapPath("~/Mascotas.XML"));
        //2 consulta
        //Ya acá en este from estamos filtrando qué nodo del archivo queremos, o sea que ya estamos haciendo el filtrado,         
        //no estamos sacando todos los nodos del archivo
        //esto significa que en la variable unNodo se va a ir cargando vez por vez un nodito XML de Mascota
        //o sea que cada vez que use unNodo voy a estar usando UN nodito de mascota con sus 3 etiquetas adentro
        var resultado = from unNodo in _origenDatos.Elements("Mascota")
                        where Convert.ToInt32(unNodo.Element("Edad").Value) > 5 //el VALOR de una etiqueta es el texto contenido de ella,
                        select unNodo;                                 // ahora, si la propiedad value se la aplicamos a un nodo, o sea, 
                                                                    // una etiqueta que tiene otras etiquetas hijas, como este nodo no puede
                                                            //tener texto directo, entonces lo que hace es concatenar sin espacios,
                                                        // los valores contenidos de todas sus subetiquetas
                                //si a un nodo que no contiene texto propio porque tiene etiquetas contenidas le aplicamos la operacion ToString
                            // automaticamente lo que hace es convertir en un string de una sola línea todas las etiquetas de ese nodo
                // conjuntamente con sus datos, que tecnicamente es lo que vimos en el listbox, agarró las etiquetas y las puse una tras otra.
                //en un string de una linea. 
        //3 ejecicion
        LBResultado.Items.Clear();
        foreach (var unNodo in resultado)
        {
            LBResultado.Items.Add(unNodo.ToString()); //ahora si yo quiesiera arreglar esto en vez de poner un ToString pongo
                                                //unNodo.Element("Nombre").Value en vez de LBResultado.Items.Add(unNodo.ToString())LBResultado.Items.Add(unNodo.ToString())
        }
    }
    
    
    protected void BtnFiltrar2_Click(object sender, EventArgs e)
    {
        //1 origen de datos
        System.Xml.Linq.XElement _origenDatos = System.Xml.Linq.XElement.Load(Server.MapPath("~/Mascotas.XML"));
        //2 consulta
        var resultado = (from unNodo in _origenDatos.Elements("Mascota")
                         orderby (int)unNodo.Element("Edad") descending
                         select unNodo).First();

        //3 despliegue de resulktados
        LBResultado.Items.Clear();
        LBResultado.Items.Add(resultado.Value);
// ó para ser mas especifico
      //LBResultado.Items.Add(resultado.Element("Nombre").Value);
    }


    protected void BtnFiltrar3_Click(object sender, EventArgs e)
    {
        //1. origen 
        System.Xml.Linq.XElement _origenDatos = System.Xml.Linq.XElement.Load(Server.MapPath("~/Mascotas.XML"));

        //2 consulta
        var resultado = (from unNodo in _origenDatos.Elements("Mascota")
                         where (int)unNodo.Element("Edad") == 45
                         select unNodo).Any();

        //3 despliegue
        LBResultado.Items.Clear();
        LBResultado.Items.Add(resultado.ToString());

    }
}