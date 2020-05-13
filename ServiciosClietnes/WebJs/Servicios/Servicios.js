$(document).ready(function () {
    $("#dataTable").dataTable().fnDestroy();
    
    $("#crearTablaServicios").click(function () {
        var tablaServicios = null;
        tablaServicios = $("#dataTable tbody");
        var htmlDetalleTabla = "";
        var fechaIni = $("#fechaIni").val();
        var fechaFin = $("#fechaFin").val();
        $.ajax({
            type: "GET",
            url: "GetServicios",
            data: { _fechaIni: fechaIni, _fechaFin: fechaFin },
            async: true,
            success: function (data) {
                if (data.list == 0) {
                    $("#dataTable").dataTable().fnDestroy();
                    tablaServicios = $("#dataTable tbody");
                    tablaServicios.html("");
                } else {
                    $("#dataTable").dataTable().fnClearTable();
                    $("#dataTable").dataTable().fnDraw();
                    $("#dataTable").dataTable().fnDestroy();
                    $.each(data.list, function (index, value) {
                        htmlDetalleTabla += "<tr>" +
                            "<td width="+ "20 %"+">" + value.Id + "</td>" +
                            "<td>" + value.fechaString + "</td>" +
                            "<td>" + value.Hora + "</td>" +
                            "<td>" + value.Cliente + "</td>" +
                            "<td>" + value.Conductor + "</td>" +
                            "<td>" + value.Ruta + "</td>" +
                            "<td>" + value.Vehiculo + "</td>";
                        htmlDetalleTabla += "</tr>";
                    });
                    tablaServicios.append(htmlDetalleTabla);

                    try {
                        $("#dataTable").dataTable().fnDestroy();
                        $('#dataTable').dataTable({
                            dom: 'Bfrtip',
                            buttons: [
                                'copy', 'csv', 'excel', 'pdf', 'print'
                            ],
                            ordering: false,
                            language: {
                                "sProcessing": "Procesando...",
                                "sLengthMenu": "Mostrar _MENU_ Registros",
                                "sZeroRecords": "&nbsp;",
                                "sEmptyTable": "&nbsp;",
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
                            aoColumnDefs: [{ 'bSortable': true, 'aTargets': ['no-sortable'] }]
                        });
                    }
                    catch (e) { console.log(e);}
                }
            }
        });
    });
})

function descargaExcel() {
    
    var fechaIni = $("#fechaIni").val();
    var fechaFin= $("#fechaFin").val();
    if (fechaIni != '') {
        window.location = 'descargaExcel?fechaini=' + fechaIni + '&fechafin=' + fechaFin;
    } else {
        alert(data.mensajeError);
        return false;
    }
}

