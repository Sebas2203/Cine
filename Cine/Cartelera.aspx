<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Cartelera.aspx.cs" Inherits="Cine.Cartelera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Container">
        <h1 class="CarteleraTitulo">Cartelera</h1>
        <div id="cartelera" runat="server" class="cartelera">

        </div>

    </div>
</asp:Content>
