using System.Threading.Tasks;

namespace Taxi.Common.Services
{
    public interface IGeolocatorService
    {
        double Latitude { get; set; }

        double Longitude { get; set; }

        Task GetLocationAsync();//Este método nos va a cargar la longitud y latitud en estemos.
    }
}
