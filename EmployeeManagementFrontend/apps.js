var app = angular.module('employeeApp', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider

        .when('/', {
            templateUrl: 'pages/home.html',
            controller: 'homeController',
            controllerAs: 'homeCtrl'
        })

        .when('/about', {
            templateUrl: 'pages/about.html',
            controller: 'aboutController'
        })

        .when('/contact', {
            templateUrl: 'pages/contact.html',
            controller: 'contactController'
        })

        .when('/AddEmployeeData', {
            templateUrl: 'pages/AddEmployeeData.html',
            controller: 'addController'
        })

        .when('/UpdateEmployeeData', {
            templateUrl: 'pages/UpdateEmployeeData.html',
            controller: 'updateController'
        })

        .when('/DeleteEmployeeData', {
            templateUrl: 'pages/DeleteEmployeeData.html',
            controller: 'deleteController'
        })
        .otherwise({
            redirectTo: "/"
        })
});
