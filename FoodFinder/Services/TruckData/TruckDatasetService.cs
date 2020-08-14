using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Collections.Generic;

namespace FoodFinder.Services
{
    public class TruckDatasetService : ITruckDatasetService
    {
        private const string API_KEY_HEADER = "X-App-Token";

        private string ApiKey { get; set; }
        private string ApiBasePath { get; set; }
        private string ApiEndpoint { get; set; }
        public TruckDatasetService(IConfiguration config)
        {
            ApiKey = config["DataSF_API_KEY"];
            ApiBasePath = config["DataSF_Base_Api"];
            ApiEndpoint = config["DataSF_Path"];
        }
        public IEnumerable<TruckDataRecord> GetRemoteData()
        {
            var client = new RestClient(ApiBasePath);
            client.AddDefaultHeader(API_KEY_HEADER, ApiKey);
            client.UseNewtonsoftJson();

            var request = new RestRequest(ApiEndpoint, DataFormat.Json);

            var response = client.Get<TruckDataRecord[]>(request);

            return response.Data;
        }
    }
}
