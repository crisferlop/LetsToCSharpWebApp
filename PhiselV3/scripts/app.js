myApp = angular.module('myApp', []);

myApp.controller('mainController', function ($scope, $http) {
    $http.get('/home/getProducts')
    .success(function (result) {
        $scope.users = result;
        console.log(result);
    })
    .error(function (data) {
        console.log(data);
    });
})