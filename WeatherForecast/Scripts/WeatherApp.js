(function () {
    'use strict';

    if (!window.console) {
        var noOp = function () { }; // no-op function
        window.console = {
            log: noOp,
            warn: noOp,
            error: noOp
        };
    }
    var WeatherApp = angular.module('WeatherApp', []);

    //disable debug data to gain some performance on prod environment
    //comment the lines below on dev environment
    WeatherApp.config(['$compileProvider', '$httpProvider', function ($compileProvider, $httpProvider) {
        $compileProvider.debugInfoEnabled(false);
        $httpProvider.useApplyAsync(true);
    }]);

})(window.angular);