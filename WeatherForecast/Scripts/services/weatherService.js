(function () {
    'use strict';
    angular
        .module('WeatherApp')
        .factory('WeatherService', WeatherService);

    WeatherService.$inject = ['$http', '$q'];

    function WeatherService($http, $q) {

        var service = {
            getWetherReport: getWeatherReport
        }

        function getWeatherReport(city) {
            var result = $q.defer();

            var params = { cityName: city };

            return $http({
                method: 'GET',
                url: '/Home/GetWeatherReport',
                params: params,
                headers: { 'Content-Type': 'application/json' }
            })
                .success(function (response) {
                    result.resolve(response);
                })
                .error(function (response) {
                    result.reject(response);
                });
        }
        return service;
    }
})();