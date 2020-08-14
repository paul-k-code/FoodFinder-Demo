using System;
using System.ComponentModel.DataAnnotations;

namespace FoodFinder.Controllers
{
    public class FoodTruckSearchRequest
    {
        private double longitude;
        private double latitude;

        [Required, Range(-90, 90)]
        public double Latitude
        {
            get => latitude;
            set
            {
                if (value > 90 || value < -90) throw new ValidationException("Latitude must be between -90 and 90");

                latitude = value;
            }
        }
        [Required, Range(-180, 180)]
        public double Longitude
        {
            get => longitude;
            set
            {
                if (value > 180 || value < -180) throw new ValidationException("Longitude must be between -180 and 180");

                longitude = value;
            }
        }
    }
}
