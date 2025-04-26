using System;
using System.Data;
using Datos;

namespace Negocios
{
    public class lnCine
    {
        private ldCine _datos;

        public lnCine()
        {
            _datos = new ldCine(); // Instancia de la capa de datos
        }

        // Método para obtener las películas
        public DataTable ObtenerPeliculas_Negocios()
        {
            try
            {
                var resultado = _datos.ObtenerPelicula();
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Método para registrar un nuevo usuario
        public string RegistrarUsuario_Negocio(string email, string pass)
        {
            try
            {
                return _datos.RegistrarUsuario(email, pass);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Método para buscar un usuario (login)
        public DataTable BuscarUsuario_Negocios(string email, string pass)
        {
            try
            {
                return _datos.BuscarUsuario(email, pass);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
