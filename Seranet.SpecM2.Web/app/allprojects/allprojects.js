(function () {
    'use strict';
    var controllerId = 'allprojects';
    angular.module('app').controller(controllerId, ['$scope', 'common', '$routeParams', '$http', allprojects]);

    function allprojects($scope, common, $routeParams, $http) {

        $scope.allProjects = [];

        //function to getAllProjectsFrom99XTService 
        $http.get("http://99xtechnology.lk/services/api/Projects", { withCredentials: true }).
                    success(function (data) {
                       
                        console.log("Success");
                        $scope.allProjects = data;
                        console.log($scope.allProjects);
                    }).
                    error(function (data, error) {
                        console.log(error);
                        console.log("error");
                    });
        

        //function to import project
        $scope.importProjectToDb = function (project) { 

            console.log(project)
            console.log(JSON.stringify(project));

            $http.post('api/project', JSON.stringify(project)).
                     success(function (data, status, headers) {
                         
                     });

            console.log("I am called");

        }

        //$scope.importProjectToDb = function (project) {
        //    $http({
        //        url: 'api/project',
        //        method: "POST",
        //        data: { 'message' : project }
        //    })
        //   .then(function(response) {
        //       console.log("Project added");
        //   }, 
        //       function(response) { // optional
        //           // failed
        //       }
        //   );


    }



})();