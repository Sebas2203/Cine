<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TempSeleccionAsientos.aspx.cs" Inherits="Cine.TempSeleccionAsientos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" heref="css/asientos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="asientos-container" runat="server"></div> <%--carga dinámicamente los asientos con base en el XML.--%> 
        </div>
    </form>
    <script src="Scripts/js/asientos.js"></script>
</body>
</html>
