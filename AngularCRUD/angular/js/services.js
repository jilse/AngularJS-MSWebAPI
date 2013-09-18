'use strict';
jweb.app.factory('ApiFactory', function($resource){
	var _query = function(modelName, success){
		$resource('/api/' + modelName).query().$promise.then(function(data){
			if(angular.isFunction(success))
				success(data)
		})
	}
	var _get = function(modelName, id, success){
		$resource('/api/'+ modelName +'/:id', {id: '@id'}).get({id: id}).$promise.then(function(data){
			if(angular.isFunction(success))
				success(data)
		})
	}
	var _delete = function(modelName, id, success){
		$resource('/api/'+ modelName +'/:id', {id: '@id'}).delete({id: id}).$promise.then(function(){
			if(angular.isFunction(success))
				success()
		})
	}
	var _save = function(modelName, data, success) {
		$resource('/api/'+ modelName ).save(data).$promise.then(function(d) {
			if (angular.isFunction(success))
				success(d);
		});
	}
	return {
		query: _query,
		get: _get,
		save: _save,
		delete: _delete
	}
});
