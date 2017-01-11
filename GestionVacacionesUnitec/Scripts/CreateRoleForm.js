$(document).ready(function () {

    console.log("Create role form script");

    var $roleNameInput   =  $("#roleName");
    var $roleSubmit      =  $("#submitRole");

    console.log($roleNameInput);
    console.log($roleSubmit);

    //on submit form clicked
        $roleSubmit.click(function (e) {
        e.preventDefault();
        $("#submitRole").css('background-color', 'yellow');
        var roleName = $roleNameInput.val();

        console.log('$roleNameInput : ' + roleName );

        //posting Role Form
        var urlCreateForm = ' http://localhost:1755/Form/crearRol';
        var ajaxRequestDepartment = $.post(
        urlCreateForm,
        {
            ID: '1',
            descripcion: roleName,
            activo : '1'
        },
        function () {
            console.log("Role posted");
            $("#submitRole").css('background-color', 'green');
        });
    });
});


