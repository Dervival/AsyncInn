﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelManagementService : IHotelManager
    {
        private AsyncInnDbContext _context { get; }

        public HotelManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public void DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotels.FirstOrDefault(hotels => hotels.ID == id);
            IEnumerable<HotelRoom> hotelRooms = _context.HotelRooms.ToList().Where(room => room.HotelId == hotel.ID);
            foreach(HotelRoom hotelRoom in hotelRooms)
            {
                _context.HotelRooms.Remove(hotelRoom);
            }
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.ID == id);
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public void UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }

        /// <summary>
        /// Returns the number of rooms assocatied with this 
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public int RoomCount(Hotel hotel)
        {
            int roomCount = _context.HotelRooms.Where(room => room.HotelId == hotel.ID).Count();
            return roomCount;
        }
    }
}
