//app-trips.js
(function () {
    
    "use strict";

    //Creating the module
        
    angular.module("app-trips", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "tripsController",
                controllerAs: "vm",
                templateUrl:"/views/tripsView.html"
            });

            $routeProvider.when("/editor/:tripName", {
                controller: "tripEditorController",
                controllerAs: "vm",
                templateUrl: "/views/tripEditorView.html"
            });

            $routeProvider.otherwise({ redirecto: "/" });

        });

    angular.module("app-trips")
        .config(['$locationProvider', function ($locationProvider) {
            $locationProvider.hashPrefix('');
        }]);

})();