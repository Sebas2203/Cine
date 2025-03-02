using Cine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

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
            listaPeliculas.Add(new Peliculas { id = 1, precio = 3000 , horario = "20:15", nombrePelicula = "Dune", urlImagen = "content/media/banner-dune.jpg", descripcion = "Ciencia Ficción/Aventura/Drama" });
            listaPeliculas.Add(new Peliculas { id = 2, precio = 3000 , horario = "21:30", nombrePelicula = "Fast & Furious: Tokyo Drift", urlImagen = "content/media/banner-tokyo.jpg", descripcion = "Acción/Carreras Automovilísticas" });
            listaPeliculas.Add(new Peliculas { id = 3, precio = 3000 , horario = "05:15", nombrePelicula = "Star Wars: Episodio 3", urlImagen = "content/media/banner-starwars.jpg", descripcion = "Ciencia Ficción/Aventura/Drama" });
            listaPeliculas.Add(new Peliculas { id = 4, precio = 3000 , horario = "19:15", nombrePelicula = "La tumba de las Luciernagas", urlImagen = "content/media/banner-tumba.jpg", descripcion = "Drama/Bélico/Tragedia" });
            listaPeliculas.Add(new Peliculas { id = 5, precio = 3000 , horario = "02:15", nombrePelicula = "The GodFather", urlImagen = "content/media/banner-god.jpg", descripcion = "Crimen/Drama/Thriller" });


            //sesion de la lista de peliculas
            Session["listaPeliculas"] = listaPeliculas;

            //recorrer la lista de peliculas
            foreach (var item in listaPeliculas)
            {
                //crear un div para cada articulo
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerHtml += $"<div class='pelicula'> <div class='etiqueta'>ESTRENO</div> <img src='{item.urlImagen}' alt='{item.nombrePelicula}'></div>";

                //agregar un CSS
                div.Attributes["class"] = "pelicula";

                //agregar boton
                Button btn = new Button();
                btn.Text = "Ver Horario";
                btn.ID = $"btnComprar-{item.id}";
                //CSS al boton
                btn.CssClass = "boton";
                //agregar un evento al boton
                btn.Click += new EventHandler(btnComprar_Click);
                div.Controls.Add(btn);


                //agregar el div creado al form del HTML
                cartelera.Controls.Add(div);
            }
        }


        protected void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                //capturar el id del boton
                Button btn = (Button)sender;
                string btnId = btn.ClientID;

                if (!string.IsNullOrEmpty(btnId))
                {
                    int idPelicula = int.Parse(btnId.Split('-')[1]);

                    //buscar e; articulo en la lsita de objetos
                    var peliFiltrada = new Peliculas();

                    peliFiltrada = listaPeliculas.FirstOrDefault(x => x.id == idPelicula);

                    //agregar el articulo a la pagina de ticket
                    if (peliFiltrada != null)
                    {
                        if (peliFiltrada.id == idPelicula)
                        {
                            //crear una instancia del tikect 
                            Ticket ticket = new Ticket();

                            //cargar los datos del ticket
                            ticket.pelicula = peliFiltrada;

                            Session["pelicula"] = ticket;

                            //redireccionar a la pagina de ticket
                            Response.Redirect("tickets.aspx", false);
                        }
                        else
                        {
                            throw new Exception("Error");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontro la pelicula");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

