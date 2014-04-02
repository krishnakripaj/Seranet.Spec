(function () {
    'use strict';
    var controllerId = 'admin';
    angular.module('app').controller(controllerId, ['common', '$scope','$http',admin]);

    function admin(common,$scope,$http) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Admin';
        $scope.isAdmin = "no";
        activate();

        function activate() {
            $http({ method: 'GET', url: 'security/username' }).
              success(function (data, status, headers, config) {
                  console.log(data);
                  //$scope.userName = data.split("\\")[1].toString().toLowerCase();
                  $scope.userName = "nirangad";
                  $http({ method: 'GET', url: 'api/userrole/' + $scope.userName }).
                      success(function (data, status, headers, config) {
                          if (data == 0) {
                              $scope.isAdmin = "yes";
                              console.log("Admin page writes granted");
                          }
                          else {
                              $scope.isAdmin = "no";
                          }

                      }).
                      error(function (data, status, headers, config) {
                          console.log(data);
                      });

              }).
              error(function (data, status, headers, config) {
                  console.log(data);
              });
            common.activateController([], controllerId)
                .then(function () { log('Activated Admin View'); });
        }
    }
})();