var carPage = angular.module('carPage', []);
carPage.controller('carController', function ($scope, $http) {

    // Get car query
    var carId = angular.element(document.getElementById("carId"))[0].textContent;
    if(carId != 0)
    {
        $http.get('/api/car/' + carId).success(function (responce) {
            $scope.car = responce;
        });
    }

    // Get drivers list to select query
    $http.get('/api/driver').success(function (drResponce) {
        $scope.drivers = drResponce;
    });


    $scope.submit=function(){
        if(carId != 0)
        {
            // We have an update existing note
            $http({
                method: 'POST',
                url: '/api/car',
                params:  $scope.car,
                headers: { 'Content-Type': 'application/json' }
            }).then(function successCallback(response) {
                location.href = '/Home/Index';
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
        }
        else
        {
            // Create new note
            $http({
                method: 'PUT',
                url: '/api/car',
                params:  $scope.car,
                headers: { 'Content-Type': 'application/json' }
            }).then(function successCallback(response) {
                location.href = '/Home/Index';
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
        }
    }
});

function cancel() {
    location.href = '/Home/Index';
}

function revert() {
    var scope = angular.element(document.getElementById("wrap")).scope();
    var $http = angular.injector(["ng"]).get("$http");
    var carId = angular.element(document.getElementById("carId"))[0].textContent;
    $http.get('/api/car/' + carId).success(function (responce) {
        var firstCar = responce;
        scope.$apply(function(){
            scope.car = firstCar;
        })
    });
}

function deleteCar() {
    var $http = angular.injector(["ng"]).get("$http");
    var carId = angular.element(document.getElementById("carId"))[0].textContent;
    $http.delete('/api/car/' + carId).success(function (responce) {
        location.href = '/Home/Index';             
    });
}