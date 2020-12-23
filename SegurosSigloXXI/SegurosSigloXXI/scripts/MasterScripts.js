/*
 *  On Content Loaded
 */
$(".btn-action").on("click", function () {
    $(".container-actions").slideToggle(200);
});

$(window).on("scroll", function () {
    if (window.pageYOffset > 0) {
        $(".navigation-flex").addClass("onScroll");
    } else {
        $(".navigation-flex").removeClass("onScroll");
    }
});

document.addEventListener("DOMContentLoaded", () => {
    onLoadDelete();
});

function onLoadDelete() {
    if (localStorage.getItem(currentPage()) !== null) {
        const deletedRows = JSON.parse(localStorage.getItem(currentPage()));
        const table = document.querySelector("table");
        for (var i = 0; i < deletedRows.length; i++) {
            table.deleteRow(parseInt(deletedRows[i]));
        }
    }
}

function currentPage() {
    const url = window.location.pathname.substr(1);
    const pathNames = `frmMantenimientoCliente,frmCoberturaPoliza,
                        frmAdiccionCliente,frmRegistroPoliza,
                        frmAdiccion`.split(",");
    for (var i = 0; i < pathNames.length; i++) {
        const current = pathNames[i];
        if (url.match(current)) {
            return pathNames[i];
        }
    }
    return "";
}

function deleteRegister(element) {
    const parent = element.parentElement.parentElement;
    const table = parent.parentElement;
    const index = parent.rowIndex;
    const page = currentPage();
    let deletedRows;

    table.deleteRow(parseInt(index));
    actionMessage("success", "Registro eliminado correctamente")

    if (typeof (Storage) !== "undefined") {
        if (localStorage.getItem(page) !== null) {
            deletedRows = JSON.parse(localStorage.getItem(page));
        }
        else {
            deletedRows = [];
        }
        deletedRows.push(index);
        localStorage.setItem(page, JSON.stringify(deletedRows));

    } else {
        actionMessage("info", "Almacenamiento local no soportado")
    }
}

function actionMessage(icon, message) {
    Swal.fire({
        icon: icon,
        timer: 2000,
        title: message,
        timerProgressBar: true,
        showConfirmButtonk: false,
    })
}