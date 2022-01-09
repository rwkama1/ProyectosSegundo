using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//espacio de nombres necesarios para generar la interfaz grafica
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ControlesWeb
{
    //generacion de un CustomControl
    public class ManejoTelefonos : WebControl, INamingContainer
    {
        //atributos
        private Label UnTitulo;
        private ListBox LbTelefonos;
        private Button BtnAgregarTel;
        private TextBox UnTel;
        private Button BtnBorrarTel;
        private Label LblErrorCC;
        private Panel UnPanel;


        //propiedades
        public List<EntidadesCompartidas.Telefono> ListaTelefonos
        {
            get
            {
                List<EntidadesCompartidas.Telefono> _lista = new List<EntidadesCompartidas.Telefono>();

                foreach (ListItem unTel in LbTelefonos.Items)
                {
                    _lista.Add(new EntidadesCompartidas.Telefono(unTel.Text));
                }
                return _lista;
            }

            set
            {
                LbTelefonos.Items.Clear();
                foreach (EntidadesCompartidas.Telefono unTel in value)
                {
                    LbTelefonos.Items.Add(unTel.UnTelefono);
                }
            }
        }

        //sobreescribo el metodo CreateChilCntrols
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            //creo un panel para armar el diseño
            UnPanel = new Panel();

            //agrego titulo
            UnTitulo = new Label();
            UnTitulo.Text = "TELEFONOS";
            UnTitulo.ForeColor = System.Drawing.Color.Red;
            UnTitulo.Font.Bold = true;
            UnTitulo.Font.Underline = true;
            UnPanel.Controls.Add(UnTitulo);
            UnPanel.Controls.Add(new LiteralControl("<BR />"));

            //agrego  boton de borrar
            BtnBorrarTel = new Button();
            BtnBorrarTel.Text = "Borrar Tel";
            BtnBorrarTel.Click += new EventHandler(BorrarTelefono);
            UnPanel.Controls.Add(BtnBorrarTel);

            //agrego el listbox
            LbTelefonos = new ListBox();
            UnPanel.Controls.Add(LbTelefonos);
            UnPanel.Controls.Add(new LiteralControl("<BR />"));

            BtnAgregarTel = new Button();
            BtnAgregarTel.Text = "Agregar Tel";
            BtnAgregarTel.Click += new EventHandler(AltaTelefono);
            UnPanel.Controls.Add(BtnAgregarTel);

            //agrego caja de texto para ingreso telefono
            UnTel = new TextBox();
            UnTel.Text = "";
            UnPanel.Controls.Add(UnTel);
            UnPanel.Controls.Add(new LiteralControl("<BR />"));

            //agrego la etiqueta de errores
            LblErrorCC = new Label();
            LblErrorCC.Text = "";

            //agrego el panel al control costumizado
            this.Controls.Add(UnPanel);

        }

        protected void AltaTelefono(object sender, EventArgs e)
        {
            //verifico q se haya ingresado algo en la caja de texto de telefono
            if (UnTel.Text.Trim().Length > 0)
            {
                LbTelefonos.Items.Add(UnTel.Text.Trim());
                UnTel.Text = "";
                LblErrorCC.Text = "Se agrego Correctamente el Telefono a la Lista";
            }
            else
                LblErrorCC.Text = "No Hay nada ingresado - No se agrega Telefono a la lista";
        }

        protected void BorrarTelefono(object sender, EventArgs e)
        {
            //determino si hay una linea de la lista seleccionada
            if (LbTelefonos.SelectedIndex >= 0)
            {
                LbTelefonos.Items.RemoveAt(LbTelefonos.SelectedIndex);
                LblErrorCC.Text = "Eliminacion del Telefono de la Lista con Exito";
            }
            else
                LblErrorCC.Text = "Debe Seleccionar un telefono de la lista para eliminar";
        }

        public void LimpiarTodo()
        {
            LbTelefonos.Items.Clear();
        }

    }
}
