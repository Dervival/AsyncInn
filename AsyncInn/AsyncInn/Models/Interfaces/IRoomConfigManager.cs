using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IRoomConfigManager
    {
        //Create a room configuration
        Task CreateConfiguration(Room room);
        //Read in a configuration
        Task<Room> GetConfiguration(int id);
        //Read in several room configurations
        Task<IEnumerable<Room>> GetConfigurations();
        //Update a room
        void UpdateConfiguration(Room room);
        //Delete a room
        void DeleteConfiguration(int id);
    }
}
