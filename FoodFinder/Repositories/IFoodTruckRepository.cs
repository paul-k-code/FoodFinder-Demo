using FoodFinder.Models;
using FoodFinder.Services;
using System.Collections.Generic;

namespace FoodFinder.Repositories
{
    public interface IFoodTruckRepository
    {
        IEnumerable<FoodLocation> QueryNearbyLocations(Coordinate fromPoint);

        void InitializeDatabase(IEnumerable<TruckDataRecord> records);
    }
}