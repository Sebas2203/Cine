<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="tickets.aspx.cs" Inherits="Cine.tickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="tituloTickets">Tickets</h1>
    <asp:Button ID="comprarTicket" CssClass="comprarTicket" runat="server" Text="Comprar" OnClick="comprarTicket_Click" />
    <div id="divCompras" runat="server">
    </div>

</asp:Content>
