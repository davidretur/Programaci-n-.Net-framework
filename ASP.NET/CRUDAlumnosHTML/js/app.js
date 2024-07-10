var consultar = document.getElementById('consultar');
var guardar = document.getElementById('guardar');
document.getElementById('consultar').addEventListener('click', function() {
    var id = document.getElementById('id').value.trim();
    if (id === '') {
        alert('Por favor, ingresa un valor en el input Id.');
        return;
    }else if(id!=""){
        var datosFijos = {
            nombre: 'David Duarte',
            edad: '27',
            estadoOrigen: 'Michoacan',
            estatus: true
        };
        document.getElementById('nombre').value = datosFijos.nombre;
        document.getElementById('edad').value = datosFijos.edad;
        document.getElementById('estadoOrigen').value = datosFijos.estadoOrigen;
        document.getElementById('estatus').checked = datosFijos.estatus;
        
        document.getElementById('nombre').disabled = false;
        document.getElementById('edad').disabled = false;
        document.getElementById('estadoOrigen').disabled = false;
        document.getElementById('estatus').disabled = false;
        consultar.style.display = 'none';
        guardar.style.display = 'block'; 
    }
      
});

document.getElementById('guardar').addEventListener('click', function() {
    var nombre = document.getElementById('nombre').value.trim();
    var edad = document.getElementById('edad').value.trim();
    var estadoOrigen = document.getElementById('estadoOrigen').value.trim();
    var estatus = document.getElementById('edad');
    if( nombre != "" && edad != "" && estadoOrigen != ""){
        alert('Actualización exitosa');
        LimpiarCampos();
        Desabilitar()
    }
});

function Desabilitar() {
    document.getElementById('nombre').disabled = true;
    document.getElementById('edad').disabled = true;
    document.getElementById('estadoOrigen').disabled = true;
    document.getElementById('estatus').disabled = true;   
    guardar.style.display = 'none';
}

function LimpiarCampos() {
    document.getElementById('id').value = ' ';
    document.getElementById('nombre').value = ' ';
    document.getElementById('edad').value = ' ';
    document.getElementById('estadoOrigen').value = ' ';
    document.getElementById('estatus').checked = false;
    consultar.style.display = 'block';
}

Desabilitar();