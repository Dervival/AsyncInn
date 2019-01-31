using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        //Create a hotel
        Task CreateHotel(Hotel hotel);
        //Read in a hotel
        Task<Hotel> GetHotel(int id);
        //Read in several hotels
        Task<IEnumerable<Hotel>> GetHotels();
        //Update a hotel
        void UpdateHotel(Hotel hotel);
        //Delete a hotel
        void DeleteHotel(int id);
        //Count of rooms in the hotel
        int RoomCount(Hotel hotel);
    }
}
