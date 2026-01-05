README Document

A service class handles all the business logic of the application being handled or implemented;
while a controller handles requests incoming and outgoing of the application to the external world.
The controller calls the logics of the application from the Services using an Interface.

By using an interface, unneccsary details are being hidden from the controllers, it just calls the methods
that has already been implemented in the Services.