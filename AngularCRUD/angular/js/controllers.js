'use strict';

jweb.app.controller('CRUDCtrl', function($scope, $routeParams, ApiFactory) {
	$scope.currentObject = {};
	setList();
	function setList()
	{
		ApiFactory.query($routeParams.apiName, function(o){
			$scope.list = o;
		});
	}
	$scope.setCurrent = function(id){
		console.log('calling get: ' + $routeParams.apiName);
		ApiFactory.get($routeParams.apiName, id, function(o){
			$scope.currentObject = o;
		});
	}
	$scope.delete = function(id){
		ApiFactory.delete($routeParams.apiName, id, function(){
			$scope.currentObject = {};
			setList();
		})
	}
	$scope.save = function(){
		console.log('calling save:  ' + $routeParams.apiName);
		console.dir($scope.currentObject);
		ApiFactory.save($routeParams.apiName, $scope.currentObject, function (c) {
			setList();
			$scope.currentObject = {};
		})
	}
	$scope.newApiObject = function(){
		$scope.currentObject = {};
	};
});

jweb.app.controller('ContactCtrl', function ($scope, $routeParams, ApiFactory) {
	console.log('loading ctrl');
	ApiFactory.query('contactgroups', function (data) {
		$scope.contactGroups = data;
	});
});
