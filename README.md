Angular-MSWebAPI
================

is a very basic c# web API plugged into an AngularJS single page application Create/Read/Update/Delete in VS2012

I started with an empty MVC4 web API project and the AngularJS seed project. The data is persisted using Entity Framework. The key files to notice: /models, /controllers, /angular/partials. That's all you need to add additional models persisted in the DB. /angular/js/controllers.js shows how $scope.currentObject and $scope.list are set based on the angular route. 

I'm not suggesting this is the best way to implement AngularJS and WebAPI, but as a stripped down yet functional CRUD site for someone that has gone through the AngularJS tutorial and wants to take the next step.

I'm running Visual Studio 2012 version 11.0.51106.01 Update 1. Hopefully, you should just have to clone the project, run, and go to /angular/index.html.