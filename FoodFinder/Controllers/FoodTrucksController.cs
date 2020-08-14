using FoodFinder.Models;
using FoodFinder.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel;

namespace FoodFinder.Controllers
{
    [ApiController]
    [Route("api/FoodTrucks")]
    public class FoodTrucksController : ControllerBase
    {
        private readonly ILogger<FoodTrucksController> _logger;
        private readonly IFoodFinderService _foodFinderService;


        public FoodTrucksController(ILogger<FoodTrucksController> logger, IFoodFinderService foodFinderService)
        {
            _logger = logger;
            _foodFinderService = foodFinderService;
        }

        [HttpPost("Search"), Description("Find the nearest food truck")]
        public IEnumerable<FoodLocation> Search([FromBody] FoodTruckSearchRequest searchRequest)
        {
            return _foodFinderService.FindNearbyLocations(new Coordinate(searchRequest.Latitude, searchRequest.Longitude));
        }

        [HttpGet("Load"), Description("Loads the Food Finder Database from a service")]
        public void LoadData()
        {
            _foodFinderService.Initialize();
        }

    }
}
