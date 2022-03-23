////-------------------------------------------------------------------------------------
$(".verCliente").click(function () {
    var ClienteId = $(this).attr("data-id");
    var ggg = $.ajax({
        url: "/Usuario/Customer/ObtenerCliente",
        type: "POST",
        data: {
            "ClienteId": ClienteId
        }
    });
    ggg.done(function (data) {
        $(".valorNombre").text(data.messageNombre);
        $(".valorDireccion").text(data.messageDireccion);
        $(".valorTelefono").text(data.messageTelefono);
        $(".valorEmail").text(data.messageEmail);
        $("#exampleModalCliente").modal("show");
    });
    ggg.fail(function () { });
    toastr.error(data.message);
})
//---------------------------------------------------------------------------------
$(".verRecibos").click(function () {
    var Id = $(this).attr("data-id");
    var ggg = $.ajax({
        url: "/Usuario/Recibos/ObtenerReciboxPrestamos",
        type: "POST",
        data: {
            "Id": Id
        }
    });
    ggg.done(function (data) {
        $(".valordescr").text(data.messageDescripcion);
        $(".valorMonto").text(data.messageMonto);
        $(".valorcliente").text(data.messageCliente);
        $("#exampleModalRecibos").modal("show");
    });
    ggg.fail(function () { });
    toastr.error(data.message);
})
//---------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------

$(".verPrestamo").click(function () {
    var Id = $(this).attr("data-id");

    var ggg = $.ajax({
        url: "/Usuario/Prestamos/ObtenerPrestamoxCliente",
        type: "POST",
        data: {
            "Id": Id
        }
    });

    ggg.done(function (data) {
        $(".valordescripcion").text(data.message);
        $(".valorMonto").text(data.messageMonto);
        $(".valorInteres").text(data.messageInteres);
        $("#exampleModal").modal("show");

    });
    ggg.fail(function () { });
    toastr.error(data.message);
})
//----------------------------------------------------------------------------------------

$(function () {
    $('#tblCliente,#tblPrestamo').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
        },
        "lengthMenu": [[5, -1], [5, "ALL"]]
    });
});