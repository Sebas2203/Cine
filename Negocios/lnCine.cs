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
            _datos = new ldCine();
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
        public string RegistrarUsuario_Negocios(string email, string pass)
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

        //---FACTURA---

        // Método buscar id Usuario
        public int ObtenerIDUsuario_Negocios(string email)
        {
            try
            {
                return _datos.ObtenerIDUsuario(email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Método CrearReservaYFactura
        public int CrearReservaYFactura_Negocios(int idUsuario, int idPelicula, string numeroReserva, int cantidadAsientos)
        {
            try
            {
                return _datos.CrearReservaYFactura(idUsuario, idPelicula, numeroReserva, cantidadAsientos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Método ObtenerFacturaFinal
        public DataTable ObtenerFacturaFinal_Negocios(int idFactura)
        {
            try
            {
                return _datos.ObtenerFacturaFinal(idFactura);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
