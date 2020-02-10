$(document).ready(function () {

    $("#crearTablaServicios").click(function () {
        var tablaServicios = $("#tabla");
        var htmlDetalleTabla = "<table id='tableServicios' class='table table - striped' style='background - color: white' width:'95 %'>" +
            "<tr>" +
            "<th>#</th>" +
            "<th>Fecha</th>" +
            "<th>Hora</th>" +
            "<th>Cliente</th>" +
            "<th>Conductor</th>" +
            "<th>Ruta</th>" +
            "<th>Vehiculo</th></tr>";
        var fechaIni = $("#fechaIni").val();
        var fechaFin = $("#fechaFin").val();
        $.ajax({
            type: "GET",
            url: "GetServicios",
            data: { _fechaIni: fechaIni, _fechaFin: fechaFin },
            async: true,
            success: function (data) {
                if (data == 0) {
                    alert("Error - Sin Datos")
                } else {
                    $.each(data.list, function (index, value) {
                        htmlDetalleTabla += "<tr>" +
                            "<td>" + value.Id + "</td>" +
                            "<td>" + value.fechaString + "</td>" +
                            "<td>" + value.Hora + "</td>" +
                            "<td>" + value.Cliente + "</td>" +
                            "<td>" + value.Conductor + "</td>" +
                            "<td>" + value.Ruta + "</td>" +
                            "<td>" + value.Vehiculo + "</td>"; 
                    });
                    htmlDetalleTabla += "</table>";
                    tablaServicios.append(htmlDetalleTabla);
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

