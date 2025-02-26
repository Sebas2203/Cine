using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Cine
{
    public partial class Cartelera : System.Web.UI.Page
    {
        //crear una lista de peliculas = Cartelera Peliculas
        List<Peliculas> listaPeliculas = new List<Peliculas>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //agregar los elementos a la lista de objetos
            Peliculas Cartelera = new Peliculas();

            //agregar a la lista de objetos
            listaPeliculas.Add(new Peliculas { id = 1, nombrePelicula = "Dune", urlImagen = "content/media/banner-dune.jpg" });
            listaPeliculas.Add(new Peliculas { id = 2, nombrePelicula = "Fast & Furious: Tokyo Drift", urlImagen = "content/media/banner-tokyo.jpg" });
            listaPeliculas.Add(new Peliculas { id = 3, nombrePelicula = "Star Wars: Episodio 3", urlImagen = "content/media/banner-starwars.jpg" });
            listaPeliculas.Add(new Peliculas { id = 4, nombrePelicula = "La tumba de las Luciernagas", urlImagen = "content/media/banner-tumba.jpg" });
            listaPeliculas.Add(new Peliculas { id = 5, nombrePelicula = "The GodFather", urlImagen = "content/media/banner-god.jpg" });


            //sesion de la lista de peliculas
            Session["listaPeliculas"] = listaPeliculas;

            //recorrer la lista de peliculas
            foreach (var item in listaPeliculas)
            {
                //crear un div para cada articulo
                HtmlGenericControl div = new HtmlGenericControl("div");
                //div.InnerHtml = $"<p>{item.nombrePelicula}</p><br><img src='{item.urlImagen}'alt='{item.nombrePelicula}'/>";

                div.InnerHtml += $"<div class='pelicula'> <div class='etiqueta'>ESTRENO</div> <img src='{item.urlImagen}' alt='{item.nombrePelicula}'></div>";

                //agregar un CSS
                div.Attributes["class"] = "pelicula";

                //agregar boton
                Button btn = new Button();
                btn.Text = "Comprar";
                btn.ID = $"btnComprar_ {item.id}";
                //CSS al boton
                btn.CssClass = "btnClass";
                //agregar un evento al boton
                //btn.Click += new EventHandler(btnComprar_Click);
                div.Controls.Add(btn);


                //agregar el div creado al form del HTML
                cartelera.Controls.Add(div);
            }
        }

    }
}