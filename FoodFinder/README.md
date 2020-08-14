# San Fransisco Food Truck Finder

This API provides a Swagger interface to easily find the 5 closest Food Trucks

https://localhost:44344/swagger

/api/FoodTrucks/Search

This API accepts Longitude and Latitude and will return the 5 closest Food Trucks

/api/FoodTrucks/Load

This API will download the current Food Truck data from https://data.sfgov.org and populate the database


## Dependencies

This solution requires a local SQL Server instance and a connection string to FoodTruckDatabase 