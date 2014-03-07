(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['$scope', 'common', '$http' , dashboard]);

    function dashboard($scope,common, $http) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);




        $scope.areas = [];
        $scope.projectlist = [];
        //$scope.areas[i].level gives the level of i-th area
        // $scope.areas[i].SubAreas[j].level gives the level of j-th sub area in i-th area
        $scope.claims = new Object();   //the dictionary for claim status practice_id-->>status
       
        var vm = this;
        //vm.news = {
        //    title: 'Hot Towel Angular',
        //    description: 'Hot Towel Angular is a SPA template for Angular developers.'
        //};
        //vm.messageCount = 0;
        //vm.people = [];
        vm.title = 'Dashboard';

        activate();

        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });

            



            $http({ method: 'GET', url: 'api/model' }).
               success(function (data, status, headers, config) {
                   console.log(data);
                   for (var i = 0; i < data.length; i++) {
                       $scope.areas.push(data[i]);
                   };

                   $http({ method: 'GET', url: 'api/project' }).
                   success(function (data, status, headers, config) {
                       console.log(data);
                       for (var i = 0; i < data.length; i++) {
                           $scope.projectlist.push(data[i]);
                       };

                       $http({ method: 'GET', url: 'api/projectprogress'}).
                       success(function (data, status, headers, config) {
                           console.log(data);
                           for (var i = 0; i < data.length; i++) {
                               {
                                   $scope.claims[data[i].Project_Id+":"+data[i].Practice_Id] = data[i].Status;
                               }
                           };
                           calculate();
                       }).
                       error(function (data, status, headers, config) {
                           console.log(data);
                           // called asynchronously if an error occurs
                           // or server returns response with an error status.
                       });

                   }).
                   error(function (data, status, headers, config) {
                       console.log(data);
                       // called asynchronously if an error occurs
                       // or server returns response with an error status.
                   });

               }).
               error(function (data, status, headers, config) {
                   console.log(data);
                   // called asynchronously if an error occurs
                   // or server returns response with an error status.
               });


        }


    function calculate() {
        //if (2 in $scope.claims)
        //console.log('yes');
        for (var p = 0; p < $scope.projectlist.length; p++) {
            var projectlevel = 3;
            $scope.projectlist[p].areas = [];

            //certificateCount(p);
            for (var i = 0; i < $scope.areas.length; i++) {
                var arealevel = 3;
                var practicesCount = 0;
                var certificatesCount = 0;
                for (var j = 0; j < $scope.areas[i].SubAreas.length; j++) {
                    var level = 3;
                    for (var k = 0; k < $scope.areas[i].SubAreas[j].Practices.length; k++) {

                        if (!(($scope.projectlist[p].Id + ":" + $scope.areas[i].SubAreas[j].Practices[k].Id) in $scope.claims)){
                            if($scope.areas[i].SubAreas[j].Practices[k].Level.Id <= level) {

                                level = $scope.areas[i].SubAreas[j].Practices[k].Level.Id - 1;
                            }
                        }
                        else {
                            if (!($scope.areas[i].SubAreas[j].Practices[k].Obsolete)){
                                
                                if($scope.claims[$scope.projectlist[p].Id+":"+$scope.areas[i].SubAreas[j].Practices[k].Id] != 1){

                                    if($scope.areas[i].SubAreas[j].Practices[k].Level.Id <= level) {

                                        level = $scope.areas[i].SubAreas[j].Practices[k].Level.Id - 1;
                                    }

                                }

                                else {
                                    certificatesCount++;
                                }
                            }

                        }

                        if (!($scope.areas[i].SubAreas[j].Practices[k].Obsolete)){
                            practicesCount ++;
                        }
                    }
                    //$scope.areas[i].SubAreas[j].level = level;
                    
                    //$scope.SubAreaslevel[$scope.projectlist[p].Project_Id
                    if (arealevel >= level) {
                        arealevel = level;
                       
                    }

                }
                $scope.projectlist[p].areas.push({ arealevel: arealevel, areacertificates: certificatesCount, areapractices: practicesCount });

                if (projectlevel >= arealevel) {
                    projectlevel = arealevel;
                }

                
            }

            $scope.projectlist[p].level = projectlevel;
        }

    }

    /*function certificateCount(projectId) {


        $http({ method: 'GET', url: 'api/certificates/' + projectId }).
        success(function (data, status, headers, config) {
            console.log(data);
            $scope.projectlist[projectId].certificates = data;
        }).
        error(function (data, status, headers, config) {
            console.log(data);
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });
    }*/

    }
    
})();