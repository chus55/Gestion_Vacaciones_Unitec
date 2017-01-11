$(document).ready(function () {

    console.log("Crear Solicitud Document Ready");
    //posting Role Form
    var urlCreateForm = ' http://localhost:1755/Solicitudes/crearVacacionSolicitud';
    var ajaxRequestDepartment = $.post(
    urlCreateForm,
    function () {
        console.log("Role posted");
    });
});


