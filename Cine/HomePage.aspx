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
                    <img src="content\media\dune.jpg" alt="dune" />
                </div>
                <div class="swiper-slide">
                    <img src="content\media\tokyo.jpg" alt="Tokyo Drift" />
                </div>
                <div class="swiper-slide">
                    <img src="content\media\starwars.jpg" alt="Star Wars" />
                </div>
                <div class="swiper-slide">
                    <img src="content\media\tumba.jpg" alt="La tumba de las Lurciernagas" />
                </div>
                <div class="swiper-slide">
                    <img src="content\media\thegodfather.jpg" alt="The GodFather" />
                </div>
                ...
            </div>
        </div>
    </div>

    <%-- Content --%>
    <div class="content">
        <div class="title">
            <div id="title">
                <h1>Dune</h1>
            </div>
            <div id="sub-title">
                <p>Ciencia Ficción/Aventura/Drama</p>
            </div>
        </div>
        <div class="desc">
            <!-- Swiper navigation buttons -->
            <div class="navigation-btn">
                <div class="swiper-button-prev"></div>
                <div class="swiper-button-next"></div>
            </div>
            <div id="desc">
                <p>Dune (2021) es una película de ciencia ficción dirigida por Denis Villeneuve, basada en la novela homónima de Frank Herbert. La historia sigue a Paul Atreides, un joven noble con un destino grandioso, cuya familia es enviada al peligroso planeta Arrakis para administrar la extracción de la especia melange, el recurso más valioso del universo. Sin embargo, una traición mortal obliga a Paul y a su madre a refugiarse entre los Fremen, los habitantes del desierto, donde deberá enfrentar su destino y descubrir su verdadero poder</p>
            </div>
            <asp:Button ID="btnCartelera" runat="server" Text="Ver Horarios" CssClass="btn-primary" Onclick="btnCartelera_Click"/>
        </div>
        <!-- Swiper pagination -->
        <div class="swiper-pagination"></div>
    </div>

    <%-- Movies Thumbs --%>
    <div class="thumbs">
        <div thumbsslider="" class="swiper thumbsSwiper">
            <div class="swiper-wrapper">
                <div class="swiper-slide">
                    <img src="content\media\banner-dune.jpg" />
                </div>
                <div class="swiper-slide">
                    <img src="content\media\banner-tokyo.jpg" />
                </div>
                <div class="swiper-slide">
                    <img src="content\media\banner-starwars.jpg" />
                </div>
                <div class="swiper-slide">
                    <img src="content\media\banner-tumba.jpg" />
                </div>
                <div class="swiper-slide">
                    <img src="content\media\banner-god.jpg" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
