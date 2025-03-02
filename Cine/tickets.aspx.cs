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
                    throw new Exception("No hay sesión");
                }

                // Obtener el Ticket desde la sesión
                Ticket extractor = (Ticket)Session["pelicula"];

                if (extractor.pelicula == null)
                {
                    throw new Exception("No se encontró la película en el ticket.");
                }

                // Mostrar los datos en el div
                divCompras.InnerHtml = $@"
                    <div class='containerTicket'>
                        <h2 class='tituloPeli'>{extractor.pelicula.nombrePelicula}</h2>
                        <h3 class='desc'>{extractor.pelicula.descripcion}</h3>
                        <p class='precio'>Precio: ₡{extractor.pelicula.precio}</p>
                        <p class='hora'> Hora de función: {extractor.pelicula.horario}</p>
                        <img src='{extractor.pelicula.urlImagen}' width='300' class='imagenPeli'>
                    </div>
                ";


            }
            catch (Exception ex)
            {
                divCompras.InnerHtml = $"<p style='color:red;'>Error: {ex.Message}</p>";
            }
            
        }

        protected void comprarTicket_Click(object sender, EventArgs e)
        {
            //redireccionar a la pagina de comprar entrada
            if (Session["UserLogin"] == null)
            {
                //Si no hay usuario logueado, redireccionar a la pagina de login
                System.Threading.Thread.Sleep(3000);
                Response.Redirect("tickets.aspx");
            }
            else
            {
                //Si hay usuario logueado, redireccionar a la pagina de cartelera
                Response.Redirect("tempSeleccionAsientos.aspx");
            }
        }
    }
}