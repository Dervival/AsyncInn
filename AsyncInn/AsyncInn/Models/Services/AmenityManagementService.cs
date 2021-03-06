﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class AmenityManagementService : IAmenityManager
    {
        private AsyncInnDbContext _context { get; }

        public AmenityManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenities amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public void DeleteAmenity(int id)
        {
            Amenities amenity = _context.Amenities.FirstOrDefault(amenities => amenities.ID == id);
            IEnumerable<RoomAmenities> amens = _context.RoomAmenities.ToList().Where(RA => RA.AmenitiesID == amenity.ID);
            foreach (RoomAmenities roomAmenity in amens)
            {
                _context.RoomAmenities.Remove(roomAmenity);
            }
            _context.Amenities.Remove(amenity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenity(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => a.ID == id);
        }

        public void UpdateAmenities(Amenities amenity)
        {
            _context.Amenities.Update(amenity);
            _context.SaveChanges();
        }
    }
}
