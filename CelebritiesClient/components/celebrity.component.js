celebritiesApp.component('celebrity', {
  templateUrl: './views/celebrity.html',
  controller: function ($scope, CelebrityService, CountriesService) {

    $scope.newCelebrity = {};
    $scope.isCreateFormVisible = false;

    $scope.deleteCelebrity = function (celebId) {
      CelebrityService.deleteCelebrity(celebId).then(CelebrityService.getAllCelebrities).then(function (data) {
        $scope.celebrities = data;
      });
    };

    $scope.editCelebrity = function (celebrity) {
      CelebrityService.editCelebrity(celebrity).then(CelebrityService.getAllCelebrities).then(function (data) {
        $scope.celebrities = data;
      });
    };

    $scope.addCelebrity = function () {
      CelebrityService.addCelebrity($scope.newCelebrity).then(CelebrityService.getAllCelebrities).then(function (data) {
        $scope.celebrities = data;
        $scope.newCelebrity = {};
      });
    };

    CountriesService.getAllCountries().then(function (countries) {
      $scope.countries = countries;
    });

    CelebrityService.getAllCelebrities().then(function(celebrities) {
      $scope.celebrities = celebrities;
    });
  },
  binding: {
    celebrities: '<',
    countries: '<',
    isCreateFormVisible: '=',
    newCelebrity: '='
  }
});