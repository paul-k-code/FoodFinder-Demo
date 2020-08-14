CREATE TABLE [dbo].[FoodTrucks]
(
	[Id] INT NOT NULL PRIMARY KEY,
	CompanyName varchar (200),
	FacilityType varchar(50),
	[Address] varchar(250),
	[Location] [sys].[geography],
	FoodItems varchar(500) 
)

GO
