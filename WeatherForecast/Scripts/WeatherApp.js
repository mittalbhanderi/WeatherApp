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

})(window.angular);