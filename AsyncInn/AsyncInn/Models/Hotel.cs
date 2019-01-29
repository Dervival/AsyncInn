using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Hotel
    {
        //Hotel properties
        //Primary Key
        public int ID { get; set; }

        [Required(ErrorMessage = "A hotel name is required.")]
        [Display(Name="Hotel Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [Display(Name = "Hotel Address")]
        public string Address { get; set; }

        [Display(Name="Contact number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
