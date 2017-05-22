celebritiesApp.service('CountriesService', function ($http, $rootScope) {
  var service = {
    getAllCountries: function () {
      var promise = $http.get('https://restcountries.eu/rest/v2/all?fields=name').then(function (response) {
        return response.data;
      });
      return promise;
    }
  };
  return service;
});