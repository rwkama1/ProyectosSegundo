using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
namespace Controles
{
   public class Letras:WebControl,INamingContainer//hereda de web control,porque lo que estoy creando es un control que muestre alguna pagina
       //La interfaz INamingContainer,me permite identificar un control contenedor y me va a permitir marcar Ids para que puedan salir hacia afuera de los contextos
       //Como las paginas en tiempo de ejecucion por si mismas no permite agregar nuevos elementos de interfaz grafica,se pueden usar controles
       //contenedores de tipo panel, los cual si se pueden dibujar en tiempo de ejecucion
    {
       //atributos-representan los controles contenidos
       private TextBox _txtIngreso;
       private DropDownList _ddlTipo;
       private Button _btnProceso;
       private Label _lblResultado;
       private Panel _unPanel;
       //Para que se pueda armar, todos los elementos de un Composite Control, lo primero que tenemos que programar,es la operacion
       //CreateChilControls,esta operacion va ser provocada por el servidor en los controles contenedores,para que se creen los controles 
       //contenidos
       //Tecnicamente donde terminamos de armar nuestra pagina grafica,

       //sobreescribo el metodo CreateChildControls
       protected override void CreateChildControls()
       {
           base.CreateChildControls();
           //creo un panel para armar el diseño
           _unPanel = new Panel();
           _txtIngreso = new TextBox();
           _txtIngreso.Height = Unit.Pixel(15);
           _txtIngreso.Width = Unit.Pixel(200);
           _txtIngreso.ForeColor = System.Drawing.Color.Blue;
           _unPanel.Controls.Add(new LiteralControl("Ingrese Texto: "));
           _unPanel.Controls.Add(_txtIngreso);
           _unPanel.Controls.Add(new LiteralControl("<BR/>"));

           //Cuando apreto dinamicamente una caja de texto, esta por defecto no viene con tamaño definido, consecuentemente si yo no le pongo
           //tamaño para el despliegue no se va a ver
           //La clase Unit,se encuentra definida dentro de  System.Web.UI.WebControls y representa la unidades de medidas que se pueden usar en web
           //Un literalControl es un control que no existe en tiempo de diseño, solo ejecucion ,que representa un texto directo sobre una pagina HTML
           //El literalControl se le pasa texto , y se escribe tal cual como esta en la pagina HTML, si solo colocamos texto, se escribe el texto tal cual
           //si en el texto ponemos etiquetas HTML,esta se va a escribir tal cual en la parte HTML
           
           //Agrego control dropDownList
           _ddlTipo = new DropDownList();
           _ddlTipo.Items.Add("Cantidad de Letras");
           _ddlTipo.Items.Add("Pasar a Mayusculas");
           _ddlTipo.Items.Add("Pasar a Minusculas");
           _unPanel.Controls.Add(new LiteralControl("Determine Accion: "));
           _unPanel.Controls.Add(_ddlTipo);
           //agrego el boton de proceso
           _btnProceso = new Button();
           _btnProceso.Text ="Procesar";
           _btnProceso.BackColor = System.Drawing.Color.Salmon;
           _btnProceso.Click += new EventHandler(Proceso);
           _unPanel.Controls.Add(_btnProceso);
           _unPanel.Controls.Add(new LiteralControl("<BR/>"));
           //agrego control etiqueta 
          
           _lblResultado = new Label();
           _lblResultado.Height = Unit.Pixel(15);
           _lblResultado.Width = Unit.Pixel(200);
           _lblResultado.ForeColor = System.Drawing.Color.Red;
           _unPanel.Controls.Add(new LiteralControl("Resultado: "));
           _unPanel.Controls.Add(_lblResultado);
           _unPanel.Controls.Add(new LiteralControl("<BR/>"));
           //agrego el panel con los controles
           this.Controls.Add(_unPanel);
          
       }
       protected void Proceso(object sender, EventArgs e)
       {
           //determino que opcion del ddl se selecciono
           int _indice = _ddlTipo.SelectedIndex;
           //obtengo texto ingresado
           string _texto = _txtIngreso.Text.Trim();
           //realizo operacion
           if (_indice == 0)
               _lblResultado.Text = _texto.Length.ToString();
           else if (_indice == 1)

               _lblResultado.Text = _texto.ToUpper();
           else
               _lblResultado.Text = _texto.ToLower();
       }
    }
}
