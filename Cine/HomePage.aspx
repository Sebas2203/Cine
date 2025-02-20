<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Cine.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Banner --%>
    <div class="banner">
        <%-- Swiper --%>
        <div class="swiper bannerSwiper">
            <!-- Additional required wrapper -->
            <div class="swiper-wrapper">
                <!-- Slides -->
                <div class="swiper-slide">
                    <img src="content\media\dune.jpg" alt="dune"/>
                </div>
                <div class="swiper-slide">
                    <img src="content\media\tokyo.jpg" alt="Tokyo Drift"/>
                </div>
                <div class="swiper-slide">
                    <img src="content\media\starwars.jpg" alt="Star Wars"/>
                </div>
                <div class="swiper-slide">
                    <img src="content\media\tumba.jpg" alt="La tumba de las Lurciernagas"/>
                </div>
                ...
            </div>
            <!-- If we need pagination -->
            <div class="swiper-pagination"></div>

            <!-- If we need navigation buttons -->
            <div class="swiper-button-prev"></div>
            <div class="swiper-button-next"></div>

        </div>

    </div>

    <%-- Content --%>
    <%-- Movies Thumbs --%>
</asp:Content>
