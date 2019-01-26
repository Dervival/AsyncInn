using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class Hotel
    {
        //Hotel properties
        //Primary Key
        public int ID { get; set; }

        public string Name { get; set; }
        public int Address { get; set; }
        public int Phone { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
