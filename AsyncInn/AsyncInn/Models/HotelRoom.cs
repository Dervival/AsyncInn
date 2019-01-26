using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        //Composite keys for the table - HotelId is also the foreign key for the Hotel table
        public int HotelId { get; set; } 
        public int RoomNumber { get; set; }
        
        //Foreign key for Room table
        public decimal RoomId { get; set; }

        //Payload
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        //Navigation Properties

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
