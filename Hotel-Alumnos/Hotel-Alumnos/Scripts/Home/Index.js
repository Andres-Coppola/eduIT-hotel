

$(function () {

    $(".datepicker").datepicker({
        changeYear: true,
        dateFormat: "yy/mm/dd"
    });

    $("#Precio").prop("disabled", true);

    $("#NombreExcursion").change(function () {

        if ($("#NombreExcursion").val() == "1") {

            $("#Precio").val(5000);
            $("#Precio").text("5000");
        }

        if ($("#NombreExcursion").val() == "2") {

            $("#Precio").val(7000);
        }

        if ($("#NombreExcursion").val() == "3") {

            $("#Precio").val(9000);
        }
    });


    $("#btnGuardarExcursion").click(function () {

        $("#Precio").prop("disabled", false);
        var formData = $("#form-excursion").serialize();
        $("#Precio").prop("disabled", true);

        $.ajax({
            url: urlGuardarExcursion,
            data: formData,
            method: "POST",
            success: function (data) {

                swal("Genial!", data.msg, "success");

                $("#form-excursion")[0].reset();
                $("#excursionModal").modal("hide");
                
            },
            error: function (data) {
                                
                swal("Error", data.responseJSON.msg, "error");

            }
        })
    });

    $(".tipoHab").click(function (e) {

        //alert(e.target.parentElement.id); 

        var idTipoHabitacion = e.target.parentElement.id[e.target.parentElement.id.length - 1];

        $.ajax({
            url: urlGetTipoHabitacion,
            data: { idTipoHabitacion },
            method: "POST",
            success: function (data) {

                $("#tipoHabitacionModal").modal("show");
                $("#tipoHabitacionModalLabel").html("Habitación");
                $("#lblTdHabitacion").html(data.Nombre);
                $("#textDescripcion").html(data.Descripcion);

            },
            error: function (data) {

                swal("Error", "hubo un error", "error");

            }
        })



    });


});