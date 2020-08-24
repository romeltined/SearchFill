"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (sender, user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = sender + " : " + msg;
    var li = document.createElement("li");
    var x = document.getElementById("myAudio");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
    x.play();
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    connection.invoke('getConnectionId')
        .then(function (connectionId) {
            document.getElementById("connectionId").value = connectionId;
            // Send the connectionId to controller
        }).catch(err => console.error(err.toString()));;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var sender = document.getElementById("connectionId").value;
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", sender, user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});