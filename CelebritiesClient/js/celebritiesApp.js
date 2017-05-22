var celebritiesApp = angular.module('celebritiesApp', []);

celebritiesApp.run(function ($rootScope) {
  $rootScope.baseUrl = 'http://localhost:58565';
});