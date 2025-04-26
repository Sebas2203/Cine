using Negocios;
using System;
using System.Web.UI;

namespace Cine
{
    public partial class Register : System.Web.UI.Page
    {
        private lnCine _negocios = new lnCine(); // Instancia de la capa de negocios

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                //envia los credenciales a Negocio para registrarse en Datos. 
                string resultado = _negocios.RegistrarUsuario_Negocio(email, password);

                if (resultado.Contains("éxito") || resultado.Contains("exitosamente"))
                {
                    mensajeTexto.InnerText = "Usuario registrado exitosamente.";
                    divMensaje.Style["display"] = "block";
                }
                else
                {
                    mensajeTexto.InnerText = resultado;
                    divMensaje.Style["display"] = "block";
                }
            }
            catch (Exception ex)
            {
                mensajeTexto.InnerText = "Error al registrar usuario: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }
        }
    }
}
