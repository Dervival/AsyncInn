using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IAmenityManager
    {
        //Create a amenity
        Task CreateAmenity(Amenities amenity);
        //Read in a amenity
        Task<Amenities> GetAmenity(int id);
        //Read in several amenities
        Task<IEnumerable<Amenities>> GetAmenities();
        //Update a amenity
        void UpdateAmenities(Amenities amenity);
        //Delete a amenity
        void DeleteAmenity(int id);
    }
}
