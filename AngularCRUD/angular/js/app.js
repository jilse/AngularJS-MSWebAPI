'use strict';


// Declare app level module which depends on filters, and services
var jweb = {};

jweb.app = angular.module('jweb', ['ngRoute', 'ngResource']);

jweb.app.config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/:apiName', {templateUrl: function($routeParams){
		return 'partials/' + $routeParams.apiName + '.html';
	}, controller: 'CRUDCtrl'});

    $routeProvider.otherwise({redirectTo: '/contacts'});
  }]);
