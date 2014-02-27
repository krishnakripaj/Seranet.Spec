(function () {
    'use strict';
    var controllerId = 'project';
    angular.module('app').controller(controllerId, ['common', '$routeParams', '$http', project]);

    function project(common, $routeParams, $http) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Project ' + $routeParams.projectId;

        activate();

        function activate() {
            common.activateController([], controllerId).then(function () { log('Activated Project View'); });

            $http({ method: 'GET', url: 'api/scorecard' }).
               success(function (data, status, headers, config) {
                   console.log(data);
               }).
               error(function (data, status, headers, config) {
                   // called asynchronously if an error occurs
                   // or server returns response with an error status.
               });

        }
    }
})();       