(function () {
    'use strict';

    angular
        .module('WeatherApp')
        .controller('WeatherController', WeatherController);


    WeatherController.$inject = ['$scope', 'WeatherService'];

    function WeatherController($scope, WeatherService) {

        $scope.weatherData = [];
        $scope.weekDays = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
        $scope.weatherDays = [];
        $scope.myFilter;

        var todaysDate = new Date();

        $scope.weatherForm = {
            cityName: ''
        };

        $scope.getWeatherData = function () {
            var result = WeatherService.getWetherReport($scope.weatherForm.cityName);
            result.then(function (response) {
                $scope.weatherData = JSON.parse(response.data);
                if ($scope.weatherData.forecastList !== null) {
                    $scope.weatherData.forecastList.forEach(function (forecast) {
                        if ($scope.weatherDays.indexOf(forecast.day) < 0) {
                            if ($scope.weatherDays.length < 5)
                                $scope.weatherDays.push(forecast.day);
                        }
                    });
                    $scope.myFilter = $scope.weekDays[todaysDate.getDay()];
                }
            }, function (response) {
                console.log(response.message);
            });
        };

        $scope.setFilter = function (event, day) {
            event.preventDefault();
            $scope.myFilter = day;
        };

        $scope.filterByDay = function (forecast) {
            return forecast.day === $scope.myFilter;
        };

        $scope.displayErrorDiv = function () {
            return $scope.weatherData !== null && $scope.weatherData.errorMessage !== null && $scope.weatherData.errorMessage.length > 0;
        };
    }

})();
