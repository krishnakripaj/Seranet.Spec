(function () {
    'use strict';
    var controllerId = 'project';
    angular.module('app').controller(controllerId, ['$scope', 'common', '$routeParams', '$http','$route', project]);

    function project($scope, common, $routeParams, $http,$route) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var vm = this;
        vm.title = " score card";

        var logSuccess = common.logger.getLogFn(controllerId, 'success');
       // vm.busyMessage = 'Please wait ...';
        vm.isBusy = true;
        vm.spinnerOptions = {
            radius: 40,
            lines: 7,
            length: 0,
            width: 30,
            speed: 1.7,
            corners: 1.0,
            trail: 100,
            color: '#F58A00'
        };




        $scope.areas = []; //$scope.areas[i].level gives the level of i-th area,$scope.areas[i].SubAreas[j].level gives the level of j-th sub area in i-th area
        $scope.incompletedPractisesCount = 0;
        $scope.level_list = [0, 1, 2];       
        
        $scope.projectName = "";
        $scope.projectInContext;
        $scope.projectAssignment = "";
        $scope.userName = "";
        $scope.isMember = "no";
        $scope.isAuditor = "no";
        $scope.projectId = $routeParams.projectId;
        $scope.claims = new Object();   //the dictionary for claim status practice_id-->>status
        $scope.toBeCompletedCount;
        $scope.completedCount;
        $scope.hasPractices;
        $scope.subAreaName = "";
        $scope.changedClaims = false;


        $scope.listOfAllClaims = [];
        $scope.auditedClaims = [];

        $scope.rejectClaim = function (practice) {
            document.getElementById('btn-reject' + practice.Id).disabled = true;
            if ($scope.claims[practice.Id] == 0) {
                document.getElementById('btn-accept' + practice.Id).disabled = true;
            }
            $scope.claims[practice.Id] = 2;
            var auditedbefore = false;
            var data = {};
            data['practice_id'] = practice.Id;
            data['status'] = 2;
            data['project_id'] = $scope.projectId;
            for (var i = 0; i < $scope.auditedClaims.length; i++) {
                if ($scope.auditedClaims[i].practice_id == data['practice_id']) {
                    $scope.auditedClaims[i].status = 2;
                    auditedbefore = true;
                }
            }
            if (auditedbefore == false) {
                $scope.auditedClaims.push(data);
            }
            console.log(practice.Id+" claim is rejected");
            console.log($scope.auditedClaims);
           
            
        }

        $scope.acceptClaim = function (practice) {
            document.getElementById('btn-reject' + practice.Id).disabled = true;
            document.getElementById('btn-accept' + practice.Id).disabled = true;
          
            $scope.claims[practice.Id] = 1;
            var auditedbefore = false;
            var data = {};
            data['practice_id'] = practice.Id;
            data['status'] = 1;
            data['project_id'] = $scope.projectId;
            for (var i = 0; i < $scope.auditedClaims.length; i++) {
                if ($scope.auditedClaims[i].practice_id === data['practice_id']) {
                    $scope.auditedClaims[i].status = 1;
                    auditedbefore = true;
                }
            }
            if (auditedbefore === false) {
                $scope.auditedClaims.push(data);
            }
            console.log(practice.Id + " claim is accepted");
            console.log($scope.auditedClaims);
        }

        $scope.cancelAuditing = function () {

            $scope.auditedClaims.length = 0;
            //$scope.changedClaims = true;

            $scope.closeModalPopup();
        }

        $scope.saveAudited = function () {
            //$scope.changedClaims = true;
            if ($scope.auditedClaims.length != 0) {
                $http.post("api/auditor", $scope.auditedClaims).
                    success(function (data, status, headers) {
                       // $route.reload();
                        console.log("Auditor processed the claims");
                        console.log($scope.auditedClaims);
                        $scope.closeModalPopup();
                    }).
                    error(function (data, status, headers, config) {
                        console.log(data);
                        alert("unauthorized action");
                        $scope.closeModalPopup();
                                }
                    );
            }
            else {
                $scope.closeModalPopup();
            }

            
        }

        $scope.setPractisesArray = function (practises, subareaName) {
            console.log($('.modal-backdrop'));
            //if (($('.modal-backdrop')).length > 1) {
            //    ($('.modal-backdrop'))[0] = null;
            //}

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
                $scope.hasPractices = [];
                for (var i = 0 ; i < 3 ; i++) {
                    $scope.completedPractises[i] = [];
                    $scope.pendingPractises[i] = [];
                    $scope.incompletedPractises[i] = [];
                    $scope.hasPractices[i] = "no";
                }


                $scope.subAreaName = subareaName;
                $scope.practices = practises;
                console.log(practises);

                var index = 0;
                var index1 = 0;
                var index2 = 0;

                for (var i = 0; i < Object.keys($scope.practices).length; i++) {

                    if (typeof $scope.claims[$scope.practices[i].Id] === "undefined" || $scope.claims[$scope.practices[i].Id] === 2) {
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
                    else if ($scope.claims[$scope.practices[i].Id] == 0) {
                        $scope.pendingPractises[$scope.practices[i].Level.Id - 1].push(practises[i]);
                        console.log("Pending one! " + index2 + " " + $scope.pendingPractises[$scope.practices[i].Level.Id - 1]);
                        $scope.currentSubareaPendings++;
                        index2++;
                    }

                    $scope.toBeCompletedCount = index1 + index2;
                    $scope.completedCount = index;
                    for(var c=0;c<3;c++){
                        if ($scope.incompletedPractises[c].length + $scope.completedPractises[c].length +$scope.pendingPractises[c].length > 0){
                            $scope.hasPractices[c] = "yes";
                        }
                    }
                     
                }
            }
            ////can do through for loop
            //           document.getElementById("popup-level1-raw").className = "col-md-2 red-back  content-box-type-two";
            //           document.getElementById("popup-level2-raw").className = "col-md-2 yellow-back  content-box-type-two";
            //           document.getElementById("popup-level3-raw").className = "col-md-2 green-back  content-box-type-two";
            //           document.getElementById("1-level-wholeraw").className = "row grid palered-back";
            //           document.getElementById("2-level-wholeraw").className = "row grid paleyellow-back";
            //           document.getElementById("3-level-wholeraw").className = "row grid palegreen-back";

 
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

        //when cancel button clicked 
        $scope.cancelAnyClaimsAdded = function () {

            $scope.listOfAllClaims.length = 0;
            $scope.changedClaims = true;

            $scope.closeModalPopup();
        }

        //when save button is clicked
        $scope.saveAnyClaimsAdded = function () {
            $scope.changedClaims = true;

            if ($scope.listOfAllClaims.length != 0) {

                $http.post("api/claims", $scope.listOfAllClaims).
                    success(function (data, status, headers) {
                        console.log("Claim array added");
                        $scope.closeModalPopup();
                    }).
                    error(function (data, status, headers, config) {
                        alert("You are not authorized to claim")
                        console.log(data);
                        $scope.closeModalPopup();
                    });
            }
            $scope.closeModalPopup();
            
            
            
        }

     
        //to hide the modal popup
        $scope.closeModalPopup = function () {
            console.log($('.modal-backdrop'));
            //if (($('.modal-backdrop')).length > 1) {
            //    ($('.modal-backdrop'))[0] = null;
            //}
            jQuery.noConflict();

            var modalDialog = $('#myModal');
            var backdrop = $('.modal-backdrop');
            modalDialog.modal('hide');

            //$(".modal-backdrop").hide();
            //if (modalDialog.modal) {
            //    modalDialog.modal('hide');
            //} else {
            //    setTimeout(function () { modalDialog = $('#myModal'); modalDialog.modal('hide'); }, 1000);
            //}
           // $(document).ready(function () {

            // });
            backdrop.remove();

            $route.reload();
        }
       
       
        //to uncheck all the checkboxes when popup closed
        $('#myModal').on('hidden.bs.modal', function (e) {
            var checkboxes = new Array();
            checkboxes = document.getElementsByName('incompleteCheckboxes');
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].type == 'checkbox') {
                    checkboxes[i].checked = false
                }
            }
            //alert('Modal is sclosed!');
            //console.log($('.modal-backdrop'));
        })
  

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

                       vm.isBusy = false;

                       $http({ method: 'GET', url: 'api/projectprogress/' + $scope.projectId }).
                       success(function (data, status, headers, config) {
                           console.log(data);
                           for (var i = 0; i < data.length; i++) {
                               $scope.claims[data[i].Practice_Id] = data[i].Status;
                           };
                           calculate();
                           isAMember($scope.projectAssignment).then(function () {
                               console.log('Success: isTeamMember: ' + $scope.isMember+' and isAuditor: '+$scope.isAuditor);

                           });
                           //isAuditor($scope.auditorAssignment).then(function () {
                           //    console.log('Success: ' + $scope.isAuditor);
                           //})

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
                var pendingCount = 0;
                for (var j = 0; j < $scope.areas[i].SubAreas.length; j++) {
                    var level = 3;
                    var subpracticesCount = 0;
                    var subcertificatesCount = 0;
                    var subpendingCount = 0;
                    for (var k = 0; k < $scope.areas[i].SubAreas[j].Practices.length; k++) {

                        if (!($scope.areas[i].SubAreas[j].Practices[k].Id in $scope.claims)) {
                            if ($scope.areas[i].SubAreas[j].Practices[k].Level.Id <= level) {

                                level = $scope.areas[i].SubAreas[j].Practices[k].Level.Id - 1;
                            }
                        }
                        else {
                            if (!($scope.areas[i].SubAreas[j].Practices[k].Obsolete)) {

                                if ($scope.claims[$scope.areas[i].SubAreas[j].Practices[k].Id] != 1) {

                                    if ($scope.claims[$scope.areas[i].SubAreas[j].Practices[k].Id] === 0) {
                                        subpendingCount++;
                                        console.log($scope.areas[i].SubAreas[j].Practices[k].Id +" is pending")
                                    }
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
                    $scope.areas[i].SubAreas[j].pendings = subpendingCount;
                    $scope.areas[i].SubAreas[j].level = level;
                    $scope.areas[i].SubAreas[j].hasPendings = "no"
                    if (subpendingCount > 0) {
                        $scope.areas[i].SubAreas[j].hasPendings = "yes";
                        console.log("Pendings identified :" + $scope.areas[i].SubAreas[j].hasPendings);
                    }
                    practicesCount += subpracticesCount;
                    certificatesCount += subcertificatesCount;
                    pendingCount += subpendingCount;
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
                $scope.areas[i].pendings = pendingCount;
                $scope.areas[i].hasPendings="no"
                if (pendingCount > 0) {
                    $scope.areas[i].hasPendings = "yes";
                }
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

                document.getElementById($scope.areas[i].Name).className = "content-box-type-three " + style+ " clearfix";
            }
        }  

        function isAMember(projectAssignment) {
            var promise = $http({ method: 'GET', url: 'security/username' }).
                       success(function (data, status, headers, config) {
                           console.log(data);
                           $scope.userName = data.split("\\")[1].toString().toLowerCase();
                           // $scope.userName = "nirangad";
                           $http.get("http://99xt.lk/services/api/Projects", { withCredentials: true }).
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
                                $http({ method: 'GET', url: 'api/userrole/' + $scope.userName }).
                                 success(function (data, status, headers, config) {
                                     if ((data == 1 || data == 3) && $scope.isMember=="no") {    //enum returns a number as the role (1 : auditoe, 0:admin
                                        $scope.isAuditor = "yes";                //user can be auditor only if he is not a team member                       
                                    }
                                    else {
                                       $scope.isAuditor = "no";
                                    }
                                    console.log("is auditor: " + $scope.isAuditor)
                                }).
                                error(function (data, status, headers, config) {
                                    console.log("An error occured while getting details from Userrole database.");
                                    console.log(data);
                                });

                               }).
                            error(function (data, error) {
                                console.log("An error occured while getting details from 99XT Projects API.");
                                console.log(error);
                            });
                        }).
                error(function (data, status, headers, config) {
                    console.log(data);
                    alert("Credential fails to access the project API")
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                });    
                      
        return promise;
        }      
    }  
    
})();
