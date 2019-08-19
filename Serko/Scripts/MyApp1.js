(function () {
    var app = angular.module('MyApp', []);
    app.controller('myCtrl', function ($scope) {
        $scope.name = "Zaheer";
    });
    app.controller('myModule', function ($scope) {
        $scope.test = "TEST";
    });

    app.service("APIService", function ($http) {
        this.getSubs = function () {
            console.log("1");
            return $http.get("http://localhost:51638/api/expense/Get")
        }  
    });   


    app.controller('APIController', function ($scope, APIService) {
        console.log("2");
        getAll();

        function getAll() {
            console.log("3");
            var servCall = APIService.getSubs();
            servCall.then(function (d) {
                console.log(d.data);
                $scope.expense = angular.fromJson(d.data);  // d.data;
                console.log(angular.fromJson(d.data));
            }, function (error) {
                console.log('Oops! Something went wrong while fetching the data.')
            })
        }
    });   

})();