//Peliculas

var title = {

    0: {
        title: "Dune",
        Subtitle: "Ciencia Ficción/Aventura/Drama",
        desc: "Dune (2021) es una película de ciencia ficción dirigida por Denis Villeneuve, basada en la novela homónima de Frank Herbert. La historia sigue a Paul Atreides, un joven noble con un destino grandioso, cuya familia es enviada al peligroso planeta Arrakis para administrar la extracción de la especia melange, el recurso más valioso del universo. Sin embargo, una traición mortal obliga a Paul y a su madre a refugiarse entre los Fremen, los habitantes del desierto, donde deberá enfrentar su destino y descubrir su verdadero poder.",
    },
    1: {
        title: "Rápidos y Furiosos: Tokyo Drift",
        Subtitle: "Acción/Carreras Automovilísticas",
        desc: "The Fast and the Furious: Tokyo Drift (2006) es la tercera entrega de la saga Rápidos y Furiosos. La película sigue a Sean Boswell, un joven aficionado a las carreras ilegales, quien es enviado a Tokio para evitar problemas legales en Estados Unidos. Allí descubre el mundo de las carreras clandestinas de drifting y se enfrenta a un piloto local con conexiones con la mafia Yakuza. Con la ayuda de su amigo Han, Sean aprende las técnicas del drift y se prepara para desafiar a su rival en una carrera definitiva.",
    },

    2: {
        title: "Star Wars: Episodio 3",
        Subtitle: "Ciencia Ficción/Aventura/Drama",
        desc: "Star Wars: Episode III – Revenge of the Sith (2005) es la tercera entrega de la trilogía precuela de Star Wars, dirigida por George Lucas. La historia sigue los últimos días de la República Galáctica y la caída de Anakin Skywalker hacia el lado oscuro. Mientras la Guerra de los Clones llega a su fin, el canciller Palpatine revela su verdadera identidad como Darth Sidious y manipula a Anakin, quien se convierte en Darth Vader. Obi-Wan Kenobi y Yoda intentan detener la purga Jedi, pero el Imperio surge y la galaxia cae bajo el dominio de los Sith.",
    },
    3: {
        title: "La tumba de las Luciernagas",
        Subtitle: "Drama/Bélico/Tragedia",
        desc: "La tumba de las luciérnagas (1988) es una película de animación japonesa dirigida por Isao Takahata y producida por Studio Ghibli. La historia sigue a Seita y su hermana pequeña Setsuko, dos niños que luchan por sobrevivir en Japón durante los últimos meses de la Segunda Guerra Mundial. Tras perder a su madre en un bombardeo y quedar sin hogar, los hermanos enfrentan el hambre, la indiferencia de la sociedad y las dificultades de la guerra mientras intentan mantenerse juntos.",
    },
    4: {
        title: "The Godfathe",
        Subtitle: "Crimen/Drama/Thriller",
        desc: "El Padrino (The Godfather, 1972) es una película de crimen y drama dirigida por Francis Ford Coppola, basada en la novela de Mario Puzo. La historia sigue a la familia Corleone, una de las mafias más poderosas de Nueva York, y su líder, Vito Corleone. Tras un intento de asesinato contra él, su hijo Michael, quien inicialmente quería mantenerse alejado del mundo criminal, se ve arrastrado al negocio familiar, transformándose en un líder despiadado.",
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

//cambiar titulos
var changeTitle = (index) => {
    var title = document.querySelector('#title');
    var subTitle = document.querySelector('#sub-title');
    var desc = document.querySelector('#desc');
    title.innerHTML = `<h1>${title[index].title}</h1>`;
    subTitle.innerHTML = `<p>${title[index].subTitle}</p>`;
    desc.innerHTML = `<p>${title[index].desc}</p>`;
}

swiper.on('activeIndexChange', function () {
    changeTitle(swiper.activeIndex)
})

