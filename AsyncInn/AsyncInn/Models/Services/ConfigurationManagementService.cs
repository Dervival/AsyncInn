using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class ConfigurationManagementService : IRoomConfigManager
    {
        private AsyncInnDbContext _context { get; }

        public ConfigurationManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateConfiguration(Room room)
        {
            _context.Rooms.Add(room);
            //_context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public void DeleteConfiguration(int id)
        {
            Room room = _context.Rooms.FirstOrDefault(rooms => rooms.ID == id);
            IEnumerable<RoomAmenities> amens = _context.RoomAmenities.ToList().Where(RA => RA.RoomID == room.ID);
            foreach (RoomAmenities roomAmenity in amens)
            {
                _context.RoomAmenities.Remove(roomAmenity);
            }
            IEnumerable<HotelRoom> hotelRooms = _context.HotelRooms.ToList().Where(r => r.RoomId == room.ID);
            foreach (HotelRoom hotelRoom in hotelRooms)
            {
                _context.HotelRooms.Remove(hotelRoom);
            }
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }

        public async Task<Room> GetConfiguration(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<IEnumerable<Room>> GetConfigurations()
        {
            return await _context.Rooms.ToListAsync();
        }

        public void UpdateConfiguration(Room room)
        {
            _context.Rooms.Update(room);
        }

        public int AmentityCount(Room room)
        {
            int amenityCount = _context.RoomAmenities.Where(amenity => amenity.RoomID == room.ID).Count();
            return amenityCount;
        }
    }
}
