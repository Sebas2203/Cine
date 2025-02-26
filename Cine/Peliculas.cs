using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine
{
    public class Peliculas
    {
        //atributos de la clase Peliculas
        public int id { get; set; }
        public string nombrePelicula { get; set; }
        public string descripcion { get; set; }
        public string urlImagen { get; set; }
        public decimal precio { get; set; }
    }
}