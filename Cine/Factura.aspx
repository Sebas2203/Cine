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
                <h1>Event Ticket</h1>
                <p>Event Date: 25th Feb 2025</p>
            </div>
            <div class="ticket-body">
                <div class="event-details">
                    <h2>Event Name</h2>
                    <p>Location: Main Hall, City Center</p>
                    <p>Seat: A12</p>
                    <p>Time: 7:00 PM</p>
                </div>
                <div class="qr-code">
                    <asp:Image ID="qrCodeImage" runat="server" alt="QR Code" />
                </div>
            </div>
            <div class="ticket-footer">
                <p>Powered by XYZ Ticketing</p>
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
