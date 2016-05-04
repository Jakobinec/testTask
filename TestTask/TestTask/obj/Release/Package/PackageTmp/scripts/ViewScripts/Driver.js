var driverPage = angular.module('driverPage', []);
driverPage.controller('driverController', function ($scope, $http) {
            
    // Get driver query
    debugger;
    var driverId = angular.element(document.getElementById("driverId"))[0].textContent;
    if(driverId != 0)
    {
        $http.get('/api/driver/' + driverId).success(function (responce) {
            $scope.driver = responce;
        });
    }

    $scope.submit=function(){
        if(driverId != 0)
        {
            // We have an update existing note
            $http({
                method: 'POST',
                url: '/api/driver',
                params:  $scope.driver,
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
                url: '/api/driver',
                params:  $scope.driver,
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
    var driverId = angular.element(document.getElementById("driverId"))[0].textContent;
    $http.get('/api/driver/' + driverId).success(function (responce) {
        var firstDriver = responce;
        scope.$apply(function(){
            scope.driver = firstDriver;
        })
    });
}

function deleteDriver() {
    var $http = angular.injector(["ng"]).get("$http");
    var driverId = angular.element(document.getElementById("driverId"))[0].textContent;
    $http.delete('/api/driver/' + driverId).success(function (responce) {
        location.href = '/Home/Index';
    });
}