//Peliculas

var title = {
    0: {
        title: "Rápidos y Furiosos: Tokyo Drift",
        Subtitle: "",
        desc: "",
    },
    1: {
        title: "La tumba de las Luciernagas",
        Subtitle: "",
        desc: "",
    },
    2: {
        title: "Star Wars: Episodio 3",
        Subtitle: "",
        desc: "",
    },
    3: {
        title: "Dune",
        Subtitle: "",
        desc: "",
    },
};

//swiper
//crear los thumbs swiper
var thumbsSwiper = new Swiper(".thumbsSwiper", {
    spaceBetween: 10,
    slidesPervView: 5,
    breakpoints: {
        200: {
            slidesPerView: 1.5
        },
        400: {
            slidesPerView: 1.5
        },
        600: {
            slidesPerView: 3
        },
        1100: {
            slidesPerView: 5
        },
    },
    freeMode: true,
    watchSlideProgress: true,
})

const swiper = new Swiper('.bannerSwiper', {
    spaceBetween: 0,
    effect: 'fade',

    // If we need pagination
    pagination: {
        el: '.swiper-pagination',
        clickable: true
    },

    // Navigation arrows
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },

    // hacer tumbs slider funcione como thumbs para los banners
    thumbs: {
        swiper: thumbsSwiper
    }
});
