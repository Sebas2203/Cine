using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Cine
{
    public partial class tickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarPelicula();
        }

        private void CargarPelicula()
        {
            try
            {
                if (Session["pelicula"] == null)
                {
                    throw new Exception("No hay sesion");
                }
                else
                {

                    List<Peliculas> listaPeliculas = (List<Peliculas>)Session["listaPeliculas"];

                    Ticket extractor = (Ticket)Session["ticket"];

                    ////crear un div para cada articulo
                    //HtmlGenericControl div = new HtmlGenericControl("div");
                    //div.InnerHtml += $"<div class='pelicula'> <div class='etiqueta'>ESTRENO</div> <img src='{listaPeliculas.urlImagen}' alt='{item.nombrePelicula}'></div>";

                    ////agregar un CSS
                    //div.Attributes["class"] = "pelicula";

                    ////agregar boton
                    //Button btn = new Button();
                    //btn.Text = "Comprar";
                    //btn.ID = $"btnComprar-{item.id}";
                    ////CSS al boton
                    //btn.CssClass = "btnClass";
                    ////agregar un evento al boton
                    //btn.Click += new EventHandler(btnComprar_Click);
                    //div.Controls.Add(btn);


                    ////agregar el div creado al form del HTML
                    //cartelera.Controls.Add(div);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pelicula sin existencia");
            }
        }
    }
}