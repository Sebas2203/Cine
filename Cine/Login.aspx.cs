using System;
using System.Collections.Generic;
using System.Web.UI;
using Negocios;

namespace Cine
{
    public partial class Login : System.Web.UI.Page
    {
        private lnCine _negocios = new lnCine();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                mensajeTexto.InnerText = "Su sesión ya fue iniciada. Redireccionando a la cartelera.";
                System.Threading.Thread.Sleep(3000);
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            var usuario = _negocios.BuscarUsuario_Negocios(email, password);

            User user = new User();

            // Validar el usuario
            if (usuario.Rows.Count > 0)
            {
                user.username = usuario.Rows[0]["Email"].ToString();
                user.password = usuario.Rows[0]["Pass"].ToString();
                Session["UserLogin"] = user;
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                mensajeTexto.InnerText = "Usuario o contraseña incorrectos. Por favor, intente de nuevo.";
                divMensaje.Style["display"] = "block";
            }
        }

        

    }
}