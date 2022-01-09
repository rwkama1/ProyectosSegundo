using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;


public partial class LibroVisitas : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
            string Archivoxml = ConfigurationManager.AppSettings["LibroVisita"];

            DataSet ds = new DataSet();
            //string x = Server.MapPath(Archivoxml);
            ds.ReadXml(Server.MapPath(Archivoxml));
            try
            {
                gdLibro.DataSource = ds;
                gdLibro.DataBind();
            }
            catch (Exception es)
            {
                lblError.Text = "No hay visitas"+es.Message;
            }

        }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string Archivoxml = ConfigurationManager.AppSettings["LibroVisita"];
        
        //cargo el archivo 
        XmlDocument doc = new XmlDocument(); //constructor por defecto
        doc.Load(Server.MapPath(Archivoxml));
        //Definición de elementos
        XmlNode root = doc.DocumentElement; 
         //define la raiz del arbol en este caso libroVisitas
        XmlElement xmlVisita = doc.CreateElement("Visitas"); 
        XmlElement xmlNombre = doc.CreateElement("Nombre");
        xmlNombre.InnerText = txtNombre.Text;
        XmlElement xmlComentario = doc.CreateElement("Comentario");
        xmlComentario.InnerText = txtComentario.Text;
         //Agrupa los elementos en hijos del nodo
        xmlVisita.AppendChild(xmlNombre);
        xmlVisita.AppendChild(xmlComentario);
        root.AppendChild(xmlVisita);
         //Guardo los cambios
        doc.Save(Server.MapPath(Archivoxml));
        //limpio el formulario
        txtNombre.Text = "";
        txtComentario.Text = "";

    }
    
}
