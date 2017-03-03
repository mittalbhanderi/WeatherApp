(function () {
    'use strict';

    angular
        .module('WeatherApp')
        .controller('WeatherController', WeatherController);

    WeatherController.$inject = ['WeatherService'];

    function WeatherController(WeatherService) {
        var vm = this;
        vm.ctrlName = 'WeatherController';

        vm.weatherData = [];
        vm.weekDays = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
        vm.weatherDays = [];
        vm.myFilter;

        var todaysDate = new Date();

        vm.weatherForm = {
            cityName: ''
        };
        
        vm.getWeatherData = function () {
            if (vm.weatherForm.cityName !== '') {
                var result = WeatherService.getWeatherReport(vm.weatherForm.cityName);
                result.then(function (response) {
                    vm.weatherData = JSON.parse(response.data);
                    if (vm.weatherData.forecastList !== null) {
                        vm.weatherData.forecastList.forEach(function (forecast) {
                            if (vm.weatherDays.indexOf(forecast.day) < 0) {
                                if (vm.weatherDays.length < 5)
                                    vm.weatherDays.push(forecast.day);
                            }
                        });
                        vm.myFilter = vm.weekDays[todaysDate.getDay()];
                    } else {
                        vm.weatherData.errorMessage = "This service is currently unavailable. Please try again later!";
                    }
                }, function (response) {
                    console.log(response.message);
                });
            }
        };;

        vm.setFilter = function (event, day) {
            event.preventDefault();
            vm.myFilter = day;
        };

        vm.filterByDay = function (forecast) {
            return forecast.day === vm.myFilter;
        };

        vm.displayErrorDiv = function () {
            return vm.weatherData !== null && vm.weatherData.errorMessage !== null && vm.weatherData.errorMessage;
        };

    }

})();
