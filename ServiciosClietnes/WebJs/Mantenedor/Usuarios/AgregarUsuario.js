$(document).ready(function(){
    //$('.combobox').combobox();

    document.getElementById("CrearUsuario").onclick = function () {
        
        var usuario = $("#Usuario").val();
        var email = $("#Email").val();
        var cliente = $("#modClientes").val();

        $.ajax({
            type: "POST",
            url: "AgregarUsuario",
            data: { _Usuario: usuario, _Email: email, _Cliente: cliente },
            async: true,
            success: function (data) {
                try {
                    if (data > 0) {
                        //if (!data.Verificador) {
                        //    $("#modalErrorLoginMensaje").html(data.Mensaje);
                        //    $("#aModalErrorLogin").click();
                        //    return;
                        //}
                        //else {
                        //    $("#modalErrorLoginMensaje").html(data.Mensaje);
                        //    $("#aModalErrorLogin").click();
                        //}
                        alert("usuario creado");
                        location.reload();
                    }
                }
                catch (e) { }
            },
            error: function (a, b, c) {
                console.log(a, b, c);
            }
        });
    };
      
});

function GetUsuario(IdUsuario) {
    $("#modClienteundefined").empty();

    $.ajax({
        type: "GET",
        url: "GetUsuario",
        data: { _IdUsuario: IdUsuario },
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("Debe ingresar campos obligatorios");
            } else {
                $.each(data, function (index, value) {
                    $.each(this, function (name, value) {
                        $("#modIdUsuario").val(value.IdUsuario);
                        $("#modUsuario").val(value.Usuario);
                        $("#modEmail").val(value.Email);
                        $("#modClientes").val(value.IdEmpresa);
                        document.getElementById("modUsuario").value=value.Usuario;
                        document.getElementById("IdUsuario").value=value.IdUsuario;
                        document.getElementById("modClientes").value = value.IdEmpresa;
                        document.getElementById("modEmail").Value = value.Email;
                    });
                });
            }
         }
    });
}

function EliminarUsuario(IdUsuario) {
    abrirConfirmacion('Eliminar', 'Desea eliminar Usuario?', function (){
        $.ajax({
            type: "POST",
            url: 'EliminarUsuario',
            data: {
            _IdUsuario: IdUsuario,
            },
            success: function(data){
                if (data.Verificador)  {
                    location.reload();
                }
            }
        });
    }, true);
};

function ModificaUsuario() {
    var Id = $("#modIdUsuario").val();
    var usuario = $("modUsuario").val();
    var cliente = $("modClientes").val();
    var email = $("modEmail").val();
    $.ajax({
        type: "POST",
        url: "ModificarUsuario",
        data: { _IdUsuario: Id, _Usuario: usuario, _Cliente: cliente, _Email:email},
        async: true,
        success: function (data) {
            if (date == 1) {
                alert("Usuario modificado correctamente");
                location.reload();
            }
            if (data = 2) {
                alert("Error");
            }
            if (data = 3) {
                alert("Debe Completar datos");
            }
        }
    });
}

