var app = angular.module('app', ['ngRoute']);

app.config(function($routeProvider){
  $routeProvider
    .when('/', {
      templateUrl: 'App/components/views/home.html',
      controller: 'mainController'
    })
    .otherwise({
      redirectTo: '/'
    });
});

app.controller('rootController', function($scope){
  $scope.viewbag = "I am ROOT";
});
