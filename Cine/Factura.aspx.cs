using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using QRCoder;
using static QRCoder.PayloadGenerator;

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
                RegistrarReservaYFactura(qrCodeDataUrl + DateTime.Now.ToString());

                ////esto carga la cantidad de asientos seleccionados para usar el dato en una operación para conseguir el total a cobrar. 
                //if (Session["asientosSeleccionados"] != null && Session["cantidadAsientos"] != null)
                //{
                //    string asientos = Session["asientosSeleccionados"].ToString();
                //    int cantidad = (int)Session["cantidadAsientos"];

                //    // Definir el precio de cada asiento (puedes cambiarlo según sea necesario)
                //    int precioPorAsiento = 5000;

                //    // Calcular el total a pagar
                //    int total = cantidad * precioPorAsiento;

                //    //esto podría ir en el aspx. para poder tener un display de la informacion:::

                //    //< asp:Label ID = "lblAsientosSeleccionados" runat = "server" CssClass = "asientos-info" />< br />
                //    //< asp:Label ID = "lblCantidad" runat = "server" CssClass = "cantidad-info" />< br />
                //    //< asp:Label ID = "lblTotal" runat = "server" CssClass = "total-info" />

                //    //para que se vea así
                //    //Asientos seleccionados: A1, A2, B4
                //    //Cantidad de asientos: 3
                //    //Total a pagar: ₡15000



                //    lblAsientosSeleccionados.Text = "Asientos seleccionados: " + asientos;
                //    lblCantidad.Text = "Cantidad de asientos: " + cantidad;
                //    lblTotal.Text = "Total a pagar: ₡" + total;
                //}
                //else
                //{
                //    lblAsientosSeleccionados.Text = "No hay asientos seleccionados.";
                //    lblCantidad.Text = "";
                //    lblTotal.Text = "";
                //}
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
                if ((Session["pelicula"] != null) && (Session["UserLogin"] != null))
                {
                    Ticket datosPeli = (Ticket)Session["pelicula"];
                    User datosUsuario = (User)Session["UserLogin"];
                    int cantidadAsientos = (int)Session["cantidadAsientos"];

                    divDetalles.InnerHtml = $@"
                    <div class='containerTicket'>
                        <h3 class='cliente'>Correo de cliente: {datosUsuario.username}</h3>
                        <h2 class='tituloPeli'>{datosPeli.pelicula.nombrePelicula}</h2>
                        <p class='hora'> Hora de función: {datosPeli.pelicula.horario}</p>
                        <p class='asientos'> Cantidad de asientos: {cantidadAsientos}</p>
                        <p class='precio'>Total IVAI: ₡{datosPeli.pelicula.precio * cantidadAsientos}</p>
                    </div>
                    ";

                    QRString = datosPeli.pelicula.nombrePelicula + datosPeli.pelicula.horario.ToString() + datosUsuario.username;
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
            catch (Exception ex)
            {
                QRString = null;
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }
            return QRString;
        }

        public int ObtenerIDUsuario()
        {
            try
            {
                // Obtener el correo electrónico del usuario desde la sesión
                User datosUsuario = (User)Session["UserLogin"];
                string email = datosUsuario.username;

                // Crear una instancia de la capa de negocios
                Negocios.lnCine negocio = new Negocios.lnCine();

                // Llamar al método para obtener el ID del usuario
                int idUsuario = negocio.ObtenerIDUsuario_Negocios(email);
                return idUsuario;
            }
            catch (Exception ex)
            {
                mensajeTexto.InnerText = "Error: " + ex.Message;
                divMensaje.Style["display"] = "block";
                return -1; // Error al obtener el ID
            }
        }


        //nuevo metodo (tiene que hacer la instancia a negocios)
        public string RegistrarReservaYFactura(string QR)
        {
            try
            {

                // Obtener el ID del usuario desde la sesión
                User datosUsuario = (User)Session["UserLogin"];
                int idUsuario = ObtenerIDUsuario();

                // Obtener el ID de la película desde la sesión
                Ticket datosPeli = (Ticket)Session["pelicula"];
                int idPelicula = datosPeli.pelicula.id;

                // Obtener el número de reserva y la cantidad de asientos desde la sesión
                string numeroReserva = QR;
                int cantidadAsientos = (int)Session["cantidadAsientos"];

                // Crear una instancia de la capa de negocios
                Negocios.lnCine negocio = new Negocios.lnCine();

                // Llamar al método para crear la reserva y factura
                int idFactura = negocio.CrearReservaYFactura_Negocios(idUsuario, idPelicula, numeroReserva, cantidadAsientos);
                return "Factura creada con éxito. ID de factura: " + idFactura;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

        }
    }
}