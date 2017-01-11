$(document).ready(function () {

    console.log("Create department form script");

    var $departmentNameInput   = $("#departmentName");
    var $departmentSubmit      = $("#submitDepartment");

    console.log($departmentIdInput);
    console.log($departmentNameInput);
    console.log($departmentSubmit);

    //on submit form clicked
    $departmentSubmit.click(function (e) {
        e.preventDefault();
        $("#submitDepartment").css('background-color', 'yellow');
        var departmentName = $departmentNameInput.val();
        console.log('$departmentNameInput : ' + departmentName);

        //posting department Form
        var urlCreateForm = 'http://localhost:1755/Form/crearDepartamento';
        var ajaxRequestDepartment = $.post(
            urlCreateForm,
            {
                ID: '1',
                descripcion: departmentName,
                activo: '1'
            },
            function () {
                console.log("Department posted");
                $("#submitDepartment").css('background-color', 'green');
            });
    });
});