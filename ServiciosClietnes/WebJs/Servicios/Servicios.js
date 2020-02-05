$(document).ready(function () {
    $("#GetServicios").click(function () {
        $("#Id").empty();

        $.ajax({
            type: "GET",
            url: "GetServicios",
            data: { _Cliente: Cliente, _FechaIni: FechaIni, _FechAFin: FechaFin },
            async: true,
            success: function (data) {
                if (data == 0) {
                    alert("Sin datos")
                } else {
                    $.each(data, function (index, value) {
                        $.each(this, function(name, value){
                            $("#Id").val=val.Id;
                        });
                    });
                }
            }
        });
    });
})