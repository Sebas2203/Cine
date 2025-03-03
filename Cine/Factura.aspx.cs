using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;

namespace Cine
{
    public partial class Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string qrCodeDataUrl = GenerateQRCode(DatosFactura()); //genera el QR con el string que sale del metodo DatosFactura, ademas de llenar el div los datos de la pelicula seleccionada
                qrCodeImage.ImageUrl = qrCodeDataUrl;
            }
        }


        //Codigo para preparar la generacion del QR con un String por parametro
        public string GenerateQRCode(string text)
        {
            try
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                        {
                            string filePath = Server.MapPath("Content/QRCodes/QRCode.png");
                            qrCodeImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                            return "Content/QRCodes/QRCode.png";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
                return string.Empty;
            }
        }

        //Codigo para generar el string para el QR, y tambien para llenar el DIV con los datos de la pelicula
        protected string DatosFactura()
        {
            string QRString;
            try
            {
                if ( (Session["pelicula"] != null) && (Session["UserLogin"] != null) )
                {
                    Peliculas datosPeli = (Peliculas)Session["pelicula"];
                    User datosUsuario = (User)Session["UserLogin"];
                    
                    divDetalles.InnerHtml = $@"
                    <div class='containerTicket'>
                        <h3 class='cliente'>Correo de cliente: {datosUsuario.username}</h3>
                        <h2 class='tituloPeli'>{datosPeli.nombrePelicula}</h2>
                        <p class='hora'> Hora de función: {datosPeli.horario}</p>
                        <p class='precio'>Total IVAI: ₡{datosPeli.precio}</p> //falta hacer calculo basado en el numero de asientos seleccionados
                    </div>
                    ";

                    QRString = datosPeli.nombrePelicula+datosPeli.horario.ToString()+datosUsuario.username;
                }
                else
                {
                    QRString = null;
                    mensajeTexto.InnerText = "Ocurrió un error. Será redireccionado a la pagina principal.";
                    divMensaje.Style["display"] = "block";
                    Thread.Sleep(3000);
                    Response.Redirect("HomePage.aspx"); 
                }

            }
            catch (Exception ex) {
                QRString = null;
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }
            return QRString;
        }
    }
}