using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//ADO.NET
using System.Configuration;
using System.Data;

namespace Datos
{
    public class ldCine
    {
        #region connection string  

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

        public DataTable ObtenerPelicula()
        {
            DataTable peliculasTable = new DataTable();

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_ObtenerPeliculas", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetro de salida  
                SqlParameter outputParam = new SqlParameter("@mensaje", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

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

        public string RegistrarUsuario(string Email, string Pass)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_InsertarUsuario", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Pass);


                // Parámetro de salida
                SqlParameter outputParam = new SqlParameter("@mensaje", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                cmd.ExecuteNonQuery();

                // Retornar el mensaje del SP
                return outputParam.Value.ToString();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }




    }
}