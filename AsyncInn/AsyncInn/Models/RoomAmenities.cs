using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        //Composite key - AmenitiesID is the foreign key for the Amenities table, RoomID is the foreign key for the Room Table
        public int RoomID { get; set; }
        public int AmenitiesID { get; set; }

        //Navigation properties
        public Room Room { get; set; }
        public Amenities Amenity { get; set; }
    }
}
