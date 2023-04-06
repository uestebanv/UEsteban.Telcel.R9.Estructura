
$(document).ready(function () { // Esta parte del código se ejecutará automáticamente cuando la página esté lista.
    $("#botonenviar").click(function () { // Con esto establecemos la acción por defecto de nuestro botón de enviar.
        if (validaForm()) { // Primero validará el formulario.
            $.post("enviar.php", $("#formdata").serialize(), function (res) {

                function validaForm() {
                    // Campos de texto
                    if ($("#nombre").val() == "") {
                        alert("El campo Nombre no puede estar vacío.");
                        $("#nombre").focus();       // Esta función coloca el foco de escritura del usuario en el campo Nombre directamente.
                        return false;
                    }
                    if ($("#apellidos").val() == "") {
                        alert("El campo Apellidos no puede estar vacío.");
                        $("#apellidos").focus();
                        return false;
                    }
                    if ($("#direccion").val() == "") {
                        alert("El campo Dirección no puede estar vacío.");
                        $("#direccion").focus();
                        return false;
                    }

                    // Checkbox
                    if (!$("#mayor").is(":checked")) {
                        alert("Debe confirmar que es mayor de 18 años.");
                        return false;
                    }

                    return true; // Si todo está correcto
                }