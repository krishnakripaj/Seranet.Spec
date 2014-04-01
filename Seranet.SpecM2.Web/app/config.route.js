(function () {
    'use strict';
    var controllerId='config.route';
    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        //$routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes($http) {

        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/dashboard/dashboard.html'
                }
            }, {
                url: '/admin',
                config: {
                    templateUrl: 'app/admin/admin.html'
                }
            }, {
                url: '/project/:projectId',
                config: {
                    templateUrl: 'app/project/project.html'
                }
            }, {
                url: '/activities',
                config: {
                    templateUrl: 'app/activities/activities.html'
                }
            }
        ];
    }
})();