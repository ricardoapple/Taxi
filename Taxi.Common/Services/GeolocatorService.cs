using System;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace Taxi.Common.Services
{
    public class GeolocatorService : IGeolocatorService
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public async Task GetLocationAsync()
        {
            try
            {
                var locator = CrossGeolocator.Current;//Obtenemos la localización del teléfono
                locator.DesiredAccuracy = 50;//Es una precisión de 50 metros.
                var location = await locator.GetPositionAsync();
                Latitude = location.Latitude;
                Longitude = location.Longitude;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
