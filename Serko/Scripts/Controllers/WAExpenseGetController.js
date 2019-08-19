var app = angular.module('MyApp');
app.controller('WAExpenseGetController', function ($scope,$location, WAExpenseGetService) {
    console.log('1');
    getAll();

    function getAll() {
        var servCall = WAExpenseGetService.getSubs();
        servCall.then(function (d) {
          
            $scope.expense = angular.fromJson(d.data);  // d.data;
            if ($scope.expense.Total == '0') {
                $scope.result = 'XML does not contain Total';
                $scope.expense = null;
            }

          

        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.' + error.ExceptionMessage)
        })
    }
});   