using FoodFinder.Models;
using System.Collections.Generic;

namespace FoodFinder.Services
{
    public interface IFoodFinderService
    {
        IEnumerable<FoodLocation> FindNearbyLocations(Coordinate fromPoint);
        void Initialize();
    }
}