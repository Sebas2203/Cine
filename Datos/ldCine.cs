//using System;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;//ADO.NET


using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//leer información con ADO.net
using System.Configuration;
using System.Data;

namespace Datos
{
    public class ldCine
    {
        #region CONNECTION_STRING

        private SqlConnection _connection;

        public ldCine()
        {
            initConnection();
        }
        public void initConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        //public DataTable ObtenerPelicula()
        //{
        //    DataTable peliculasTable = new DataTable();

        //    try
        //    {
        //        _connection.Open();
        //        SqlCommand cmd = new SqlCommand("dbo.sp_ObtenerPeliculas", _connection);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        // Parámetro de salida  
        //        SqlParameter outputParam = new SqlParameter("@mensaje", SqlDbType.NVarChar, 100)
        //        {
        //            Direction = ParameterDirection.Output
        //        };
        //        cmd.Parameters.Add(outputParam);

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            peliculasTable.Load(reader);
        //        }

        //        return peliculasTable;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de errores  
        //        Console.WriteLine("Error: " + ex.Message);
        //        return peliculasTable;
        //    }
        //    finally
        //    {
        //        _connection.Close();
        //    }
        //}


        public DataTable ObtenerPelicula()
        {
            DataTable peliculasTable = new DataTable();

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_ObtenerPeliculas", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    peliculasTable.Load(reader);
                }

                return peliculasTable;
            }
            catch (Exception ex)
            {
                // Manejo de errores  
                Console.WriteLine("Error: " + ex.Message);
                return peliculasTable;
            }
            finally
            {
                _connection.Close();
            }
        }


        #endregion


        //register
        //public string RegistrarUsuario(string Email, string Pass)
        //{
        //    try
        //    {
        //        _connection.Open();
        //        SqlCommand cmd = new SqlCommand("dbo.sp_InsertarUsuario", _connection);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        // Parámetros de entrada
        //        cmd.Parameters.AddWithValue("@Email", Email);
        //        cmd.Parameters.AddWithValue("@Password", Pass);


        //        // Parámetro de salida
        //        SqlParameter outputParam = new SqlParameter("@mensaje", SqlDbType.NVarChar, 100)
        //        {
        //            Direction = ParameterDirection.Output
        //        };
        //        cmd.Parameters.Add(outputParam);

        //        cmd.ExecuteNonQuery();

        //        // Retornar el mensaje del SP
        //        return outputParam.Value.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Error: " + ex.Message;
        //    }
        //}

        //register
        public string RegistrarUsuario(string Email, string Pass)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_InsertarUsuario", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Solo los parámetros que el SP realmente espera
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Pass);

                cmd.ExecuteNonQuery();

                // Si no hay error, asumimos que fue exitoso
                return "Usuario registrado correctamente";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


        //log in
        public DataTable BuscarUsuario(string Email, string Pass)
        {
            DataTable dt = new DataTable();

            try
            {
                _connection.Open(); // Abre la conexión

                using (SqlCommand cmd = new SqlCommand("dbo.sp_ObtenerUsuarioPorEmail", _connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregamos los parámetros correctos
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                    cmd.Parameters.AddWithValue("@Password", string.IsNullOrEmpty(Pass) ? (object)DBNull.Value : Pass);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close(); // Siempre cerramos la conexión
            }

            return dt;
        }

        //metodo de factura a base de datos


    }
}