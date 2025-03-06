<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TempSeleccionAsientos.aspx.cs" Inherits="Cine.TempSeleccionAsientos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Selección de asientos</title>
    <link href="css\asientos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor1">
            <h1>Selección de asientos</h1>

            <!-- Encabezado de columnas -->
            <div class="seat-label-row">
                <span></span>
                <!-- Espacio vacío para alinear con las filas -->
                <span>1</span> <span>2</span> <span>3</span> <span>4</span> <span>5</span> <span>6</span> <span>7</span> <span>8</span>
            </div>

            <div id="AsientosContainer" runat="server" class="asientos-container">
            </div>
            <%--carga dinámicamente los asientos con base en el XML.--%>
        </div>
        <asp:Button ID="btnContinuar" runat="server" CssClass="btn-continuar"
            Text="Continuar con la compra" OnClick="btnContinuar_Click" />

        <input type="hidden" id="selectedSeatsHidden" name="selectedSeatsHidden" />
    </form>
    <script src="Scripts/js/asientos.js"></script>
</body>
</html>
