using FoodFinder.Models;
using FoodFinder.Repositories;
using FoodFinder.Services;
using System;
using System.Collections.Generic;

namespace FoodFinderTests.ServiceStubs
{
    public class StubFoodTruckRepository : IFoodTruckRepository
    {
        public List<TruckDataRecord> SavedTruckRecords { get; set; }
        public void InitializeDatabase(IEnumerable<TruckDataRecord> records)
        {
            SavedTruckRecords = new List<TruckDataRecord>();
            SavedTruckRecords.AddRange(records);
        }

        public IEnumerable<FoodLocation> QueryNearbyLocations(Coordinate fromPoint)
        {
            throw new NotImplementedException();
        }
    }
}
