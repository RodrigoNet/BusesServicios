$(document).ready(function () {

    $("#crearTablaServicios").click(function () {
        var tablaServicios = $("#tabla");
        var htmlDetalleTabla = "<table id='tableServicios' class='table table - striped' style='background - color: white' width:'95 %'>" +
            "<tr>" +
            "<th>#</th>" +
            "<th>Vehiculo</th>" +
            "<th>Hora</th>" +
            "<th>Conductor</th>" +
            "<th>Ruta</th></tr>";
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
                            "<td>" + value.Cliente + "</td>" +
                            "<td>" + value.Ruta + "</td>" +
                            "<td>" + value.Vehiculo + "</td>" +
                            "<td>" + value.fechaString + "</td></tr>"; 
                    });
                    htmlDetalleTabla += "</table>";
                    tablaServicios.append(htmlDetalleTabla);
                }
            }
        });
    });
})

