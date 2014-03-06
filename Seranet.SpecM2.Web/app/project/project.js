(function () {
    'use strict';
    var controllerId = 'project';
    angular.module('app').controller(controllerId, ['$scope', 'common', '$routeParams', '$http', project]);

    function project($scope, common, $routeParams, $http) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        
        $scope.areas = [];
        $scope.project = "";
        $scope.practices = {};
        var practiceLevel = {
            p1: { L1: [a, b], L2: [e, f] },
            p2: { L1: [x, y], L2: [g, h] }
        }

        var areaData = {    }
        var vm = this;
        vm.title = $scope.project + " score card";

        activate();

        function activate() {
            common.activateController([], controllerId).then(function () { log('Activated Project View'); });

            $http({ method: 'GET', url: 'api/model' }).
               success(function (data, status, headers, config) {
                   console.log(data);
                   for (var i = 0; i < data.length; i++) {
                       $scope.areas.push(data[i]);
                       
                       
                   };
               }).
               error(function (data, status, headers, config) {
                   console.log(data);
                   // called asynchronously if an error occurs
                   // or server returns response with an error status.
               });


            $http({ method: 'GET', url: 'api/project/' + $routeParams.projectId }).
               success(function (data, status, headers, config) {
                   $scope.project = data.Name;
                  // $scope.$apply();
               }).
               error(function (data, status, headers, config) {
                   console.log(data);
                   // called asynchronously if an error occurs
                   // or server returns response with an error status.
               });

            $http({ method: 'GET', url: 'api/projectprogress/' + $routeParams.projectId }).
              success(function (data, status, headers, config) {
                  console.log(data);
                  for (var i = 0; i < data.length; i++) {
                      $scope.practices[data[i].Practice_Id] = data[i].Status                    
                  };               
                  
              }).
              error(function (data, status, headers, config) {
                  console.log(data);
                  // called asynchronously if an error occurs
                  // or server returns response with an error status.
              });
            
        }
    }
})();       