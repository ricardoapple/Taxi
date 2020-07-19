using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi.Web.Models
{
    public class TripDetail
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }
        public DateTime DateLocal => Date.ToLocalTime();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Trip Trip { get; set; } //Un Detalle de viaje tiene un Viaje
        public ICollection<TripDetail> TripDetails { get; set; }//Una collection tiene muchos detalles de viajes

    }
}
