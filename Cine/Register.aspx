<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Cine.Register1" %>

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
        <%-- <asp:Button ID="btnRegistrar" CssClass="login-button" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" /> --%>
    </div>
    <div>
    </div>
    </form>

 <div class="dialog-container" id="divMensaje" style="display: none;" runat="server">
     <div class="message-box">
         <div id="mensajeContenido">
             <span id="mensajeTexto" runat="server"></span>
             <button id="cerrarMensaje" class="btnClass btnMensaje" onclick="cerrarMensaje()">Cerrar</button>
         </div>
     </div>
 </div>
</asp:Content>
