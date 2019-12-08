$('.FormAjax').submit(function (e) {
    e.preventDefault();
    var form = $(this);
    var tipo = form.attr('data-form');
    var accion = form.attr('action');
    var metodo = form.attr('method');
    var boton = $(".boton")
    var texto = boton.text()
    var msjError = "<script>Swal.fire({'error','error','error'});</script>";
    var formdata = new FormData(this);

    var textoAlerta;
    if (tipo === "save") {
        textoAlerta = "¿Desea Añadir esta información?";
    } else if (tipo === "delete") {
        textoAlerta = "¿Desea Eliminar esta información?";
    } else if (tipo === "update") {
        textoAlerta = "¿Desea actualizar esta información?";
    } else {
        textoAlerta = "¿Desea realizar esta acción?";
    }
    Swal.fire({
        title: "Se realizaran cambio",
        text: textoAlerta,
        type: "question",
        showCancelButton: true,
        confirmButtonText: "Accepter",
        cancelButtonText: "Annuler"
    }).then(function (result) {
        if (result.value) {
            $.ajax({
                type: metodo,
                url: accion,
                data: formdata ? formdata : form.serialize(),
                cache: false,
                contentType: false,
                processData: false,
                beforeSend: function () {
                    if (tipo == "save") {
                        boton.attr("disabled", true);
                        boton.html('Espere por favor<i class="fa fa-spinner fa-spin fa-fw"></i>')
                    }
                },
                success: function (data) {
                    if (data.includes("añadido")) {
                        boton.html(texto)
                        boton.attr("disabled", false);
                    } else if (data.includes("actualizado")) {
                        $('#modalEdiciones').modal('hide');
                    }
                    else {
                        boton.html(texto)
                        boton.attr("disabled", false);
                    }

                    respuesta.html(data);
                },
                error: function () {
                    respuesta.html(msjError);
                    boton.attr("disabled", false);
                }
            });
        }
        return false;
    });
});
