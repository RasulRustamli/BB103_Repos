let itemDeletedBtn = document.querySelectorAll(".item-delete")


itemDeletedBtn.forEach(btn => btn.addEventListener("click", function (e) {
    e.preventDefault();
    Swal.fire({
        title: "Eminmisin",
        text: "Bak geri donusu yok",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sil onu!!!!"
    }).then((result) => {
        if (result.isConfirmed) {
            let url = btn.getAttribute("href")
            fetch(url)
                .then(response => {
                    if (response.status == 200) {
                        Swal.fire({
                            title: "Deleted!",
                            text: "Silindi",
                            icon: "success"
                        })
                        window.location.reload(true);
                    }
                    else {
                        Swal.fire({
                            title: "Error!",
                            text: "Sene dedim axi silme",
                            icon: "error"
                        });
                    }

                })
        }
    });

}))