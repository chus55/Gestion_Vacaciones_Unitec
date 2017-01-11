$(document).ready(function () {
    console.log("Dash board loaded");

    var $navList           = $('#navlist');
    var $WelcomeParagraph  = $("#welcome");
    var roles              = [];
    var permisos           = [];
    var currentSession;


    $anchorCreateUser = $('<a/>', {
        href:'http://localhost:1755/Form/ViewCrearUsuario',
        html: '<span>Crear Usuario</span>'
    });


    var url = 'http://localhost:1755/Home/getSession';
    var ajaxRequestForSession = $.post(url , function (session) {

        console.log("Session name : " + session.name);
        console.log("Session ID : " + session.talentoHumano);
        console.log("Roles ID  : " + session.roles);
        console.log("Permisos ID  : " + session.permisos);
        console.log("-------------------------------------");
        roles = session.roles.split('~');
        permisos = session.permisos.split('~');
        console.log("Roles ID array  : " + roles);
        console.log("Permisos ID array  : " + permisos);
        currentSession = session;
        console.log($navList);
        $WelcomeParagraph.append(session.name + " " + session.lastName);

        //apppendar elementos de permisos a la barra de navegacion
        for (var j = 0; j < permisos.length; j++)
        {
  
            var appendCheck = false;
            var id          = permisos[j];
            var _href       = "";
            var _html       = "";


            switch (id) {
                case '1':

                    appendCheck = true;
                    _href = 'http://localhost:1755/Form/ViewCrearRol';
                    _html = '<span>Crear Rol</span>';
                    break;
                case '2':

                    appendCheck = true;
                    _href = 'http://localhost:1755/Form/ViewCrearUsuario';
                    _html =  '<span>Crear Usuario</span>';
                    break;
                case '3':

                    appendCheck = true;
                    _href = 'http://localhost:1755/Form/ViewCrearDepartamento';
                    _html = '<span>Crear Departamento</span>';
                    break;
                default:

                    break;
            }
            if (appendCheck) {
                $listItem = $('<li>');
                $anchorListItem = $('<a/>', {
                    href: _href,
                    html: _html
                });
                console.log($listItem);
                $listItem.append($anchorListItem);
                $navList.append($listItem);
            }
        }

    });
   
});
