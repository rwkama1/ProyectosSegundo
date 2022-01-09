using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuDeberes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
         List<Articulo > ListaArt = Persistencia.ListarArt();
            foreach (Articulo p in ListaArt)
            {
                Menu1.Items.Add(new MenuItem( p.Nombre,p.Codigo.ToString()));
            }
            //Menu1.MenuItemClick += Seleccion;
    }
  
}