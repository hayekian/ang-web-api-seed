/// <reference path="HLib.js" />



var AngApp = angular.module('App', ['ngRoute', 'ngSanitize']);


AngApp.factory('$exceptionHandler', function () {
    return function errorCatcherHandler(exception, cause) {
        var obj = {};
        obj.Exception = exception;
        obj.Cause = cause;
        obj.StackTrace = exception.stack;
        obj.URL = window.location.href;
        obj.App = APP;
        console.log(JSON.stringify(obj));
    };
});


AngApp.run(['$rootScope', '$http', '$location', function ($rootScope, $http, $location) {
    ROOT = $rootScope;
    ROOT.Log = "";
  
}]);



AngApp.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/home',
        {
            templateUrl: "Main.aspx", controller: 'HomeCtrl'
        }).when('/app/:id',
        {
            templateUrl: "ViewApplication.aspx", controller: 'CtrlApp'
        })
       
       .otherwise({
           redirectTo: '/home'
       });

}]);



AngApp.controller('MainCtrl', ['$scope', '$http',
  function ($scope, $http) {
      $scope.TEST = "the test";

      var obj = {};

      obj.name = 'Jorge';

      var obj2 = angular.copy(obj);
      obj2.name = 'mike';
      $scope.Original = JSON.stringify(obj);
      $scope.NewObj = JSON.stringify(obj2);
      $scope.Changes = JSON.stringify(ObjDifferences(obj, obj2));
      var toPost = { Name: 'jorge', Age: 39 };
      _POST2($http, "WebApi", toPost, function (data) {

          alert(JSON.stringify(data));

      });




  }]);
   




// .controller('FormsCtrl', ['$scope',

//      function ($scope) {


//          $scope.$on('$viewContentLoaded', function (event) {

//              $("#example").dataTable({
//                  "bSort": true,
//                  "iDisplayLength": 100,
//                  "aLengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
//                  "bProcessing": true,
//                  "sAjaxSource": 'Commands.aspx?Forms=1'

//              });
//          })
//      }

// ]

//  ).controller('CtrlApp',

//   ['$scope', '$routeParams', '$http', '$rootScope', '$location', '$window',

//          CtrlApp]


//  )
//.controller('CtrlAppsList',

//   ['$scope', '$routeParams', '$location',

//          CtrlAppsList]


//  ).controller('CtrlAdminAllApps', ['$scope',

//      function ($scope) {


//          $scope.$on('$viewContentLoaded', function (event) {

//              $("#example").dataTable({
//                  "bSort": true,
//                  "iDisplayLength": 100,
//                  "aLengthMenu": [[25, 50, 100, -1], [25, 50, 100, "All"]],
//                  "bProcessing": true,
//                  "sAjaxSource": 'Commands.aspx?AllApps=1',
//                  "aaSorting": [[3, 'desc']],
//                  "aoColumns": [

//{ "mData": "NamedInsured" },
//{ "mData": "userName" },
//{ "mData": "EffectiveDate" },
//{ "mData": "DateModified" },
//{ "mData": "StatusMessage" },
//{ "mData": "PolicyNumber" },
//{ "mData": "Premium" }
//                  ]

//              }
//              );
//          }
//          );
//      }


//  ])




function _POST2(http, _url, _data, next) {
    http({ method: 'POST', url: _url, data: _data, headers: { 'Content-Type': 'application/json' } }).
  success(function (data, status, headers, config) {
      next(data);
  }).
  error(function (data, status, headers, config) {

      throw new Error('bad post');
  });

}

