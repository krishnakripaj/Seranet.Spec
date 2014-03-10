(function () {
    'use strict';
    var controllerId = 'project';
    angular.module('app').controller(controllerId, ['$scope', 'common', '$routeParams', '$http', project]);

    function project($scope, common, $routeParams, $http) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);


        $scope.areas = [];
        $scope.incompletedPractisesCount = 0;
        //$scope.areas[i].level gives the level of i-th area
        // $scope.areas[i].SubAreas[j].level gives the level of j-th sub area in i-th area
        $scope.projectName = "";
        $scope.projectId = $routeParams.projectId;
        $scope.claims = new Object();   //the dictionary for claim status practice_id-->>status
        $scope.toBeCompletedCount;
        $scope.completedCount;
        $scope.subAreaName = "";

        $scope.setPractisesArray = function (practises, subareaName) {
            $scope.practices = [];
            $scope.completedPractises = [];
            $scope.pendingPractises = [];
            $scope.incompletedPractises = [];


            $scope.subAreaName = subareaName;
            $scope.practices = practises;
            console.log(practises);

            var index = 0;
            var index1 = 0;
            var index2 = 0;

            for (var i = 0; i < Object.keys($scope.practices).length; i++) {
               
                for (var j =0; j < Object.keys($scope.claims).length; j++) {
                    if (j+1 == $scope.practices[i].Id) {
                        if ($scope.claims[j+1] == 1)
                        {
                            $scope.completedPractises[index] = practises[i];
                            console.log("Got one! " + index);
                            index++;
                        }
                        else if ($scope.claims[j+1] == 2) {
                            $scope.incompletedPractises[index1] = practises[i];
                            console.log("Incompleted one! " + index1);
                            index1++;
                        }
                        else  {
                            $scope.pendingPractises[index2] = practises[i];
                            console.log("Pending one! " + index2);
                            index2++;
                        }
                   
                       
                    }
                }

                $scope.toBeCompletedCount = index2 + index1 ;
                $scope.completedCount = index;
            }

        }


        var vm = this;
        vm.title = " score card";

        activate();

        function activate() {
            common.activateController([], controllerId).then(function () { log('Activated Project View'); });

            $http({ method: 'GET', url: 'api/model' }).
               success(function (data, status, headers, config) {
                   console.log(data);
                   for (var i = 0; i < data.length; i++) {
                       $scope.areas.push(data[i]);
                   };

                   $http({ method: 'GET', url: 'api/project/' + $scope.projectId }).
                   success(function (data, status, headers, config) {
                       $scope.projectName = data.Name;

                       $http({ method: 'GET', url: 'api/projectprogress/' + $scope.projectId }).
                       success(function (data, status, headers, config) {
                           console.log(data);
                           for (var i = 0; i < data.length; i++) {
                               $scope.claims[data[i].Practice_Id] = data[i].Status;
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
            for (var i = 0; i < $scope.areas.length; i++) {
                var arealevel = 3;
                var practicesCount = 0;
                var certificatesCount = 0;
                for (var j = 0; j < $scope.areas[i].SubAreas.length; j++) {
                    var level = 3;
                    var subpracticesCount = 0;
                    var subcertificatesCount = 0;
                    for (var k = 0; k < $scope.areas[i].SubAreas[j].Practices.length; k++) {

                        if (!($scope.areas[i].SubAreas[j].Practices[k].Id in $scope.claims)) {
                            if ($scope.areas[i].SubAreas[j].Practices[k].Level.Id <= level) {

                                level = $scope.areas[i].SubAreas[j].Practices[k].Level.Id - 1;
                            }
                        }
                        else {
                            if (!($scope.areas[i].SubAreas[j].Practices[k].Obsolete)) {

                                if ($scope.claims[$scope.areas[i].SubAreas[j].Practices[k].Id] != 1) {

                                    if ($scope.areas[i].SubAreas[j].Practices[k].Level.Id <= level) {

                                        level = $scope.areas[i].SubAreas[j].Practices[k].Level.Id - 1;
                                    }

                                }

                                else {
                                    subcertificatesCount++;
                                }
                            }

                        }

                        if (!($scope.areas[i].SubAreas[j].Practices[k].Obsolete)) {
                            subpracticesCount++;
                        }

                    }
                    $scope.areas[i].SubAreas[j].practices = subpracticesCount;
                    $scope.areas[i].SubAreas[j].certificates = subcertificatesCount;
                    $scope.areas[i].SubAreas[j].level = level;
                    practicesCount += subpracticesCount;
                    certificatesCount += subcertificatesCount;
                    if (arealevel >= level) {
                        arealevel = level;
                    }

                    var substyle = "";
                    var levelPercentage;
                    if ($scope.areas[i].SubAreas[j].level == 0) {
                        substyle = "black";
                        levelPercentage = 0;
                    }
                    else if ($scope.areas[i].SubAreas[j].level == 1) {
                        substyle = "red";
                        levelPercentage = 25;
                    }
                    else if ($scope.areas[i].SubAreas[j].level == 2) {
                        substyle = "yellow";
                        levelPercentage = 75;
                    }
                    else if ($scope.areas[i].SubAreas[j].level == 3) {
                        substyle = "dark-green";
                        levelPercentage = 100;
                    }

                    document.getElementById($scope.areas[i].SubAreas[j].Id).className = "progress-bar " + substyle + "-back";
                    document.getElementById($scope.areas[i].SubAreas[j].Name).className = substyle + "-text bold-text large-text";
                    document.getElementById($scope.areas[i].SubAreas[j].Id).style.width = levelPercentage + "%";

                }

                $scope.areas[i].practices = practicesCount;
                $scope.areas[i].certificates = certificatesCount;
                $scope.areas[i].level = arealevel;
                var style = "";
                if ($scope.areas[i].level == 0)
                    style = "black-back";
                else if ($scope.areas[i].level == 1)
                    style = "red-back";
                else if ($scope.areas[i].level == 2)
                    style = "yellow-back";
                else if ($scope.areas[i].level == 3)
                    style = "dark-green-back";

                document.getElementById($scope.areas[i].Name).className = "content-box-type-three " + style + " clearfix";
            }
        }
    }
})();