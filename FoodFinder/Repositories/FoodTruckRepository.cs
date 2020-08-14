using Dapper;
using FoodFinder.Models;
using FoodFinder.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FoodFinder.Repositories
{
    public class FoodTruckRepository : IFoodTruckRepository
    {
        private readonly string queryNearbyLocationsSql = @"DECLARE @searchFrom geography = GEOGRAPHY::Point(@latitude, @longitude, 4326);
            SELECT Top 5 ft.CompanyName, ft.FacilityType, ft.Address, ft.FoodItems, @searchFrom.STDistance(ft.Location)/1609.344 as MilesAway
            FROM dbo.FoodTrucks ft
            ORDER BY @searchFrom.STDistance(ft.Location)";

        private readonly IConfiguration _config;

        public FoodTruckRepository(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<FoodLocation> QueryNearbyLocations(Coordinate fromPoint)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("FoodTruckDatabase")))
            {
                connection.Open();
                return connection.Query<FoodLocation>(queryNearbyLocationsSql, new { latitude = fromPoint.Latitude, longitude = fromPoint.Longitude });
            }
        }

        /// <summary>
        /// This method will update or add records
        /// </summary>
        /// <param name="records"></param>
        public void InitializeDatabase(IEnumerable<TruckDataRecord> records)
        {

            var sql = @"MERGE INTO dbo.FoodTrucks as ft using (Select @objectid as Id) As newval(Id) on ft.Id = newval.Id
                WHEN MATCHED THEN
                    Update Set CompanyName = @applicant, FacilityType = @facilitytype, Address = @address, FoodItems = @fooditems, Location = geography::Point(@latitude, @longitude, 4326)
                WHEN NOT MATCHED THEN 
                    insert (Id, CompanyName, FacilityType, Address, FoodItems, Location) values (@objectid, @applicant, @facilitytype, @address, @fooditems, geography::Point(@latitude, @longitude, 4326));";
            using (var connection = new SqlConnection(_config.GetConnectionString("FoodTruckDatabase")))
            {

                var affectedRows = connection.Execute(sql, records);
                if(affectedRows != records.Count())
                {
                    throw new Exception("Error loading records");
                }
            }
        }
    }
}
