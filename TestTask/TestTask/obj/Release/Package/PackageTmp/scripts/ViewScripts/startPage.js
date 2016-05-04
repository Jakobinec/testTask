var carId;
var driverId;
var myapp = angular.module('myapp', []);
myapp.controller('mainController', function ($scope, $http) {
    $http.get('/api/car').success(function (responce) {
        $scope.cars = responce;
    });
    $http.get('/api/driver').success(function (drResponce) {
        $scope.drivers = drResponce;
    });
    $scope.selectedCarId = null;
    $scope.setSelected = function (selectedCarId) {
        $scope.selectedCarId = selectedCarId;
        carId = selectedCarId;
    };

    $scope.selectedDriverId = null;
    $scope.setSelecteDriver = function (selectedDriverId) {
        $scope.selectedDriverId = selectedDriverId;
        driverId = selectedDriverId;
    };
});

function addCar() {
    location.href = '/Home/ViewCar/' + 0;
}

function editCar() {
    location.href = '/Home/ViewCar/' + carId;
}

function addDriver() {
    location.href = '/Home/ViewDriver/' + 0;
}

function editDriver() {
    location.href = '/Home/ViewDriver/' + driverId;
}