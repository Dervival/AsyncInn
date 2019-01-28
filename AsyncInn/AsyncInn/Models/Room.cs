using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Room
    {
        //primary key
        public int ID { get; set; }

        [Required(ErrorMessage = "Please give a name to this room configuration.")]
        [Display(Name = "Configuration Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please choose whether the room is a studio, one bedroom, or two bedroom room.")]
        [Display(Name = "Configuration Name")]
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
