celebritiesApp.service('CelebrityService', function ($http, $rootScope) {
  var service = {
    getAllCelebrities: function () {
      var promise = $http.get($rootScope.baseUrl + '/api/Celebrities/Celebrity').then(function (response) {
        return response.data.model;
      }).catch(function (e) {
        console.log("got an error in initial processing", e);
        alert(e.statusText);
      });
      return promise;
    },
    addCelebrity: function (celebrity) {
      var body = JSON.stringify(celebrity);
      var promise = $http.post($rootScope.baseUrl + '/api/Celebrities/Celebrity', body).then(function (response) {
        return response.data.model;
      }).catch(function (e) {
        console.log("got an error in initial processing", e);
        alert(e.statusText);
      });
      return promise;
    },
    editCelebrity: function (celebrity) {
      var body = JSON.stringify(celebrity);
      var promise = $http.put($rootScope.baseUrl + '/api/Celebrities/Celebrity', body).then(function (response) {
        return response.data;
      }).catch(function (e) {
        console.log("got an error in initial processing", e);
        alert(e.statusText);
      });
      return promise;
    },
    deleteCelebrity: function (id) {
      var promise = $http.delete($rootScope.baseUrl + '/api/Celebrities/Celebrity/' + id).then(function (response) {
        return response.data;
      }).catch(function (e) {
        console.log("got an error in initial processing", e);
        alert(e.statusText);
      });
      return promise;
    }
  };
  return service;
});