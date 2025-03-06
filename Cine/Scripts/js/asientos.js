
document.addEventListener("DOMContentLoaded", function () {
    let selectedSeats = [];

    document.querySelectorAll(".seat").forEach(seat => {
        seat.addEventListener("click", function () {
            if (!this.classList.contains("ocupado")) {
                this.classList.toggle("seleccionado");

                let seatId = this.id;
                if (this.classList.contains("seleccionado")) {
                    selectedSeats.push(seatId);
                } else {
                    selectedSeats = selectedSeats.filter(s => s !== seatId);
                }

                // Guardar asientos seleccionados en localStorage para pasarlos al backend
                sessionStorage.setItem("selectedSeats", JSON.stringify(selectedSeats));
            }
        });

    });
    document.getElementById('btnContinuar').addEventListener('click', function () {
        // Retrieve selected seats from sessionStorage
        let storedSeats = sessionStorage.getItem('selectedSeats');

        // Set the hidden input field value to the selected seats
        document.getElementById('selectedSeatsHidden').value = storedSeats ? storedSeats : '';

        // Optionally: Clear sessionStorage after storing (depending on your use case)
        // sessionStorage.removeItem('selectedSeats');
    });
});
