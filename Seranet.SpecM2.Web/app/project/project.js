(function () {
    'use strict';
    var controllerId = 'project';
    angular.module('app').controller(controllerId, ['common', '$routeParams', project]);

    function project(common, $routeParams) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Project ' + $routeParams.projectId;

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated Project View'); });
        }
    }
})();