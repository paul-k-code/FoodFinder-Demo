using System.Collections.Generic;

namespace FoodFinder.Services
{
    public interface ITruckDatasetService
    {
        IEnumerable<TruckDataRecord> GetRemoteData();
    }
}