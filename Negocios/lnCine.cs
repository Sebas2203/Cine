using System;
using System.Data;
using System.Data.SqlClient;


namespace Negocios
{
    public class lnCine
    {
        //metodo que consulta articulos en la capa de datos  
        public DataTable ObtenerPeliculas_Negocios()
        {
            try
            {
                //instanciar la capa de datos  
                Datos.ldCine datos = new Datos.ldCine();

                //se ejecuta la llamada  
                var resultado = datos.ObtenerPelicula();

                //si se require, se realiza una validacion de la info obtenida de la capa de datos  

                //retorna el resultado  
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //metodo de login
        public bool Login(string email, string password, out string mensaje)
        {
            using (SqlConnection conn = new SqlConnection("connection string"))  // cambiar connection string
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email AND Pass = @Pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Pass", password);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    mensaje = "Login exitoso";
                    return true;
                }

                mensaje = "Credenciales incorrectas";
                return false;
            }
        }
        //metodo de registro
        public bool RegistrarUsuario(string email, string password, int tipoUsuario)
        {
            using (SqlConnection conn = new SqlConnection("connection string"))  // cambiar connection string
            {
                string query = "INSERT INTO Usuarios (Email, Pass, Tipo_Usuario) VALUES (@Email, @Pass, @Tipo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Pass", password);
                cmd.Parameters.AddWithValue("@Tipo", tipoUsuario);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
        //metodos factura
        public bool RegistrarReserva(int idUsuario, string numeroReserva, DateTime fecha)
        {
            using (SqlConnection conn = new SqlConnection("connection string"))  // cambiar connection string
            {
                string query = @"INSERT INTO Reservas (Numero_Reserva, ID_Usuario, Fecha) 
                         VALUES (@NumeroReserva, @ID_Usuario, @Fecha)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NumeroReserva", numeroReserva);
                cmd.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                cmd.Parameters.AddWithValue("@Fecha", fecha);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
