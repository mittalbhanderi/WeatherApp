(function () {
    'use strict';
    angular
        .module('WeatherApp')
        .factory('WeatherService', WeatherService);

    WeatherService.$inject = ['$http'];

    function WeatherService($http) {

        var service = {
            getWeatherReport: getWeatherReport
        };

        function getWeatherReport(city) {

            var params = { cityName: city };

            var result =  $http({
                method: 'GET',
                url: '/Home/GetWeatherReport',
                params: params,
                headers: { 'Content-Type': 'application/json' }
                }).then(function(response){
                    return response; 
                }, function(response){
                    return response;
                });

            return result;
        }
        return service;
    }
})();