(function () {
    'use strict';
    var controllerId = 'allprojects';
    angular.module('app').controller(controllerId, ['$scope', 'common', '$routeParams', '$http', '$route', allprojects]);

    function allprojects($scope, common, $routeParams, $http, $route) {


        common.activateController([], controllerId);

        $scope.allProjectsFrom99XServiceAPI = [];   //coming from the 99X service
        $scope.allProjectsFromDatabase = [];        //coming from spec database

        //function to getAllProjectsFrom99XTService 
        $http.get("http://99xtechnology.lk/services/api/Projects", { withCredentials: true }).
                    success(function (data) {

                        console.log("Success");
                        $scope.allProjectsFrom99XServiceAPI = data;
                        console.log($scope.allProjectsFrom99XServiceAPI);
                    }).
                    error(function (data, error) {
                        console.log(error);
                        console.log("error");
                    });

        //function to enable / disable project
        $scope.enableDisableProject = function (project) {
            var btnId = "enableDisableBtn" + project.Id;

            console.log(btnId);

            if (project.Enabled === true)
                document.getElementById(btnId).innerHTML = "Enable";    // cuz at this point the button has still not changed the enabled state. 
            else
                document.getElementById(btnId).innerHTML = "Disable";

            $http.put('api/project/' + project.projetId, JSON.stringify(project)).
                   success(function (data, status, headers) {
                   });
            $route.reload();

        }



        //funtion to get all project details from database
        $scope.getAllProjectsFromDatabase = function () {
            $http({ method: 'GET', url: 'api/project/' }).
                          success(function (data, status, headers, config) {
                              console.log(data);
                              for (var i = 0; i < data.length; i++) {
                                  $scope.allProjectsFromDatabase[i] = data[i];

                                  var btnId = "enableDisableBtn" + data[i].Id;


                                  if ($scope.allProjectsFromDatabase[i].Enabled === true)
                                      $scope.allProjectsFromDatabase[i].enableDisableStatus = "Disable";
                                  else
                                      $scope.allProjectsFromDatabase[i].enableDisableStatus = "Enable";

                              };

                              console.log('All Projects from db : ', $scope.allProjectsFromDatabase);
                          }).
                          error(function (data, status, headers, config) {
                              console.log(data);
                              // called asynchronously if an error occurs
                              // or server returns response with an error status.
                          });

        }

        $scope.getAllProjectsFromDatabase();

        //function to import project
        $scope.importProjectToDb = function (project) {
            $http.post('api/project', project).
                     success(function (data, status, headers) {
                         console.log("Status: ", data);
                         if (data === "true")
                             console.log("Project is existing");
                         else {
                             console.log("Project added");
                         }
                     });

            console.log("Importing project happening ...");
            $route.reload();

        }
    }



})();