$(document).ready(function () {

    $("#ModificarClave").click(function () {
        var Id = $("#Id").val();
        var clave = $("#NewContrasena").val();
        console.log("paso1");
        $.ajax({
            type: "POST",
            url: "ModificarClave",
            data: { _Id: Id, newclave: clave },
            async: true,
            success: function (data) {
                if (data == 1) {
                    alert("");
                }
                if (data == 2) {
                    alert("Error");
                }
            }
        });
        console.log("paso2");
    });

});
