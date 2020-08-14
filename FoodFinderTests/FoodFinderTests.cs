using FoodFinder.Services;
using FoodFinderTests.ServiceStubs;
using NUnit.Framework;
using System.Linq;

namespace FoodFinderTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EnsureNoZeroLatLongRecordsLoaded()
        {
            var stubRepo = new StubFoodTruckRepository();
            var stubDataService = new StubTruckDatasetService();

            stubDataService.Records.Add(new TruckDataRecord { objectid = 1, applicant = "invalid", latitude = 0, longitude = 0, status = "APPROVED" });

            var foodFinderService = new FoodFinderService(stubRepo, stubDataService);
            foodFinderService.Initialize();

            Assert.Zero(stubRepo.SavedTruckRecords.Count());
        }

        [Test]
        public void EnsureNoUnApprovedRecordsLoaded()
        {
            var stubRepo = new StubFoodTruckRepository();
            var stubDataService = new StubTruckDatasetService();

            stubDataService.Records.Add(new TruckDataRecord { objectid = 1, applicant = "invalid", latitude = 89, longitude = 44, status = "DENIED" });


            var foodFinderService = new FoodFinderService(stubRepo, stubDataService);
            foodFinderService.Initialize();

            Assert.Zero(stubRepo.SavedTruckRecords.Count());
        }

        [Test]
        public void EnsureApprovedWithLocationRecordsLoaded()
        {
            var stubRepo = new StubFoodTruckRepository();
            var stubDataService = new StubTruckDatasetService();

            stubDataService.Records.Add(new TruckDataRecord { objectid = 2, applicant = "valid", latitude = 89, longitude = 44, status = "APPROVED" });


            var foodFinderService = new FoodFinderService(stubRepo, stubDataService);
            foodFinderService.Initialize();

            Assert.IsTrue(stubRepo.SavedTruckRecords.Any());
        }
    }
}