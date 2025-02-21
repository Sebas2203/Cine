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
                ...
            </div>
        </div>
    </div>

    <%-- Content --%>
    <div class="content">
        <div class="title">
            <div id="title">
                <h1>Movie Name</h1>
            </div>
            <div id="sub-title">
                <p>Sub title</p>
            </div>
            <div class="rating">
                <i class="fa-solid fa-star"></i>
            </div>
            <div class="button">
                <button>
                    Trailer
                </button>
            </div>
        </div>
        <div class="desc">
            <!-- Swiper navigation buttons -->
            <div class="navigation-btn">
                <div class="swiper-button-prev"></div>
                <div class="swiper-button-next"></div>
            </div>
            <div id="desc">
                <p>Descripcion pelicula</p>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Comprar Entrada" class="btn-primary" />
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
            </div>
        </div>
    </div>


</asp:Content>
