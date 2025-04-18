using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
