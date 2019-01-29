using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        //Composite keys for the table - HotelId is also the foreign key for the Hotel table
        [Required(ErrorMessage = "Please select a hotel to associate this room with.")]
        [Display(Name = "Hotel Name")]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Please select a room number for this hotel room.")]
        [Display(Name = "Room number")]
        public int RoomNumber { get; set; }

        //Foreign key for Room table
        [Required(ErrorMessage = "Please select a room configuration.")]
        [Display(Name = "Configuration Name")]
        public int RoomId { get; set; }

        //Payload
        [Required(ErrorMessage = "Please set a monetary rate for this room.")]
        [Display(Name = "Nightly Rate")]
        public decimal Rate { get; set; }
        [Required(ErrorMessage = "Please choose whether or not this room is pet friendly.")]
        [Display(Name = "Room is pet-friendly")]
        public bool PetFriendly { get; set; }

        //Navigation Properties

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
