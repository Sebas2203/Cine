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
});