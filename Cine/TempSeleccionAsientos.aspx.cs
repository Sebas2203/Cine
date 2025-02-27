using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Cine
{
    public partial class TempSeleccionAsientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAsientos();
            }
        }

        // CargarAsientos() recorre los asientos y su estado en el XML, y dentro del foreach va creando un div con un ID unico 
        // por cada asiento.Ese div está en la línea 13 del aspx. 
        // Vamos a necesitar crear un XML por cada película en cartelera y reutilizar el script y el estilo.  

        private void CargarAsientos() 
        {
            string xmlPath = Server.MapPath("DataFiles/asientos.xml");
            XDocument doc = XDocument.Load(xmlPath);

            var asientos = doc.Descendants("asiento")
                              .Select(a => new
                              {
                                  Id = a.Attribute("id").Value,
                                  Estado = a.Attribute("estado").Value
                              });

            foreach (var asiento in asientos)
            {
                string claseCss = "seat disponible"; // Estado por defecto

                if (asiento.Estado == "ocupado")
                    claseCss = "seat ocupado";
                else if (asiento.Estado == "seleccionado")
                    claseCss = "seat seleccionado";

                LiteralControl seatDiv = new LiteralControl($"<div id='{asiento.Id}' class='{claseCss}'></div>");
                AsientosContainer.Controls.Add(seatDiv);
            }
        }
    }
}