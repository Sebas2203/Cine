﻿using Cine;
using System;
using System.Collections.Generic;
using System.Data;
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
            // Instantiate the business layer
            Negocios.lnCine negocio = new Negocios.lnCine();

            // Obtain the DataTable of movies
            System.Data.DataTable peliculasTable = negocio.ObtenerPeliculas_Negocios();

            // Convert the DataTable to a List<Peliculas>
            listaPeliculas = peliculasTable.AsEnumerable().Select(row => new Peliculas
            {
                id = row.Field<int>("id"),
                nombrePelicula = row.Field<string>("nombrePelicula"),
                descripcion = row.Field<string>("descripcion"),
                urlImagen = row.Field<string>("urlImagen"),
                precio = row.Field<decimal>("precio"),
                horario = row.Field<string>("horario")
            }).ToList();

            // Store the list in the session
            Session["listaPeliculas"] = listaPeliculas;

            // Iterate through the list of movies
            foreach (var item in listaPeliculas)
            {
                // Create a div for each movie
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerHtml += $"<div class='pelicula'> <div class='etiqueta'>ESTRENO</div> <img src='{item.urlImagen}' alt='{item.nombrePelicula}'></div>";

                // Add CSS class
                div.Attributes["class"] = "pelicula";

                // Add button
                Button btn = new Button();
                btn.Text = "Ver Horario";
                btn.ID = $"btnComprar-{item.id}";
                btn.CssClass = "boton";
                btn.Click += new EventHandler(btnComprar_Click);
                div.Controls.Add(btn);

                // Add the created div to the HTML form
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

