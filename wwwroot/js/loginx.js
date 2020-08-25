"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/loginxHub").build();

connection.on("ReceiveCredential", function (who) {
    //alert(who);
    var input = JSON.stringify(who);
    $.ajax({
        data: input,
        url: '/api/loginx',
        type: 'post',
        contentType: 'application/json',
        success: function () {
            try {
                //alert(data);
                window.location.href = "/Home";
            } catch (e) {
                alert("Output is not valid text: ");
            }
        }, error: function (request, error) {
            alert("AJAX Call Error: " + error);
        }
    });
});

//function authenticate(who) {

//}

connection.start().then(function () {
    connection.invoke('getConnectionId')
        .then(function (connectionId) {
            document.getElementById("connectionId").value = connectionId;
            // Send the connectionId to controller
        }).catch(err => console.error(err.toString()));;
}).catch(function (err) {
    return console.error(err.toString());
});

