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
    $(document).ready(function () {
        //Llamar a datatable
        $('#tblPrestamos').DataTable({
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            }
        });
    });