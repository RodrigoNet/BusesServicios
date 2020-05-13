$(document).ready(function(){

    document.getElementById("CrearUsuario").onclick = function () {
        
        var usuario = $("#Usuario").val();
        var email = $("#Email").val();
        var cliente = $("#Clientes").val();

        $.ajax({
            type: "POST",
            url: "AgregarUsuario",
            data: { _Usuario: usuario, _Email: email, _Cliente: cliente },
            async: true,
            success: function (data) {
                try {
                    if (data > 0) {
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
                        $("#cliente").val(value.IdEmpresa);
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
    var usuario = $("#modUsuario").val();
    var cliente = $("#modClientes").val();
    var email = $("#modEmail").val();
    console.log("modificausuario");
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


