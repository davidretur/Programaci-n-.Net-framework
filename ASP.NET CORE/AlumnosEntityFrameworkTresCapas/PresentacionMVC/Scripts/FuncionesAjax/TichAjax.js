function llamadoAjaxGEThtml(urlAction, funcExito) {
    $.ajax({
        type: 'GET',
        url: urlAction,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: funcExito,
        error: errorGenerico
    });
}
function llamadoAjaxEliminacion(urlAction, funcExito) {
    $.ajax({
        type: 'DELETE',
        url: urlAction,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: funcExito,
        error: errorGenerico
    });
}


function obtenerUsuarioPorId(id) {
    var url = 'http://localhost:5041/api/EstatusAlumnos/' + id;
    $.ajax({
        type: 'GET',
        url: url,
        content: "application/json; charset=utf-8",
        async: true,
        dataType: "json",
        success: function (data) {
            mostrarUsuarioEnModal(data);
        },
        error: errorGenerico
    });
}

// Función de éxito para mostrar los datos del usuario en el modal
function mostrarUsuarioEnModal(data) {
    // Actualiza el contenido del modal con los datos del usuario
    $('#detalleUsuario').html(`
            <p><strong>Id:</strong> ${data.id}</p>
            <p><strong>Clave:</strong> ${data.clave}</p>
            <p><strong>Nombre:</strong> ${data.nombre}</p>
                </div>

               
                <div class="modal-footer">
            <button type="button" class="btn btn-danger" onclick="btnEliminar(${data.id})">Eliminar Permanentemente</button>
        `);

    // Abre el modal
    $('#modalUsuario').modal('show');
}

function btnEliminar(id) {
    var url = 'http://localhost:5041/api/EstatusAlumnos/' + id;
    $.ajax({
        type: 'DELETE',
        url: url,
        content: "application/json; charset=utf-8",
        async: true,
        dataType: "json",
        success: function (data) {
            console.log("Fue eliminado");
            $('#modalUsuario').modal("hide");
            window.location.replace("http://localhost:60165/EstatusAlumnos");
        },
        error: errorGenerico
    });
}

function errorGenerico(jqXHR, exception) {
    var msg = '';
    if (jqXHR.status === 0) {
        msg = 'No está conectado, favor de verificar su conexión.';
    }
    else if (jqXHR.status === 404) {
        msg = 'Página no encontrada [404]';
    }
    else if (jqXHR.status === 500) {
        msg = 'Error en el servidor [500]';
    }
    else if (jqXHR.status === 'parseerror') {
        msg = 'El parseo del JSON es erróneo.';
    }
    else if (jqXHR.status === 'timeout') {
        msg = 'Error por tiempo de espera.';
    }
    else if (jqXHR.status === 'abort') {
        msg = 'La petición Ajax fue abortada.';
    }
    else {
        msg = 'Error no conocido. ' + jqXHR.responseText;
    }
    alert("Ajax error: " + msg);
}
