var btn_Delete = $(".borrarCheckItem").hide();
var table = $("#table_categoria").DataTable({
    "sAjaxSource": "/BancoPreguntas/GetCategorias",
    "processing": true,
    selector: 'td:not(:first-child)',
        fnServerData: function (sSource, aoData, fnCallback) {
            $.ajax({
                type: "POSt",
                data: aoData,
                url: sSource,
                success: fnCallback
            })
    },
    aoColumns: [
        {
            "mData": "id", "render": function (data, type, full, meta) {
                return "<input name='checkList' value='" + data + "' class='checkItem check-input' type='checkbox'/>"
            }
        },
        { "mData": "id" },
            {
                "mData": "nombre", "render": function (nombre, type, full, meta) {
                    return nombre.substr(0, 30);
                }
            },
            {
                "mData": function (data, type, full, meta) {
                    return data.comentario.substr(0, 75) +"..."

                }
            },
            {
                "mData": function (data, type, full, meta) {
                    return "<Button data-titulo='Categoría' data-url='/BancoPreguntas/ModificarCategoria' data-comentario='" + data.comentario + "' data-nombre='" + data.nombre + "'  data-id=" + data.id + " onclick='createModal(this);'class='btn btn-success'><i class='fa fa-eye'></i></Button>"
                }
            },
            {
                "mData": function (data, type, full, meta) {
                    return "<Button  data-titulo='Categoría' data-url='/BancoPreguntas/EliminarCategoria' data-form='update'  data-comentario='" + data.comentario + "'  data-nombre='" + data.nombre + "' data-id=" + data.id + " onclick='AjaxResponse(this);'class='btn btn-danger'><i class='fa fa-trash-o'></i></Button>"
                }
            },

        ],
        language: {
            lengthMenu: "Visualizar _MENU_ registros por pagina",
            zeroRecords: "Nada encontrado - Discuple",
            info: "Visualisar _START_ a _END_ de _TOTAL_ entradas",
            infoEmpty: "Ningun registro disponible",
            infoFiltered: "(filtered from _MAX_ total records)",
            oPaginate: {
                sPrevious: "Anterior",
                sNext: "Siguiente"
            },
            processing: "DataTables esta actualmente ocupado"
        },
    });

  



var AjaxResponse = function (e) {
    data = $(e).data()
            var id = data.id
            var Url = data.url
            $.ajax({
                type: "post",
                data: { id: id },
                url: Url,
                success: function (data) {
                    table.ajax.reload(null, false);
                }
            })
}

var createModal = function (e) {
    var contenedor = $("#contenedor");
    $(contenedor).html("");
    $(contenedor).append('<div class="form text-right"><button type="submit" class="btn btn-primary">Editar</button></div>')
    var data = $(e).data()
    for (var i in data) {
        if (i != "url" && i!="titulo") {
            if (i == "id") {
                $(contenedor).append("<div class=form-group'><label> " + i.toUpperCase() + "</label> <input type='text' name=" + i + " readonly class='form-control'  value=" + data[i] + "></div >")
            } else {
                $(contenedor).append("<div class=form-group'><label> " + i.toUpperCase() + "</label> <textarea name=" + i + " class='form-control'>" + data[i] + "</textarea></div >")
            }
        }
    }
    $(contenedor).append('<button type="submit" class="btn btn-success">Modificar</button>')
    $(contenedor).attr("action", data.url)
    $(contenedor).attr("data-form", data.form)
    $("#title").html(data.titulo)
    $('#modalEdiciones').modal('show');
}



$("#check").change(function () {
    $(".checkItem").prop("checked", $(this).prop("checked"))
    btn_Delete.toggle()
})

$(".borrarCheckItem").click(function () {
    var id = $(".checkItem:checked").each(function () {
        return $(this).val()
    })
    var list = []
    for (var i = 0; i < id.length; i++) {
        list.push(id[i].attributes.value.nodeValue)
    }
    ajaxRecicler(list.toString())
})

var ajaxRecicler = function (id) {
        $.ajax({
            type: "post",
            url: "/BancoPreguntas/EliminarVariasCategorias",
            data: { id: id },
            cache: false,
            beforeSend: function () {
            },
            success: function (data) {
                respuesta.html(data);
                table.ajax.reload(null, false);
            },
            error: function () {
            }
        });
}

function alertaEliminar() {
    Swal.fire({
        title: "Eliminar",
        text: "sera eliminado ¿estas seguro?",
        type: "question",
        showCancelButton: true,
        confirmButtonText: "Accepter",
        cancelButtonText: "Annuler"
    }).then(function (result) {
        if (resul.value) {
            return true
        }
    })
}