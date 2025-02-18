<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cine.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container">
        <h2>Inicio de Sesión</h2>
        <br />
        <asp:TextBox ID="txtUsername" placeholder="Correo Electónico" runat="server" />
        <br />
        <asp:RegularExpressionValidator
            ID="EmailValidator" runat="server" ControlToValidate="txtUsername" ErrorMessage="Por favor ingrese un correo válido." ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ForeColor="Red">
        </asp:RegularExpressionValidator>

        <br />
        <asp:TextBox ID="txtPassword" placeholder="Contraseña" runat="server" TextMode="Password" />
        <br />
        <br />
        <asp:Button ID="btnLogin" CssClass="login-button" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <br />
        <a>¿No tiene cuenta?</a>
        <a href="register.aspx" runat="server">Registrar</a>
    </div>

    <div class="dialog-container" id="divMensaje" style="display: none;" runat="server">
        <div class="message-box">
            <div id="mensajeContenido">
                <span id="mensajeTexto" runat="server"></span>
                <button id="cerrarMensaje" class="btnClass btnMensaje" onclick="cerrarMensaje()">Cerrar</button>
            </div>
        </div>
    </div>


</asp:Content>
