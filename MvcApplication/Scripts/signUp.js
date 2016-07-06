$(function () {

    $("form input").not("#cemail").blur(function () {
        // Remove style anyway because:
        // If valid - style is already on element
        // If not valid - style of invalidInput will be assigned in the next lines
        $(this).removeAttr('class');

        var isInputValid = $(this)[0].checkValidity();
        
        if (!isInputValid) {            
            $(this).addClass("invalidInput");
        }

    });

    $("#cemail").blur(function () {
        // Reset validation checks
        document.getElementById('cemail').setCustomValidity("");

        // Check HTML5 required validation
        var isInputValid = $(this)[0].checkValidity();

        // If email is invalid, we don't need to check if it exists in the db server
        if (!isInputValid) {
            $(this).removeAttr('class');
            $(this).addClass("invalidInput");

            return;
        }

        // If email is valid we need to check if it exists in the db server

        // Gets email string from input
        var strEmail = $('#cemail').val();
        // Set Json object to send to the server
        var objJson = { email : strEmail };

        $.ajax({
            type: "POST",
            url: "/Login/IsEmailExists", // Location of the service
            data: objJson, //Data sent to server
            datatype: "json", //Expected data format from server
            success: function (data) { //On Successfull service call
                var objResult = JSON.parse(data);

                if (objResult.found == "true") {
                    // Sets state of 'required' to 'invalid' and sets the message to "This email is already registered!" in submit
                    document.getElementById('cemail').setCustomValidity("This email is already registered!");
                    // Removes any previous style
                    $('#cemail').removeAttr('class');
                    // Adds invalid style
                    $('#cemail').addClass("invalidInput");
                }                
                    
            }

        });
    });

});