"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/newsHub").build();
var article = document.querySelector(".alert");
var titleTag = document.getElementById("title");
var textTag = document.getElementById("text");

connection.on("ReceiveMessage", function (title, text) {
   article.classList.remove("hidden");
   titleTag.innerHTML = title;
   textTag.innerHTML = text;
   $("#success-alert").fadeTo(5000, 500).slideUp(500, function () {
      $("#success-alert").slideUp(500);
   });
});

connection.start();
