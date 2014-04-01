(function () {
    'use strict';

    var controllerId = 'topnav';
    angular.module('app').controller(controllerId,
        ['$scope', 'common', '$routeParams', '$http', topnav]);

    function topnav($scope, common, $routeParams, $http) {
        var vm = this;
        var role = "team";
        $scope.userName = "";
        $scope.isAdmin = "no";
        
        activate();
        
        function activate() {

            $http({ method: 'GET', url: 'security/username' }).
                success(function (data, status, headers, config) {
                    console.log(data);
                    $scope.userName = data.split("\\")[1].toString().toLowerCase();
                    
                    $http({ method: 'GET', url: 'api/userrole/' + $scope.userName }).
                        success(function (data, status, headers, config) {
                            if (data == 0) {
                                $scope.isAdmin = "yes";
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


            
        }
    };
})();