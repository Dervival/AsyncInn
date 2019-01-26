using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        //primary key
        public int ID { get; set; }

        public string Name { get; set; }
        public Layout Layout { get; set; }

        //navigation properties
        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenities> Amenities { get; set; }
    }

    //Using the bedroom layouts of the room as the enum...
    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}
