(function () {
    'use strict';
    var controllerId = 'project';
    angular.module('app').controller(controllerId, ['$scope', 'common', '$routeParams', '$http', project]);

    function project($scope, common, $routeParams, $http) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var vm = this;
        vm.title = " score card";

        $scope.areas = [];
        $scope.incompletedPractisesCount = 0;
        $scope.level_list = [0, 1, 2];

        //$scope.areas[i].level gives the level of i-th area
        // $scope.areas[i].SubAreas[j].level gives the level of j-th sub area in i-th area
        $scope.projectName = "";
        $scope.projectInContext;
        $scope.projectAssignment = "";
        $scope.userName = "";
        $scope.isMember = "yes";
        $scope.projectId = $routeParams.projectId;
        $scope.claims = new Object();   //the dictionary for claim status practice_id-->>status
        $scope.toBeCompletedCount;
        $scope.completedCount;
        $scope.subAreaName = "";
        $scope.changedClaims = false;


        $scope.listOfAllClaims = [];

        $scope.setPractisesArray = function (practises, subareaName) {

            if ($scope.changedClaims) {
                $http({ method: 'GET', url: 'api/projectprogress/' + $scope.projectId }).
                       success(function (data, status, headers, config) {
                           console.log(data);
                           for (var i = 0; i < data.length; i++) {
                               $scope.claims[data[i].Practice_Id] = data[i].Status;
                           };
                           setPractices();

                       }).
                       error(function (data, status, headers, config) {
                           console.log(data);
                           // called asynchronously if an error occurs
                           // or server returns response with an error status.
                       });
            }
            else {
                setPractices();
            }

            function setPractices() {
                $scope.listOfAllClaims.length = 0;
                $scope.practices = [];
                $scope.completedPractises = [];
                $scope.pendingPractises = [];
                $scope.incompletedPractises = [];

                for (var i = 0 ; i < 3 ; i++) {
                    $scope.completedPractises[i] = [];
                    $scope.pendingPractises[i] = [];
                    $scope.incompletedPractises[i] = [];
                }


                $scope.subAreaName = subareaName;
                $scope.practices = practises;
                console.log(practises);

                var index = 0;
                var index1 = 0;
                var index2 = 0;

                for (var i = 0; i < Object.keys($scope.practices).length; i++) {

                    if (typeof $scope.claims[$scope.practices[i].Id] === "undefined" || $scope.claims[$scope.practices[i].Id] === 0) {
                        $scope.incompletedPractises[$scope.practices[i].Level.Id - 1].push(practises[i]);
                        console.log("Unclaimed or rejected one! " + index1 + " " + $scope.incompletedPractises[$scope.practices[i].Level.Id - 1]);
                        index1++;
                    }
                    if ($scope.claims[$scope.practices[i].Id] == 1) {
                        $scope.completedPractises[$scope.practices[i].Level.Id - 1].push(practises[i]);
                        console.log($scope.completedPractises[0]);
                        console.log("Got one! " + index + " " + $scope.completedPractises[$scope.practices[i].Level.Id - 1]);
                        index++;
                    }
                    else if ($scope.claims[$scope.practices[i].Id] == 2) {
                        $scope.pendingPractises[$scope.practices[i].Level.Id - 1].push(practises[i]);
                        console.log("Pending one! " + index2 + " " + $scope.pendingPractises[$scope.practices[i].Level.Id - 1]);
                        index2++;
                    }

                    $scope.toBeCompletedCount = index1 + index2;
                    $scope.completedCount = index;
                }
            }

            //can do through for loop
            document.getElementById("popup-level1-raw").className = "col-md-1 red-back  content-box-type-two";
            document.getElementById("popup-level2-raw").className = "col-md-1 yellow-back  content-box-type-two";
            document.getElementById("popup-level3-raw").className = "col-md-1 green-back  content-box-type-two";
        }

        //function to save the claims
        $scope.createClaimRequest = function (practise) {

            console.log(practise);
            var l = "#incompleteCheckBox" + practise.Id;
            var data = {};
            console.log(l);
            if (!$(l).prop('checked')) {
                // $scope.listOfAllClaims.pop();

                $scope.listOfAllClaims.splice($.inArray($scope.findClaimObject(practise.Id), $scope.listOfAllClaims), 1);

                console.log("not clicked - " + l);
                console.log($scope.listOfAllClaims);
            }
            else {

                data['AuditorComment'] = "Seed Auto generated ";
                data['Practice'] = practise;
                data['Project'] = $scope.projectInContext;
                data['TeamComment'] = "Seed Auto generated ";

                $scope.listOfAllClaims.push(data);
                console.log("clicked - " + l);
                console.log($scope.listOfAllClaims);
            }
        };

        $scope.findClaimObject = function (claimPracticeId) {

            for (var i = 0, len = $scope.listOfAllClaims.length; i < len; i++) {

                if ($scope.listOfAllClaims[i].Practice.Id === claimPracticeId)
                    return $scope.listOfAllClaims[i]; // Return as soon as the object is found

            }

            return null; // The object was not found

        }

        $scope.createAndSaveClaimRequestsArray = function () {
            $scope.changedClaims = true;
            jQuery.noConflict();
            $(document).ready(function () {
                $('#myModal').modal('hide');
            });

            if ($scope.listOfAllClaims.length != 0) {
                $http.post("api/claims", $scope.listOfAllClaims).success(function (data, status, headers) {
                    console.log("Claim aray added");
                })

                //for (var i = 0; i < $scope.listOfAllClaims.length; i++) {
                //    var divId = "IncompleteDiv" + $scope.listOfAllClaims[i].Practice.Id;

                //    console.log(divId);
                //    document.getElementById(divId).className = "row grid disabled-practise-div";
                //}
            }
        }

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

                       $scope.projectInContext = data;

                       $scope.projectName = data.Name;
                       $scope.projectAssignment = data.ProjetId;

                       $http({ method: 'GET', url: 'api/projectprogress/' + $scope.projectId }).
                       success(function (data, status, headers, config) {
                           console.log(data);
                           for (var i = 0; i < data.length; i++) {
                               $scope.claims[data[i].Practice_Id] = data[i].Status;
                           };
                           calculate();
                           isAMember($scope.projectAssignment).then(function () {
                               console.log('Success: ' + $scope.isMember);
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

       

        function isAMember(projectAssignment) {
            var promise = $http({ method: 'GET', url: 'security/username' }).
                       success(function (data, status, headers, config) {
                           console.log(data);
                           //$scope.userName = data.split("\\")[1].toString().toLowerCase();
                           $scope.userName = "nirangad";
                           $http.get("http://99xtechnology.lk/services/api/Projects", { withCredentials: true }).
                            success(function (data) {
                                console.log(data);
                                for (var i = 0; i < data.length; i++) {
                                    if (projectAssignment.toLowerCase() == data[i].assignment.toLowerCase()) {
                                        if (data[i].rep.toLowerCase() == $scope.userName)
                                            $scope.isMember = "yes";
                                        else {
                                            for (var j = 0; j < data[i].members.length ; j++) {
                                                if (data[i].members[j].toLowerCase() == $scope.userName)
                                                    $scope.isMember = "yes";
                                            }

                                        }
                                    }
                                }

                            }).
                            error(function (data, error) {
                                console.log(error);
                            });

                       }).
                       error(function (data, status, headers, config) {
                           console.log(data);
                           // called asynchronously if an error occurs
                           // or server returns response with an error status.
                       });
            return promise;
        }

    }
})();