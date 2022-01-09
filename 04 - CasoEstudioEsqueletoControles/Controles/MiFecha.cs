using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
namespace Controles
{
    public class MiFecha:WebControl,INamingContainer
    {
        private Dropdownlistdiasmes _ddldias;
        private Dropdownlistmeses _ddlmes;
        private DropDownListaños _ddlaños;
        private Label _lblResultadoo;
        private DateTime fecha;
        private Panel _unPanel;
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            //creo un panel para armar el diseño

            _unPanel = new Panel();
            //Agrego control dropDownList
            _ddldias = new Dropdownlistdiasmes();
            _unPanel.Controls.Add(new LiteralControl("Dias: "));
            _unPanel.Controls.Add(_ddldias);
            _ddlmes = new Dropdownlistmeses();
            _unPanel.Controls.Add(new LiteralControl("Mes: "));
            _unPanel.Controls.Add(_ddlmes);
            _ddlaños = new DropDownListaños();
            _unPanel.Controls.Add(new LiteralControl("Años: "));
            _unPanel.Controls.Add(_ddlaños);
            _lblResultadoo = new Label();
            _lblResultadoo.Height = Unit.Pixel(15);
            _lblResultadoo.Width = Unit.Pixel(200);
            _lblResultadoo.ForeColor = System.Drawing.Color.Red;
            _unPanel.Controls.Add(new LiteralControl("Resultadoo: "));
            _unPanel.Controls.Add(_lblResultadoo);
            _unPanel.Controls.Add(new LiteralControl("<BR/>"));
            this.Controls.Add(_unPanel);
        }
        public DateTime SelectedDate
        {
            get {return new DateTime (_ddlaños.SelectedIndex,_ddlmes.SelectedIndex,_ddldias.SelectedIndex); }
            set 
            {
                


 
            }
        }
    }
}
