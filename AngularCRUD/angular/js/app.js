'use strict';


// Declare app level module which depends on filters, and services
var jweb = {};

jweb.jsonFilter = function (input, options, op) {
	if (input == null || options == null) return;
	var result = [];

	angular.forEach(input, function(row) {
		if (row[options.Property] === undefined && !options instanceof Array) return;

		var checkRow = function(opt){
			if(!row[opt.Property] && !opt.Value) //looking for null valued rows
				return row;

			if(row[opt.Property] && opt.Value === '!null') //looking for not null valued rows
				return row;

			if ((row[opt.Property] && opt.Value )&&((row[opt.Property].toString()).toLowerCase() === (opt.Value.toString()).toLowerCase())){
				return row;
			}
		}

		var add;
		if (options instanceof Array){ //does an OR on the list of conditions. could add to it to optionally have OR/AND
			for(var i = 0; i < options.length; i++){
				add = checkRow(options[i]);
				if(add)
					break;
			}
		}else{
			add = checkRow(options);
		}

		if(add){
			result.push(row);
			if(op) op(row)
		}
	});
	return result;
};


jweb.app = angular.module('jweb', ['ngRoute', 'ngResource']);

jweb.app.config(['$routeProvider', function($routeProvider) {
	$routeProvider.when('/:apiName', {templateUrl: function($routeParams){
		return 'partials/' + $routeParams.apiName + '.html';
	}, controller: 'CRUDCtrl'});

    $routeProvider.otherwise({redirectTo: '/contacts'});
  }]);
