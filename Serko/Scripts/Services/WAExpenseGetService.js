var app = angular.module('MyApp');
app.service("WAExpenseGetService", function ($http, $location) {


        this.getSubs = function () {
            return $http.get("http://localhost:51638/api/expense/Get")
        }
        
    
});   