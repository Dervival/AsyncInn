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

            //Seeding data...
            //Hotel locations
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Seattle Original",
                    Address = "2901 3rd Ave #300, Seattle, WA 98121",
                    Phone = "(503) 780-4561"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Seattle Auxiliary",
                    Address = "400 Broad St, Seattle, WA 98109",
                    Phone = "(111) 112-3456"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Portland's Finest",
                    Address = "The last train on the 8:05 red line",
                    Phone = "(333) 999-0101"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "HQ 2 (location 1)",
                    Address = "Somewhere in New York",
                    Phone = "(551) 293-1443"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "HQ 2 (location 2)",
                    Address = "Somewhere near D.C.",
                    Phone = "(992) 111-2342"
                }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Basic Studio",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 2,
                    Name = "Executive Studio",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 3,
                    Name = "Basic One Bedroom",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 4,
                    Name = "One Bedroom Suite",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Two Bedroom Suite",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 6,
                    Name = "Presidential Suite",
                    Layout = Layout.TwoBedroom
                }
                );
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Mini-fridge"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Personal Safe"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Clothes Drawer"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Microwave"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Freezer"
                }
            );
        }

        //setup DbSets
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
