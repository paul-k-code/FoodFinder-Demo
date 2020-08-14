using FoodFinder.Models;
using FoodFinder.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder.Services
{
    public class FoodFinderService : IFoodFinderService
    {
        private readonly IFoodTruckRepository _foodTruckRepository;
        private readonly ITruckDatasetService _truckDataService;

        public FoodFinderService(IFoodTruckRepository foodTruckRepository, ITruckDatasetService truckDatasetService)
        {
            _foodTruckRepository = foodTruckRepository;
            _truckDataService = truckDatasetService;
        }

        //Test Coordinates 37.7622106,-122.4404893
        public IEnumerable<FoodLocation> FindNearbyLocations(Coordinate fromPoint)
        {
            return _foodTruckRepository.QueryNearbyLocations(fromPoint);
        }

        public void Initialize()
        {
            var truckData = _truckDataService.GetRemoteData();
            //Only load data for approved vendors that have a location
            var approvedTrucks = truckData.Where(truck => truck.status == "APPROVED" && !(truck.longitude == 0 && truck.latitude == 0));
            _foodTruckRepository.InitializeDatabase(approvedTrucks);
        }
    }
}
