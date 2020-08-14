using FoodFinder.Services;
using System.Collections.Generic;

namespace FoodFinderTests.ServiceStubs
{
    public class StubTruckDatasetService : ITruckDatasetService
    {
        public List<TruckDataRecord> Records { get; set; }

        public StubTruckDatasetService()
        {
            Records = new List<TruckDataRecord>();
        }
        public IEnumerable<TruckDataRecord> GetRemoteData()
        {
            return Records;
        }
    }
}
