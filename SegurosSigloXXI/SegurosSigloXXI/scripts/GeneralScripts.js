document.addEventListener("DOMContentLoaded", () => {
    const sl = document.querySelectorAll("select");
    if (sl !== null) {
        sl.forEach(item => { item.selectedIndex = "-1" });
    }
    resetDefault();

    $(".btnRegistrar").on("click", function () {
        $(".modal").fadeIn(200).css({ display: "flex" });
    });

    $("#cerrar").on("click", function () {
        $(".modal").fadeOut(200, function () {
            $(this).css({ display: "none" });
            document.forms[0].reset();
        });
    });
});

function resetDefault() {
    [].forEach.call(document.forms[0].elements, (item) => {
        if (item.type != "submit")
            item.setAttribute("autocomplete", false);
    });
}