using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
                string qrCodeDataUrl = GenerateQRCode("25 Feb 2025 19:00:00");
                qrCodeImage.ImageUrl = qrCodeDataUrl;
            }
        }

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
                            string filePath = Server.MapPath("~/qr_codes/QRCode.png");
                            qrCodeImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                            return "/qr_codes/QRCode.png";
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
    }
}