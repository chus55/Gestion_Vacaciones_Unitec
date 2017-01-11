$(document).ready(function () {
    console.log("DOM ready")
    $emailInput    = $("#USERNAME");
    $passwordInput = $("#PASSWORD");
    $loginSubmit   = $("#SUBMIT");

    $dashboardLink = $("#url");


    $dashboardLink.hover(function (e) {

        e.preventDefault();
        console.log("Dashboard link has been clicked");
    });
    
    
    $("#SUBMIT").on("click", function (e) {
        e.preventDefault();
        var email = $emailInput.val();
        var password = $passwordInput.val();
        console.log("Email : " + email);
        console.log("Password : " + password);
        console.log("TEST");


        var url = 'http://localhost:1755/TestForService/Login2'
        var ajaxRequest = $.post(url, { email: email, password: password }, function (response) {

            console.log("Response status: " + response.status);
            console.log("Next url : " + response.url);
            if (response.status == 1)
                window.location.href = response.url;
            else if (response.status == 0)
                $emailInput.css("color", "red");
            //window.location.href = 'www.google.com';
        });

        
        

    });




    

    /*$loginSubmit.click(function () {

        var email = $emailInput.val();
        var password = $passwordInput.val();
        console.log("Email : " + email);
        console.log("Password : " + password);
    });*/

});