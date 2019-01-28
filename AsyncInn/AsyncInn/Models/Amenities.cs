using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Amenities
    {
        //public key for Amenities
        public int ID { get; set; }

        [Required(ErrorMessage = "Please name this new amenity.")]
        [Display(Name = "Amenity Name")]
        public string Name { get; set; }
    }
}
