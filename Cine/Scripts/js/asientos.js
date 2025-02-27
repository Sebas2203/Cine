



document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".seat.disponible").forEach(function (seat) {
        seat.addEventListener("click", function () {
            if (this.classList.contains("seleccionado")) {
                this.classList.remove("seleccionado");
                this.classList.add("disponible");
            } else {
                this.classList.remove("disponible");
                this.classList.add("seleccionado");
            }
        });
    });
});
