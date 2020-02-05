$(document).ready(function () {
    $("#Login").click(function () {
        var nombre = $("#Nombre").val();
        var contresena = $("#Contrasena").val();
        var urlIndex = $("#urlIndex").val();
        var urlLogin = $("#urlLogin").val();

        $.ajax({
            type: "POST",
            url: urlLogin,
            data: {
                _nombre: nombre,
                _contrasena: contresena
            },
            async: true,
            success: function (data) {
                try {
                    if (data.Verificador !== undefined) {
                        if (!data.Verificador) {
                            $("#modalErrorLoginMensaje").html(data.Mensaje);
                            $("#aModalErrorLogin").click();
                            return;
                        }
                    }
                }
                catch (e) { }
                if (data == 1) {
                    window.location = urlParametros;
                }
                if (data == 2) {
                    window.location = urlIndex;
                }
            },
            error: function (a, b, c) {
                console.log(a, b, c);
            }
        });
    });
});