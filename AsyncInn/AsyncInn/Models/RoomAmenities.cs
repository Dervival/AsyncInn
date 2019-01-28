using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        //Composite key - AmenitiesID is the foreign key for the Amenities table, RoomID is the foreign key for the Room Table
        [Required(ErrorMessage = "Please select a room configuration to assocate an amenity with.")]
        [Display(Name = "Configuration Name")]
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Please select an amenity to assocate with a room configuration.")]
        [Display(Name = "Amenity Name")]
        public int AmenitiesID { get; set; }

        //Navigation properties
        public Room Room { get; set; }
        public Amenities Amenity { get; set; }
    }
}
