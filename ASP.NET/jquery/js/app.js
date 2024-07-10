
// jQuery para ocultar los párrafos con clase de error al cargar la página
$(document).ready(function () {
    $('.error').hide(); // Oculta todos los párrafos con clase 'error'
    $('h3').text('TICH'); // Cambia el texto del encabezado h3


    // Mostrar div instrucciones al entrar
    $('#instrucciones').mouseenter(function () {
        $(this).show();
    });

    // Ocultar div instrucciones al salir
    $('#instrucciones').mouseleave(function () {
        $(this).hide();
    });
    // Evento change para el select con id "estado"
    $('#estado').change(function () {
        // Obtener el valor y texto del estado seleccionado
        var estadoSeleccionado = $('#estado option:selected');
        var numeroEstado = estadoSeleccionado.val();
        var nombreEstado = estadoSeleccionado.text();

        // Mostrar alert con el número y nombre del estado seleccionado
        alert('Estado seleccionado:\nNúmero: ' + numeroEstado + '\nNombre: ' + nombreEstado);
    });
    // Asignar función al evento clic del botón "aceptar"
    $('#aceptar').click(function () {
        // Obtener valores de los inputs
        var nombre = $('#nombre').val();
        var edad = $('#edad').val();
        var fechaNac = $('#fechaNac').val();
        var estado = $('#estado option:selected').text();

        // Mostrar los valores en el párrafo con id "generales"
        $('#generales').text('Nombre: ' + nombre + ', Edad: ' + edad + ', Fecha de Nacimiento: ' + fechaNac + ', Estado: ' + estado);

        var habilidades = [];
        $('#listaHabilidades li').each(function () {
            habilidades.push($(this).text());
        });

        // Mostrar las habilidades separadas por punto y coma en el párrafo con id "habilidades"
        $('#habilidades').text('Habilidades: ' + habilidades.join('; '));

        // Ocultar todos los párrafos con clase "error"
        $('.error').hide();
        // Cambiar la clase de todos los párrafos con clase "error"
        $('.error').removeClass('text-success').addClass('text-danger');
        // Asignar función al evento clic del botón "aceptar"
        $('#aceptar').click(function () {
            // Cambiar el color a azul de los spans dentro de párrafos
            $('p span').css('color', 'blue');
        });
        // Asignar evento clic a todos los párrafos con clase "error"
        $('.error').click(function () {
            $(this).hide(); // Ocultar el párrafo específico al hacer clic en él
        });

    });
});
