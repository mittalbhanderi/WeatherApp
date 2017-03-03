describe('Weather Controller', function () {
    var ctrl,
        mockWeatherService,
        rootScope,
        httpBackend;

    beforeEach(module('WeatherApp'));

    beforeEach(function () {
        mockWeatherService = jasmine.createSpyObj('WeatherService', ['getWeatherReport']);
        inject(function ($q) {
            mockWeatherService
                .getWeatherReport
                .and
                .returnValue($q.when({}));
        });
    });

    beforeEach(inject(function ($controller) {
        ctrl = $controller('WeatherController', {
            WeatherService: mockWeatherService
        });
    }));

    it(' should be defined', function () {
        expect(ctrl).toBeDefined();
    });

    describe('WeatherController.getWeatherData', function () {
        it('gets the weather data when a valid city is provided in the input', function () {
            expect(ctrl.weekDays.length).toBe(7);
            expect(ctrl.weatherData).toBeDefined();
            expect(ctrl.weatherDays).toBeDefined();
            expect(ctrl.weatherForm).toBeDefined();
            ctrl.getWeatherData();
            expect(mockWeatherService.getWeatherReport).not.toHaveBeenCalled();
            expect(ctrl.weatherData).toEqual([]);
            expect(ctrl.weatherDays).toEqual([]);

            ctrl.weatherForm.cityName = 'London';
            ctrl.getWeatherData();
            expect(mockWeatherService.getWeatherReport).toHaveBeenCalled();
        });
    });

});

describe('Weather Service', function () {
    var $httpBackend;
    var $rootScope;
    var WeatherService;
    var getWeatherReportHandler;

    beforeEach(module('WeatherApp'));
    beforeEach(inject(function (_$httpBackend_, _$rootScope_, _WeatherService_) {
        $httpBackend = _$httpBackend_;
        $rootScope = _$rootScope_;
        WeatherService = _WeatherService_;

        getWeatherReportHandler = $httpBackend.when('GET', '/Home/GetWeatherReport')
            .respond(200, {
                status: 'done'
            });
    }));

    describe('getWeatherReport', function () {
        it('gets the weather report', function (done) {
            $httpBackend.expectGET('/Home/GetWeatherReport');
            WeatherService.getWeatherReport('London').then(function (status) {
                expect(status).not.toBe(null);
                expect(status).not.toBe('done');
                done();
            });
            $httpBackend.flush();
            $rootScope.$apply();
        });
    });
});