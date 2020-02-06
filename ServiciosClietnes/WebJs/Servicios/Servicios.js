$(document).ready(function () {
    $("#crearTablaServicios").click(function () {
        var tablaServicios = $("#tablaServicios");
        var htmlDetalleTabla = "";
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
                    $("#tablaServicios").html("");
                    $.each(data.list, function (index, value) {
                        htmlDetalleTabla += "<tr>" +
                            "<td>" + value.Id + "</td>" +
                            "<td>" + value.Cliente + "</td>" +
                            "<td>" + value.Ruta + "</td>" +
                            "<td>" + value.Vehiculo + "</td>" +
                            "<td>" + value.fechaString + "</td></tr>"; 
                    });
                    tablaServicios.append(htmlDetalleTabla);
                }
            }
        });
    });
})

$(document).ready(function () {
    $('#tableServicios').DataTable({
        searching: false,
        lengthChange: false,
        sorting: false,
        paging: true
    });
});

