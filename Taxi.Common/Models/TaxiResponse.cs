using System.Collections.Generic;
using System.Linq;

namespace Taxi.Common.Models
{
    public class TaxiResponse
    {
        public int Id { get; set; }

        public string Plaque { get; set; }

        public List<TripResponse> Trips { get; set; }

        public UserResponse User { get; set; }

        //Promedio de todas las calificaciones individales
        public float Qualification => Trips == null ? 0 : Trips.Average(t => t.Qualification);

        //Total de numeros de viajes. 
        public int NumberOfTrips => Trips == null ? 0 : Trips.Count;
    }
}
