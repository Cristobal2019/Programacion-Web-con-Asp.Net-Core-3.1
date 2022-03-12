
//definir el evento click para el boton guardar

$("#btnGuardarNuevoPrestamo").click(function () {

    //obtener los valores de los imput del formulario

    var Descripcion = $(".descripcionPrestamo").val();
    var Monto = $(".montoPrestamo").val();
    var Interes = $(".interesPrestamo").val();
    var Cuota = $(".cuotaPrestamo").val();
    var ClienteId = 2;

    //valida que los campos sean requerido
    if (Descripcion == "" || Monto == "" || Interes == "" || Cuota == "") {
        Swal.fire({
            icon: 'error',
            text: 'Por favor, Llenar todos los campos',
            background: 'white',
            timer: 15000
        });
    }
    else {
        //ENVIAMOS los datos al servidor

        var xhr = $.ajax({
            url: "PrestamoNuevoGuardar",
            type: "POST",
            //agregar parametros de la peticion, lo que esta entre comilla es igual al campo de modelo
            data: {
                "Descripcion": Descripcion,
                "Monto": Monto,
                "Interes": Interes,
                "Cuota": Cuota,
                "ClienteId": ClienteId
            }
        });
        xhr.done(function (data) {
            Swal.fire({
                icon: 'success',
                title: data.message,
                showConfirmButton: false,
                timer: 15000
            });
        });
        xhr.fail(function () {

        });

    }
});

