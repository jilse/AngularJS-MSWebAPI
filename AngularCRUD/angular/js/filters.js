'use strict';
jweb.app.filter('onproperty', function() {
	return function(input, query) {
		if (!input || input.length === 0) return;
		if (!query) return input;
		query.Property = query.Property;
		return jweb.jsonFilter(input, query);
	}
});
//usage<span ng-repeat="o in mybojects | onproperty:[{Property: 'propertyname', Value: 'yes'}, {Property: 'anotherBool', Value: true}]">
