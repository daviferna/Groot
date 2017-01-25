app.directive('myDirective', [function(){
  return{
    restrict: 'E',
    template: "<p>I am a directive</p>"
  };
}]);
