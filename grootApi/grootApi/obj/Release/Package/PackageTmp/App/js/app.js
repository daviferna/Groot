var app = angular.module("grootApp", ["ngRoute"]);

app.config(function ($routeProvider) {

    $routeProvider
        .when("/", {
            templateUrl: "App/views/home.html",
            controller: "homeController"
        })
        .when("/login", {
            templateUrl: "App/views/login.html",
            controller: "loginController"
        })
        .when("/panel", {
            templateUrl: "App/views/panel.html",
            controller: "panelController"
        })

});

app.controller("rootController", function ($scope) {
    $scope.hola = "sad";
});

app.controller("homeController", function ($scope) {
    $scope.hey = "hey";
});

app.controller("panelController", function ($scope) {


    $scope.init = function() {
        drawTempHUmidity();
    }

    
});

app.controller("loginController", function ($scope) {
});

function getMaxOfArray(numArray) {
    return Math.max.apply(null, numArray);
}

function drawTempHUmidity(){
    /*temperature and humidity*/
    var fakeData = [24, 25, 26, 28, 29, 34, 25, 19, 14, 26, 20, 19, 16, 24, 23, 20, 17, 24, 19, 47, 48, 25];
    var fakeTemp = [24, 25, 26, 28, 20, 34, 30, 10, 12, 26, 20, 17, 16, 20, 23, 19, 17, 24, 19, 47, 48, 25];

    var temHumGraphic = document.getElementById("tempAndHum");
    var context = temHumGraphic.getContext("2d");
    var graphicHeight = temHumGraphic.height;
    var graphicWidth = temHumGraphic.width;
    var portionWidth = temHumGraphic.width / fakeData.length;
    var portionHeight = graphicHeight / getMaxOfArray(fakeData);


    context.beginPath();
    context.strokeStyle = "#AAA";
    context.lineWidth = 0.5;

    //Dividir en 10 partes
    var division = graphicHeight / 10;

    for (var x = 0; x < 10; x++) {
        context.moveTo(0, x * division);
        context.lineTo(graphicWidth, x*division);
    }
    context.stroke();

    
    context.beginPath();
    context.strokeStyle = "#5cadd4";
    context.lineWidth = 10;
    for (var x = 0; x < fakeData.length; x++) {
        context.moveTo(x * portionWidth + 10, graphicHeight);
        context.lineTo(x * portionWidth + 10, graphicHeight - portionHeight * fakeData[x]);
        
    }
    context.stroke();

    context.beginPath();
    context.strokeStyle = "#e33131";
    context.lineWidth = 3;

    for (var x = 0; x < fakeTemp.length; x++) {
        context.moveTo(x * portionWidth + 5, graphicHeight - portionHeight * fakeTemp[x]);
        context.lineTo((x + 1) * portionWidth + 5, graphicHeight - portionHeight * fakeTemp[x + 1]);
    }
    context.closePath();
    context.stroke();
    


    
    for (var x = 0; x < fakeTemp.length; x++) {
        context.beginPath();
        context.arc(x * portionWidth + 7, graphicHeight - portionHeight * fakeTemp[x], 7, 0, 2 * Math.PI, false);
        context.closePath();
        context.fillStyle = "#9e2222";
        context.fill();
    }
    
    


   
    
    context.beginPath();

    context.strokeStyle = "#999999";
    context.lineWidth = 2;

    context.moveTo(0, graphicHeight);
    context.lineTo(graphicWidth, graphicHeight);
    context.stroke();

    
}