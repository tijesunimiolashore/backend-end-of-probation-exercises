Assessment 3 Part 1 Point 1b

A service class handles all the business logic of the application being handled or implemented; while a controller handles requests incoming and outgoing of the application to the external world (database, inmemory, etc.).

The controller calls the business logics of the application being implemented in the Services using an Interface. The inetrface serves as the middleman between the Services and Controllers.

By using a Service Class, unneccsary details are being hidden from the Controllers, it calls the methods already implemented in the Service Class.
