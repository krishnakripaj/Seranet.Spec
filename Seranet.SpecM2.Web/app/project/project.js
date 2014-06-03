(function () {
    'use strict';
    var controllerId = 'project';
    angular.module('app').controller(controllerId, ['$scope', 'common', '$routeParams', '$http', '$route', project]);

    function project($scope, common, $routeParams, $http, $route) {
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

        $scope.CommentsArray = [];
        $scope.toBeCompletedCount;
        $scope.completedCount;
        $scope.hasPractices;
        $scope.subAreaName = "";
        $scope.changedClaims = false;


        $scope.listOfAllClaims = [];
        $scope.auditedClaims = [];

        $scope.notApplicableClaims = [];

        $scope.rejectClaim = function (practice) {
            document.getElementById('btn-reject' + practice.Id).disabled = true;
            if ($scope.claims[practice.Id] == 0) {
                document.getElementById('btn-accept' + practice.Id).disabled = true;
                document.getElementById('btn-notapplicable' + practice.Id).disabled = true;
                //document.getElementById('auditor-dropdown' + practice.Id).disabled = true;

                
                

            }
            $scope.claims[practice.Id] = 2;
            var auditedbefore = false;
            var data = {};
            data['practice_id'] = practice.Id;
            data['status'] = 2;
            data['project_id'] = $scope.projectId;
            // data['auditor_comment'] = document.getElementById("text-auditor-comment" + practice.Id).value;


            var f = "#addCommentBtn" + practice.Id;
            if (f != null)
                $(f).removeClass('disabled');

            var j = "#addAuditorCommentBtn" + practice.Id;
            if (j != null)
                $(j).removeClass('disabled');

            for (var i = 0; i < $scope.auditedClaims.length; i++) {
                if ($scope.auditedClaims[i].practice_id == data['practice_id']) {
                    $scope.auditedClaims[i].status = 2;
                    auditedbefore = true;
                }
            }
            if (auditedbefore == false) {
                $scope.auditedClaims.push(data);
            }
            console.log(practice.Id + " claim is rejected");
            console.log($scope.auditedClaims);


        }

        $scope.makeClaimNotApplicable = function (practice) {
            document.getElementById('btn-reject' + practice.Id).disabled = true;
            document.getElementById('btn-accept' + practice.Id).disabled = true;
            document.getElementById('btn-notapplicable' + practice.Id).disabled = true;
            //    document.getElementById('auditor-dropdown' + practice.Id).disabled = true;

            var j = "#addAuditorCommentBtn" + practice.Id;

            $(j).removeClass('disabled');


            $scope.claims[practice.Id] = 3;
            var auditedbefore = false;
            var data = {};
            data['practice_id'] = practice.Id;
            data['status'] = 4;
            data['project_id'] = $scope.projectId;

            for (var i = 0; i < $scope.auditedClaims.length; i++) {
                if ($scope.auditedClaims[i].practice_id === data['practice_id']) {
                    $scope.auditedClaims[i].status = 4;
                    auditedbefore = true;
                }
            }
            if (auditedbefore === false) {
                $scope.auditedClaims.push(data);
            }
            console.log(practice.Id + " claim is not applicable");
            console.log($scope.auditedClaims);
        }


        $scope.acceptClaim = function (practice) {
            document.getElementById('btn-reject' + practice.Id).disabled = true;
            document.getElementById('btn-accept' + practice.Id).disabled = true;
            document.getElementById('btn-notapplicable' + practice.Id).disabled = true;
            // document.getElementById('auditor-dropdown' + practice.Id).disabled = true;

            var j = "#addAuditorCommentBtn" + practice.Id;

            $(j).removeClass('disabled');

            $scope.claims[practice.Id] = 1;
            var auditedbefore = false;
            var data = {};
            data['practice_id'] = practice.Id;
            data['status'] = 1;
            data['project_id'] = $scope.projectId;
            //data['auditor_comment'] = document.getElementById("text-auditor-comment" + practice.Id).value;

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

            $(".modal-backdrop fade in").remove();

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
                $scope.notApplicableClaims = [];
                $scope.hasPractices = [];
                for (var i = 0 ; i < 3 ; i++) {
                    $scope.completedPractises[i] = [];
                    $scope.pendingPractises[i] = [];
                    $scope.incompletedPractises[i] = [];
                    $scope.notApplicableClaims[i] = [];
                    $scope.hasPractices[i] = "no";
                }


                $scope.subAreaName = subareaName;
                $scope.practices = practises;
                console.log(practises);

                var index = 0;
                var index1 = 0;
                var index2 = 0;
                var index3 = 0;

                for (var i = 0; i < Object.keys($scope.practices).length; i++) {

                    if (typeof $scope.claims[$scope.practices[i].Id] === "undefined" || $scope.claims[$scope.practices[i].Id] === 2) {

                        for (var ind = 0; ind < $scope.CommentsArray.length ; ind++) {
                            //check if practise id matches 
                            if ($scope.CommentsArray[ind][0] == $scope.practices[i].Id) {
                                practises[i].TeamComment = $scope.CommentsArray[ind][1];
                                practises[i].AuditorComment = $scope.CommentsArray[ind][2];
                            }
                        }

                        $scope.incompletedPractises[$scope.practices[i].Level.Id - 1].push(practises[i]);
                        console.log("Unclaimed or rejected one! " + index1 + " " + $scope.incompletedPractises[$scope.practices[i].Level.Id - 1]);
                        index1++;
                    }
                    if ($scope.claims[$scope.practices[i].Id] == 1) {

                        for (var ind = 0; ind < $scope.CommentsArray.length ; ind++) {
                            //check if practise id matches 
                            if ($scope.CommentsArray[ind][0] == $scope.practices[i].Id) {
                                practises[i].TeamComment = $scope.CommentsArray[ind][1];
                                practises[i].AuditorComment = $scope.CommentsArray[ind][2];
                            }
                        }

                        $scope.completedPractises[$scope.practices[i].Level.Id - 1].push(practises[i]);
                        console.log($scope.completedPractises[0]);
                        console.log("Got one! " + index + " " + $scope.completedPractises[$scope.practices[i].Level.Id - 1]);
                        index++;
                    }
                    else if ($scope.claims[$scope.practices[i].Id] == 0) {

                        for (var ind = 0; ind < $scope.CommentsArray.length ; ind++) {
                            //check if practise id matches 
                            if ($scope.CommentsArray[ind][0] == $scope.practices[i].Id) {
                                practises[i].TeamComment = $scope.CommentsArray[ind][1];
                                practises[i].AuditorComment = $scope.CommentsArray[ind][2];
                            }
                        }

                        $scope.pendingPractises[$scope.practices[i].Level.Id - 1].push(practises[i]);
                        console.log("Pending one! " + index2 + " " + $scope.pendingPractises[$scope.practices[i].Level.Id - 1]);
                        $scope.currentSubareaPendings++;
                        index2++;





                    }
                    else if ($scope.claims[$scope.practices[i].Id] == 3) {

                        for (var ind = 0; ind < $scope.CommentsArray.length ; ind++) {
                            //check if practise id matches 
                            if ($scope.CommentsArray[ind][0] == $scope.practices[i].Id) {
                                practises[i].TeamComment = $scope.CommentsArray[ind][1];
                                practises[i].AuditorComment = $scope.CommentsArray[ind][2];
                            }
                        }

                        $scope.notApplicableClaims[$scope.practices[i].Level.Id - 1].push(practises[i]);
                        console.log("Not applicable one - but is completed! " + index3 + " " + $scope.notApplicableClaims[$scope.practices[i].Level.Id - 1]);
                        $scope.currentSubareaPendings++;
                        index3++;
                    }


                    $scope.toBeCompletedCount = index1 + index2;
                    $scope.completedCount = index + index3;
                    for (var c = 0; c < 3; c++) {
                        if ($scope.incompletedPractises[c].length + $scope.completedPractises[c].length + $scope.pendingPractises[c].length + $scope.notApplicableClaims[c].length > 0) {
                            $scope.hasPractices[c] = "yes";
                        }
                    }

                    console.log("NA - ");
                    console.log($scope.notApplicableClaims);

                }
            }
        }

        //function to save the claims
        $scope.createClaimRequest = function (practise) {

            console.log(practise);
            var l = "#incompleteCheckBox" + practise.Id;
            var j = "#addCommentBtn" + practise.Id;

            var data = {};
            console.log(l);
            if (!$(l).prop('checked')) {

                // document.getElementById('addCommentBtn' + practise.Id).disabled = true;
                $(j).addClass('btn btn-addcomment disabled');

                $scope.listOfAllClaims.splice($.inArray($scope.findClaimObject(practise.Id), $scope.listOfAllClaims), 1);
                console.log("not clicked - " + l);
                console.log($scope.listOfAllClaims);
            }
            else {
                $(l).prop('checked', true);
                // document.getElementById('addCommentBtn' + practise.Id).disabled = false;
                $(j).removeClass('disabled');
                data['Practice'] = practise;
                data['Project'] = $scope.projectInContext;
                data['TeamComment'] = document.getElementById("text-member-comment" + practise.Id).value;

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
                $(".modal-backdrop fade in").remove();
            } else {
                $scope.closeModalPopup();
            }
        }


        //to hide the modal popup
        $scope.closeModalPopup = function () {
            console.log($('.modal-backdrop'));
            jQuery.noConflict();

            var modalDialog = $('#myModal');
            var backdrop = $('.modal-backdrop');
            modalDialog.modal('hide');

            $('body').removeClass('modal-open');
            backdrop.remove();
            $route.reload();

            //to uncheck all the checkboxes when popup closed
            $('#myModal').on('hidden.bs.modal', function (e) {
                var checkboxes = new Array();
                checkboxes = document.getElementsByName('incompleteCheckboxes');
                for (var i = 0; i < checkboxes.length; i++) {
                    if (checkboxes[i].type == 'checkbox') {
                        checkboxes[i].checked = false
                    }
                }
            })

            $(".modal-backdrop fade in").remove();

        }

        //to hide the comment modal popup
        $scope.closeCommentPopupAndTakeText = function (incomplete) {
            var modalId = "#commentModal" + incomplete.Id;
            var commentText = document.getElementById("text-member-comment" + incomplete.Id).value;

            var practiceToAddCommentTo = $scope.findClaimObject(incomplete.Id);
            practiceToAddCommentTo.TeamComment = commentText;

            console.log($('.modal-backdrop'));
            jQuery.noConflict();
            var modalDialog = $(modalId);
            var backdrop = $('.modal-backdrop');
            modalDialog.modal('hide');

            $('body').removeClass('modal-open');
            backdrop.remove();
            $(".modal-backdrop fade in").remove();
        }

        //to hide the complete comment modal popup
        $scope.closeCompletedCommentPopupAndTakeText = function (complete) {
            var modalId = "#commentCompletedModal" + complete.Id;
            var commentText = document.getElementById("text-auditor-complete-comment" + complete.Id).value;


            var practiceToAddCommentTo = $scope.findAuditedClaimObject(complete.Id);
            practiceToAddCommentTo.auditor_comment = commentText;

            console.log($('.modal-backdrop'));
            jQuery.noConflict();
            var modalDialog = $(modalId);
            var backdrop = $('.modal-backdrop');
            modalDialog.modal('hide');

            $('body').removeClass('modal-open');
            backdrop.remove();
            $(".modal-backdrop fade in").remove();
        }

        //to hide the completed comment modal popup
        $scope.closeCompletedCommentPopup = function (complete) {
            var modalId = "#commentCompletedModal" + complete.Id;

            console.log($('.modal-backdrop'));
            jQuery.noConflict();
            var modalDialog = $(modalId);
            var backdrop = $('.modal-backdrop');
            modalDialog.modal('hide');

            $('body').removeClass('modal-open');
            backdrop.remove();
            $(".modal-backdrop fade in").remove();
        }

        //to hide the auditor comment modal popup
        $scope.closeAuditorCommentPopupAndTakeText = function (project) {
            var modalId = "#auditorCommentModal" + project.Id;
            var commentText = document.getElementById("text-auditor-comment" + project.Id).value;

            var practiceToAddCommentTo = $scope.findAuditedClaimObject(project.Id);
            practiceToAddCommentTo.auditor_comment = commentText;

            console.log($('.modal-backdrop'));
            jQuery.noConflict();
            var modalDialog = $(modalId);
            var backdrop = $('.modal-backdrop');
            modalDialog.modal('hide');

            $('body').removeClass('modal-open');
            backdrop.remove();
            $(".modal-backdrop fade in").remove();
        }

        $scope.closeNotApplicableCommentPopupAndTakeText = function (project) {
            var modalId = "#notapplicablemodal" + project.Id;
            var commentText = document.getElementById("text-auditor-notapplicable-comment" + project.Id).value;

            var practiceToAddCommentTo = $scope.findAuditedClaimObject(project.Id);
            practiceToAddCommentTo.auditor_comment = commentText;

            console.log($('.modal-backdrop'));
            jQuery.noConflict();
            var modalDialog = $(modalId);
            var backdrop = $('.modal-backdrop');
            modalDialog.modal('hide');

            $('body').removeClass('modal-open');
            backdrop.remove();
            $(".modal-backdrop fade in").remove();
        }

        $scope.closeNotApplicableCommentPopup = function (project) {
            var modalId = "#notapplicablemodal" + project.Id;
          

            console.log($('.modal-backdrop'));
            jQuery.noConflict();
            var modalDialog = $(modalId);
            var backdrop = $('.modal-backdrop');
            modalDialog.modal('hide');

            $('body').removeClass('modal-open');
            backdrop.remove();
            $(".modal-backdrop fade in").remove();
        }


        $scope.preventClose = function (event) { event.stopPropagation(); };


        $scope.findClaimObject = function (claimPracticeId) {

            for (var i = 0, len = $scope.listOfAllClaims.length; i < len; i++) {

                if ($scope.listOfAllClaims[i].Practice.Id === claimPracticeId)
                    return $scope.listOfAllClaims[i]; // Return as soon as the object is found

            }

            return null; // The object was not found

        }

        $scope.findAuditedClaimObject = function (claimPracticeId) {

            for (var i = 0, len = $scope.auditedClaims.length; i < len; i++) {

                if ($scope.auditedClaims[i].practice_id === claimPracticeId)
                    return $scope.auditedClaims[i]; // Return as soon as the object is found

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
            }
        }

        activate();

        function activate() {
            common.activateController([], controllerId).then(function () {// log('Activated Project View'); 
            });

            $http({ method: 'GET', url: 'api/model' }).
               success(function (data, status, headers, config) {
                   console.log(data);
                   for (var i = 0; i < data.length; i++) {
                       var name = data[i].Name;
                       data[i].fname = name.split(" ")[0];
                       data[i].lname = name.split(" ")[1];
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

                               $scope.getCommentsMadeForClaim = function () {

                                   $http({ method: 'GET', url: 'api/claims/' + data[i].Id }).
                                        success(function (claimdata, status, headers, config) {
                                            var holdCommentAndId = [];
                                            holdCommentAndId[0] = claimdata.Practice.Id;
                                            holdCommentAndId[1] = claimdata.TeamComment;
                                            holdCommentAndId[2] = claimdata.AuditorComment;

                                            $scope.CommentsArray.push(holdCommentAndId);
                                        })

                               }

                               $scope.getCommentsMadeForClaim();

                           };
                           calculate();
                           isAMember($scope.projectAssignment).then(function () {
                               console.log('Success: isTeamMember: ' + $scope.isMember + ' and isAuditor: ' + $scope.isAuditor);

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

                        if (!($scope.areas[i].SubAreas[j].Practices[k].Id in $scope.claims)) { //if practise is not in claims
                            if ($scope.areas[i].SubAreas[j].Practices[k].Level.Id <= level) {

                                level = $scope.areas[i].SubAreas[j].Practices[k].Level.Id - 1;
                            }
                        }
                        else {                                                                   //if practise is in claims
                            if (!($scope.areas[i].SubAreas[j].Practices[k].Obsolete)) {
                                if ($scope.claims[$scope.areas[i].SubAreas[j].Practices[k].Id] === 3) {
                                    subcertificatesCount++;
                                }
                                else if ($scope.claims[$scope.areas[i].SubAreas[j].Practices[k].Id] != 1) {  // if practise is not accepted

                                    if ($scope.claims[$scope.areas[i].SubAreas[j].Practices[k].Id] === 0) { //if practise not claimed
                                        subpendingCount++;
                                        console.log($scope.areas[i].SubAreas[j].Practices[k].Id + " is pending")
                                    }
                                    if ($scope.areas[i].SubAreas[j].Practices[k].Level.Id <= level) {   //if sub areas practise level is less than level of area

                                        level = $scope.areas[i].SubAreas[j].Practices[k].Level.Id - 1;  //then level is sub areas practise level
                                    }
                                }

                                else {
                                    subcertificatesCount++;     //if accepted then certified practise count increase
                                }
                            }
                        }

                        if (!($scope.areas[i].SubAreas[j].Practices[k].Obsolete)) {     //calculate amount of practises 
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
                $scope.areas[i].hasPendings = "no"
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

                document.getElementById($scope.areas[i].Name).className = "content-box-type-three " + style + " clearfix";

            }
        }

        function isAMember(projectAssignment) {
            var promise = $http({ method: 'GET', url: 'security/username' }).
                       success(function (data, status, headers, config) {
                           console.log(data);
                           $scope.userName = data.split("\\")[1].toString().toLowerCase();

                           $http({ method: 'GET', url: 'api/project/' + $scope.projectId }).
                            success(function (projdata, status, headers, config) {

                                if (projdata.TeamMembers != null) {

                                    var membersListFromApi = projdata.TeamMembers;

                                    var membersArray = membersListFromApi.split(",");
                                    var member_rep = projdata.ProjectMemberRep;

                                    if ($scope.userName == projdata.ProjectMemberRep) {
                                        $scope.isMember = "yes";
                                    } else {
                                        for (var i = 0 ; i < membersArray.length ; i++) {
                                            if ($scope.userName == membersArray[i]) {
                                                $scope.isMember = "yes";
                                            }
                                        }
                                    }

                                    $http({ method: 'GET', url: 'api/userrole/' + $scope.userName }).
 success(function (data, status, headers, config) {
     if ((data == 1 || data == 3) && $scope.isMember == "no") {    //enum returns a number as the role (1 : auditoe, 0:admin
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

                                } else {
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
                                     if ((data == 1 || data == 3) && $scope.isMember == "no") {    //enum returns a number as the role (1 : auditoe, 0:admin
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
                                }
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
