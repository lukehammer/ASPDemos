var myAngular = angular.module('DatePickerApp', ['ngMaterial']);
myAngular.controller('myController', function ($scope) {
    $scope.CommitDate = new Date();
});