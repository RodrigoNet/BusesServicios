$(document).ready(function () {
    $("#dataTableDoc").dataTable().fnDestroy();

    $("#crearTablaFacturas").click(function () {
        var tablaServicios = $("#dataTableDoc tbody");
        var htmlDetalleTabla = "";
        var cliente = $("#Cliente").val();
        var fechaIni = $("#fechaIni").val();
        var fechaFin = $("#fechaFin").val();
        $.ajax({
            type: "GET",
            url: "GetFacturas",
            data: { _cliente: cliente ,_fechaIni: fechaIni, _fechaFin: fechaFin },
            async: true,
            success: function (data) {
                if (data.list == 0) {
                    $("#dataTableDoc").dataTable().fnDestroy();
                    tablaServicios = $("#dataTableDoc tbody");
                    tablaServicios.html("");
                } else {
                    $("#dataTableDoc").dataTable().fnClearTable();
                    $("#dataTableDoc").dataTable().fnDraw();
                    $("#dataTableDoc").dataTable().fnDestroy();
                    $.each(data.list, function (index, value) {
                        htmlDetalleTabla += "<tr>" +
                            "<td>" + value.Id + "</td>" +
                            "<td>" + value.NroFactura + "</td>" +
                            "<td>" + value.fechaString + "</td>" +
                            "<td align=" + "right" + ">" + value.Total.toLocaleString("es-CL") + "</td>" + //formato chileno
                            "<td>" + value.Estado + "</td>" +
                            "<td><button class='btn btn-danger' onclick ='EliminarUsuario("+value.Id+")'>Eliminar<span class='fa fa-trash'></span></button ></td>";
                        htmlDetalleTabla += "</tr>";
                    });
                    tablaServicios.append(htmlDetalleTabla);

                    try {
                        $("#dataTableDoc").dataTable().fnDestroy();
                        $("#dataTableDoc").dataTable({
                            ordering: false,
                            buttons: [
                                'pdf'
                            ],
                            language: {
                                "sProcessing": "Procesando...",
                                "sLengthMenu": "Mostrar _MENU_ Registros",
                                "sZeroRecords": "&ndsp;",
                                "sEmptyTable": "&ndsp;",
                                "sInfo": "Encontrados: _TOTAL_ Registros (Mostrando del _START_ al _END_)",
                                "sInfoEmpty": "* No se han encontrado resultados en la búsqueda",
                                "sInfoFiltered": "",
                                "sInfoPostFix": "",
                                "sSearch": "Buscar:",
                                "sUrl": "",
                                "sInfoThousands": ",",
                                "sLoadingRecords": "Cargando...",
                                "oPaginate": {
                                    "sFirst": "Primero",
                                    "sLast": "Último",
                                    "sNext": "Siguiente",
                                    "sPrevious": "Anterior"
                                },
                                "oAria": {
                                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                                }
                            },
                            aoColumnDefs: [{ 'bSortable': false, 'aTargets': ['no-sortable'] }]
                        });
                    }
                    catch (e) { console.log(e); }
                }
            }
        });
    });

    
})