<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="Cine.Factura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/css/template/FacturaStyle.css"/>
    <title>Tiquete de entrada</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="ticket-container">
            <div class="ticket-header">
                <h1>Cine UH</h1>
                <p>Comprobante de entrada</p>
            </div>
            <div class="ticket-body">
                <div class="event-details">
                    <h2>Event Name</h2>
                    <p>Asiento(s): </p>
                    <p>Precio IVAI: </p>
                </div>
                <div class="qr-code">
                    <asp:Image ID="qrCodeImage" runat="server" alt="QR Code" />
                </div>
            </div>
            <div style="text-align: left; margin-top: 20px;">
                <button type="button" onclick="printTicket()">Imprimir Boleto</button>
            </div>
            <div class="ticket-footer">
            </div>
        </div>
            <div class="dialog-container" id="divMensaje" style="display: none;" runat="server">
                <div class="message-box">
                    <div id="mensajeContenido">
                        <span id="mensajeTexto" runat="server"></span>
                        <button id="cerrarMensaje" class="btnClass btnMensaje" onclick="cerrarMensaje()">Cerrar</button>
                    </div>
                 </div>
            </div>
    </form>
</body>
</html>
