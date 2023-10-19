$(function () {

    $(".datepicker").datepicker({
        changeYear: true,
        dateFormat: "yy/mm/dd",
        minDate: 0,
    });

    $("#ddlTipoHab").change(function () {

        var tipoHab = parseInt($("#ddlTipoHab").val());
        $('#Habitacion_Id').empty();
        $('#Habitacion_Id').append('<option value="0"> Seleccione una Habitacion </option>');
        $('#cuadroHab').prop('hidden', false);
        var fechaIngreso = $("#FechaIngreso").val();
        var fechaEgreso = $("#FechaEgreso").val()


        $.ajax({
            url: urlConsultarHabitacionesPorTipo,
            data: {
                tipoHab,
                fechaIngreso,
                fechaEgreso
            },
            method: "POST",
            success: function (datos) {

                $(datos.Habitaciones).each(function (index,elem) {

                    $('#Habitacion_Id').append(`<option value="${elem.Id}"> ${elem.Numero} </option>`);
                });

                $("#textoDescripcion").html(datos.TipoHabitacion.Descripcion);

                var sourceImg = $("#imgHabitacion").prop("src").split("/");
                sourceImg[5] = datos.TipoHabitacion.ImagenNombre;
                var srcFinal = sourceImg.join("/");

                $("#imgHabitacion").prop("src", srcFinal);
            },
            error: function (data) {

                swal("Error", "hubo un error", "error");

            }
        })

    });

    $("#Habitacion_Id").change(function () {

        $("#seccion-huesped").prop("hidden", false);
    })


    $("#guardarReserva").click(function () {

        var formData = $("#form-reserva").serialize();

        $.ajax({
            url: urlGuardarReserva,
            data: formData,
            method: "POST",
            success: function () {

                swal("Genial", "Su Reserva ha sido guardada correctamente", "success");

                setTimeout(() => {
                    location.reload();
                }, "3000");
                
            },
            error: function (data) {

                swal("Error", data.responseJSON.msg, "error");

            }
        })

    });


});