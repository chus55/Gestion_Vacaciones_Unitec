$(document).ready(function () {

    var $talentoHumanoInput      = $("#talentoHumano");
    var $emailInput              = $("#email");
    var $passwordInput           = $("#password");
    var $firstNameInput          = $("#firstName");
    var $middleNameInput         = $("#middleName");
    var $lasNameInput            = $("#lastName");
    var $secondLastNameInput     = $("#secondLastName");
    var $employmentDateInput     = $("#employmentDate");
    var $submitUserButton        = $("#submitUser");
    var $roleCheckBoxes          = $(".role");
    var $departmentCheckBoxes    = $(".department");
    var $departmentList          = $("#departmentList");
    var $roleList                = $("#roleList");
    var $bossList                = $("#bossList");
    var $lists;
    var roleArray                = [];
    var departmentAray = [];
    
    var userPosted                   = false;
    var roleRelationshipPosted       = false;
    var departmentRelationshipPosted = false;
    var fetching                     = false;

    var serializedDepartmentList = "";
    var serializedRoleList       = "";
    var currentSessionId;
    //interval

    var today = new Date();
    var month = today.getUTCMonth() + 1; //months from 1-12
    var day = today.getUTCDate();
    var year = today.getUTCFullYear();
    var signUpDate = month + '/' + day + '/' + year;
    
    console.log($departmentList.html());

  /*  $signUpDateInput.datepicker();

    $employmentDateInput.datepicker({
        format: 'dd/mm/yyyy',
    }).on('changeDate', function (e) {
        $(this).datepicker('hide');
    });*/

    //Retrieve session
    /*var url = 'http://localhost:1755/Form/getSession';
    var ajaxRequestForSession = $.post(url, function (session) {

        console.log("Session name : " + session.name);
        console.log("Session ID : " + session.talentoHumano);
        currentSessionId = session.talentoHumano;

    });*/

  /*  console.log('Testing lists');
    setInterval(function () {
        console.log('Lists : ' + $lists.length);
    }, 1000);
    */

    //Fetch active departments
    var url = 'http://localhost:1755/Form/getDepartamentos';
    var ajaxRequestForDepartments = $.post(url, function (data) {
        serializedDepartmentList = data.serializedData;
        departmentAray = serializedDepartmentList.split('~');
        console.log("departments array : " + departmentAray);

        for (var c = 0; c < departmentAray.length; c++)
        {   
            $listItem = $('<li>');
            $label = $('<label>',   {
                for: departmentAray[c],
                html: departmentAray[c]
            });

            $checkbox = $('<input>', {
                class : 'department',
                type  : 'checkbox',
                name: departmentAray[c],
                value: departmentAray[c]
            });

            $listItem.append($label);
            $listItem.append($checkbox);
            $departmentList.append($listItem);
        }

        $departmentCheckBoxes = $(".department");
        setChangeListener($departmentCheckBoxes);
        $lists = $('.department');
    });


        //Fetch active departments
    var url = 'http://localhost:1755/Form/getRoles';
    var ajaxRequestForRoles = $.post(url, function (data) {
        console.log('Serialized data :  ' + data);
        serializedRoleList = data.serializedData;
        roleArray = serializedRoleList.split('~');
        console.log("Roles array : " + roleArray);

        for (var c = 0; c < roleArray.length; c++)
        {   
            $listItem = $('<li>');
            $label = $('<label>',   {
                for: roleArray[c],
                html: roleArray[c]
            });

            $checkbox = $('<input>', {
                class : 'role',
                type  : 'checkbox',
                name: roleArray[c],
                value: roleArray[c]
            });

            $listItem.append($label);
            $listItem.append($checkbox);
            $roleList.append($listItem);
        }
        $roleCheckBoxes = $(".role");
       // setChangeListener($roleCheckBoxes);
  
    });

    

    //on submit form clicked
    $submitUserButton.click( function (e) {
        e.preventDefault();

        // Get values from first form
        var talentoHumano  = $talentoHumanoInput.val();
        var email          = $emailInput.val();
        var password       = $passwordInput.val();
        var firstName      = $firstNameInput.val();
        var middleName     = $middleNameInput.val();
        var lastname       = $lasNameInput.val();
        var secondLastName = $secondLastNameInput.val();
        // Sign up date 

        //Employment Date
        var employmentDate = $employmentDateInput.val();
        console.log('Testing employment date : ' + employmentDate);

        // Get values from second form
        var roles       = "";
        var departments = "";

        var numberOfRoles = 0;
        var numberOfDepartments = 0;

        $roleCheckBoxes.each(function (index) {
            $thisCheckBox = $(this);
            if ($thisCheckBox.is(':checked'))
            {
                if (numberOfRoles != 0)
                    roles += "~";
                roles += $thisCheckBox.attr("name");
                numberOfRoles++;
            }
        });

        // Get values from third form
        $departmentCheckBoxes.each(function (index) {
            $thisCheckBox = $(this);
            if ($thisCheckBox.is(':checked')) {
                if (numberOfDepartments != 0)
                    departments += "~";
                departments += $thisCheckBox.attr("name");
                numberOfDepartments++;
            }
        });

        $('#submitUser').css('background-color', 'yellow');
           //posting User Creation Form
           var urlCreateUser = ' http://localhost:1755/Form/crearUser';
           var ajaxRequest = $.post(
               urlCreateUser,
               {
                   talentoH: talentoHumano,
                   correo: email,
                   password: password,
                   nombre1: firstName,
                   nombre2: middleName,
                   apellido1: lastname,
                   apellido2: secondLastName,
                   fechaIngreso: employmentDate,
                   fechaCreacion: signUpDate
               },
              function (data) {
                  $('#submitUser').css('background-color', 'green');
                  console.log('--------------------------');
                  console.log("Talento Humano : " + talentoHumano);
                  console.log("Email : " + email);
                  console.log("Password : " + password);
                  console.log("First Name : " + firstName);
                  console.log("Middle Name : " + middleName);
                  console.log("Last Name : " + lastname);
                  console.log("Second Last Name : " + secondLastName);
                  console.log("Creation Date : " + employmentDate);
                  console.log("Sign Up Date : " + signUpDate);
                  console.log(data);
       });
        
        
        //posting Roles Form
           var urlCreateUserRole = ' http://localhost:1755/Form/Usuario_Rol';
           var ajaxRequestRoles = $.post(
           urlCreateUserRole,
           {
               Talento_Humano: talentoHumano,
               descripcion_rol: roles
           },
           function () {
               console.log("Talento Humano Roles : " + talentoHumano);
               console.log("Roles : " + roles);
        });

        //posting Departments Form
           var urlCreateUserDepartment = ' http://localhost:1755/Form/Usuario_Departamento';
           var ajaxRequestDepartment = $.post(
           urlCreateUserDepartment,
           {
               Talento_Humano: talentoHumano,
               descripcion_departamento: departments
           },
           function () {
               console.log("Talento Humano Department : " + talentoHumano);
               console.log("Departments : " + departments);
        });
    });
});


var setChangeListener = function (checkboxes) {

    checkboxes.each(function (index) {
        $thisCheckBox = $(this);
        console.log('val : ' + $thisCheckBox.val());
        $thisCheckBox.change(function () {
            fetching = true;
            $('#submitUser').css('visibility', 'hidden');
            var value = $(this).val();
            if ($(this).is(':checked')) {
                console.log('click event');
                //fetching possible bosses
                var urlgetJefesPosibles = 'http://localhost:1755/Form/getJefesPosibles';
                var ajaxRequestBosses = $.post(
                urlgetJefesPosibles,
                {
                    departamento_descripcion: value
                },
                function (data) {
                    console.log('data requested : ' + data.serializedData);
                    fetching = false;
                    $('#submitUser').css('visibility', 'visible');

                    /////////////////////////////////////////////// requesting bosses
                    console.log('Serialized data :  ' + data);
                    serializedRoleList = data.serializedData;
                    bossArray = serializedRoleList.split('~');
                    console.log("Boss array : " + bossArray);

                    for (var c = 0; c < bossArray.length; c++) {
                        var $listItem = $('<li>');
                        var $label = $('<label>', {
                            for: bossArray[c],
                            html: bossArray[c]
                        });

                        $checkbox = $('<input>', {
                            class: 'boss',
                            type: 'checkbox',
                            name: bossArray[c],
                            value: bossArray[c]
                        });

                        $listItem.append($label);
                        $listItem.append($checkbox);
                        $('#bossList').append($listItem);
                    }
                    /////////////////////////////////////////////// done requesting bosses
                });
            }

        });
    });
}

