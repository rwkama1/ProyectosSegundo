using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EjemploLinqToObject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnCargaInicial_Click(object sender, EventArgs e)
    {
        GVDueños.DataSource = Logica.LogicaDueño.ListarDueñosManual();
        GVDueños.DataBind();
    }


    protected void BtnFiltrar1_Click(object sender, EventArgs e)
    {
        //1-obtengo la fuetne de datos para LinQ
        List<EntidadesCompartidas.Dueño> _LosDueños = Logica.LogicaDueño.ListarDueñosManual();

        //2-Determino la consulta = solo quiero dueños con mas de 3 mascotas
        var resultado = from unDueño in _LosDueños
                        where unDueño.CantMascotas > 3
                        select unDueño;
        //El resultado de esta consulta va a ser un conjunto de objetos tipo Dueño
        

        //3-Despliego el resultado en el listbox
        LBResultadoDueño.Items.Clear();
        foreach(EntidadesCompartidas.Dueño unDuenio in resultado) //el for obliga a ejecutar la consulta y luego lo de adentro del for trabaja
        {
            LBResultadoDueño.Items.Add(unDuenio.ToString());
        }
        //Resultado es la variable donde está definida la consulta del int, cuando el foreach obliga a ejecutarse dicha consulta
        //cada resultado que genere la consulta de forma automática se guarda en dicha variable, y por eso puedo sacar cada elemento
        //del resultado de ahí. 
        //Esta es la primer forma de ejecución del LinQ, en dos pasos, defino y después ejecuto
    }


    protected void BtnFiltrar2_Click(object sender, EventArgs e)
    {
        //1-Obtengo la fuente de datos para LinQ
        List<EntidadesCompartidas.Dueño> _LosDueños = Logica.LogicaDueño.ListarDueñosManual();
        //2-Determino la consulta = solo quierop dueños con menos de 6 caracteres en su nombre
        var resultado = from unDueño in _LosDueños
                        where unDueño.Nombre.Trim().Length < 6
                        select unDueño;
        //3- despliego el resultado en el listbox
        LBResultadoDueño.Items.Clear();
        foreach (EntidadesCompartidas.Dueño unDuenio in resultado)
        {
            LBResultadoDueño.Items.Add(unDuenio.ToString());
        }
    }


    protected void BtnCargaInicialMAscota_Click(object sender, EventArgs e)
    {
        GVMascota.DataSource = Logica.LogicaMascota.ListarMascotasManual();
        GVMascota.DataBind();
    }


    protected void BtnFiltrar3_Click(object sender, EventArgs e)
    {
        //1-obtengo la fuente de datos para LinQ
        List<EntidadesCompartidas.Mascota> _LasMascotas = Logica.LogicaMascota.ListarMascotasManual();

        //2-determino la consulta
        var resultado = from unaM in _LasMascotas
                        where unaM.Edad > 10
                        select unaM;

        //3-despliego el resultado en el listbox
        LBResultadoDueño.Items.Clear();
        foreach (EntidadesCompartidas.Mascota unaM in resultado)
        {
            LBResultadoMascota.Items.Add(unaM.Nombre + " - " + unaM.Raza + " - Edad: " + unaM.Edad.ToString());
        }
    }


    protected void BtnFiltrar4_Click(object sender, EventArgs e)
    {
        //aca hago todo de una en vez de en 3 pasos como hasta ahora
        //cuando junto las 3 etapas del linQ significa que voy a aplicar una operacion de conjunto, consecuentemente
        //sé que tipo de datos se me va a devolver y por lo tanto no tengo necesidad de hacer una variable de tipo VAR.
        //ya puedo hacerla del tipo específico

        //determino la consulta
        List<EntidadesCompartidas.Mascota> _Listaresultado =
            (from unaM in (Logica.LogicaMascota.ListarMascotasManual()) //cuando la obtencion del origen de datos la hago en linea dentro del 
             where unaM.Raza.Contains("Perro") //LINQ, necesito ponerlo entre parentesis, para que ejecute primero el origen de datos
             select unaM).ToList<EntidadesCompartidas.Mascota>(); //y despues tome en cuenta a la consulta LINQ
        //cuando voy a hacer un ToList con operacion de grupo hay que recordar que la lista, o sea, el conjunto lo va a crear, aunque el linq
        //No me devuelva ningun objeto, consecuentemente tendría una lista vacia
        //despliego el resultado en la grilla
        GVMascota.DataSource = _Listaresultado;
        GVMascota.DataBind();
    }


}