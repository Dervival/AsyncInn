using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //need to add composite key associations here for HotelRoom and RoomAmenities
            modelBuilder.Entity<HotelRoom>().HasKey(hotelRoom => new { hotelRoom.HotelId, hotelRoom.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(amen => new { amen.AmenitiesID, amen.RoomID });
        }

        //setup DbSets
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
