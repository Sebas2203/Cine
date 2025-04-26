using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Cine
{
    public partial class HomePage : System.Web.UI.Page
    {
        //lista de peliculas
        List<Peliculas> listaPeliculas = new List<Peliculas>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //agregar elementos a la lista de peliculas cuando se carga la pagina

        }

        protected void btnCartelera_Click(object sender, EventArgs e)
        {
            //redireccionar a la pagina de comprar entrada
            if (Session["UserLogin"] == null)
            {
                //Si no hay usuario logueado, redireccionar a la pagina de login
                System.Threading.Thread.Sleep(3000);
                Response.Redirect("Login.aspx");
            }
            else
            {
                //Si hay usuario logueado, redireccionar a la pagina de cartelera
                Response.Redirect("Cartelera.aspx");
            }
        }
    }
}