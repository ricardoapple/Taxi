using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi.Web.Models
{
    public class Taxis
    {
        [Key]
        public int Id { get; set; }

        //Permitir solo números, letras y espacios en blanco RegularExpression
        [RegularExpression("^[A-Z0-9 a-z]*$", ErrorMessage = "El campo {0} permite solo números, letras y espacios en blanco")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "El campo {0} debe tener al menos un caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Plaque { get; set; }

        public ICollection<Trip> Trips { get; set; }//Un Taxis tiene una colección de viajes
    }
}
