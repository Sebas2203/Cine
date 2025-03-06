using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Cine
{
    public partial class TempSeleccionAsientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InyectarCSS();
                CargarAsientos();
            }
        }

        // Cargar los asientos desde el XML
        private void CargarAsientos()
        {
            try
            {
                if (Session["pelicula"] == null)
                {
                    throw new Exception("No hay sesión.");
                }

                // Obtener el Ticket desde la sesión
                Ticket extractor = (Ticket)Session["pelicula"];

                if (extractor.pelicula == null)
                {
                    throw new Exception("No se encontró la película en el ticket.");
                }

                // Variable para almacenar los asientos en HTML
                string asientosHtml = "";
                int peliculaId = extractor.pelicula.id;

                // Verifica si el ID está dentro del rango válido (1-5)
                if (peliculaId >= 1 && peliculaId <= 5)
                {
                    string xmlPath = Server.MapPath($"DataFiles/{peliculaId}.xml");

                    if (System.IO.File.Exists(xmlPath)) // Verifica si el archivo XML existe
                    {
                        XDocument doc = XDocument.Load(xmlPath);

                        var asientos = doc.Descendants("asiento")
                                          .Select(a => new
                                          {
                                              Id = a.Attribute("id").Value,
                                              Estado = a.Attribute("estado").Value
                                          }).ToList();

                        if (asientos.Any()) // Verifica si hay asientos en el XML
                        {
                            char currentRow = ' ';

                            foreach (var asiento in asientos)
                            {
                                char row = asiento.Id[0];
                                string claseCss = "seat"; // Clase base siempre presente

                                if (asiento.Estado == "ocupado")
                                    claseCss += " ocupado";
                                else if (asiento.Estado == "seleccionado")
                                    claseCss += " seleccionado";
                                else
                                    claseCss += " disponible"; // Si no está ocupado ni seleccionado, es disponible

                                // Si es una nueva fila, agregamos la etiqueta con la letra de la fila
                                if (row != currentRow)
                                {
                                    asientosHtml += $"<div class='seat-label'>{row}</div>";
                                    currentRow = row;
                                }

                                // Generar el HTML de los asientos
                                asientosHtml += $"<div id='{asiento.Id}' class='{claseCss}'></div>";
                            }
                        }
                        else
                        {
                            asientosHtml = "<p style='color:red;'>No hay asientos disponibles en este momento.</p>";
                        }
                    }
                    else
                    {
                        asientosHtml = "<p style='color:red;'>Error: Archivo de asientos no encontrado.</p>";
                    }
                }

                // Asignar los asientos al contenedor en el ASPX
                AsientosContainer.InnerHtml = asientosHtml;
                System.Diagnostics.Debug.WriteLine(asientosHtml); // Esto imprime en la consola de depuración

            }
            catch (Exception ex)
            {
                AsientosContainer.InnerHtml = $"<p style='color:red;'>Error: {ex.Message}</p>";
            }
        }

        private void InyectarCSS()
        {
            string estilos = @"
        <style>
            /* Estilos generales */
            body {
                font-family: Arial, sans-serif;
                background-color: #1a1a1a;
                color: white;
                text-align: center;
                margin: 0;
                padding: 0;
            }

            /* Contenedor principal */
            .container {
                max-width: 800px;
                margin: 20px auto;
                padding: 20px;
                background-color: #2c2c2c;
                border-radius: 10px;
                box-shadow: 0px 0px 10px rgba(255, 255, 255, 0.2);
            }

            /* Encabezado de columnas */
            .seat-label-row {
                display: flex;
                justify-content: center;
                gap: 8px;
                margin-bottom: 10px;
                font-weight: bold;
            }

            .seat-label-row span {
                width: 30px;
                text-align: center;
            }

            /* Contenedor de los asientos */
            #AsientosContainer {
                display: grid;
                grid-template-columns: repeat(9, 30px); /* 8 columnas + 1 para la etiqueta de fila */
                gap: 8px;
                justify-content: center;
                align-items: center;
                background-color: #222;
                padding: 20px;
                border-radius: 10px;
                box-shadow: 0px 0px 8px rgba(255, 255, 255, 0.1);
            }

            /* Etiqueta de fila */
            .seat-label {
                font-weight: bold;
                display: flex;
                align-items: center;
                justify-content: center;
                width: 30px;
            }

            /* Estilos de los asientos */
            .seat {
                width: 25px;
                height: 25px;
                border-radius: 5px;
                display: flex;
                align-items: center;
                justify-content: center;
                font-size: 12px;
                color: white;
                cursor: pointer;
                transition: transform 0.2s ease, background-color 0.2s ease;
            }

            /* Estados de los asientos */
            .seat.disponible {
                background-color: blue;
            }

            .seat.ocupado {
                background-color: gray;
                cursor: not-allowed;
            }

            .seat.seleccionado {
                background-color: lightgray;
            }

            /* Efecto hover */
            .seat:hover {
                transform: scale(1.2);
            }

            /* Pantalla del cine */
            .screen {
                width: 90%;
                height: 40px;
                background-color: white;
                color: black;
                text-align: center;
                margin: 10px auto;
                line-height: 40px;
                font-weight: bold;
                border-radius: 5px;
            }
        </style>";

            // Agregar los estilos al <head> de la página
            LiteralControl cssLiteral = new LiteralControl(estilos);
            Page.Header.Controls.Add(cssLiteral);
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            // Obtener los asientos seleccionados desde sessionStorage (JS) vía Request.Form
            string selectedSeats = Request.Form["selectedSeatsHidden"];

            if (!string.IsNullOrEmpty(selectedSeats))
            {
                // Convertir la lista de asientos seleccionados en un array
                string[] asientosArray = selectedSeats.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Guardar los asientos en la variable de sesión
                Session["asientosSeleccionados"] = selectedSeats;

                // Guardar la cantidad de asientos seleccionados en la sesión
                int cantidadAsientos = asientosArray.Length;
                Session["cantidadAsientos"] = cantidadAsientos;

                Response.Redirect("Factura.aspx");
            }
            else
            {
                // Si no se seleccionaron asientos, mostrar un mensaje de error
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, seleccione al menos un asiento.');", true);
                //Response.Redirect("Factura.aspx");
            }
        }




    }
}