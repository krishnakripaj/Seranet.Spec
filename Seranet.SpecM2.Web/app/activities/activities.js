(function () {
    'use strict';
    var controllerId = 'activities';
    angular.module('app').controller(controllerId, [activities]);

    function activities() {
        this.fname = "Hashini";
    }

})();