using System;
using Xunit;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Services;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//using Microsoft.EntityFrameworkCore;

namespace ASyncTests
{
    public class UnitTest1
    {
        //Getters/Setters
        //Testing Amenities
        [Fact]
        public void CanGetIDOfAmenities()
        {
            Amenities amenity = new Amenities();
            amenity.ID = 0;
            Assert.True(amenity.ID == 0);
        }
        [Fact]
        public void CanSetIDOfAmenities()
        {
            Amenities amenity = new Amenities();
            amenity.ID = 10;
            amenity.ID = 0;
            Assert.True(amenity.ID == 0);
        }
        [Fact]
        public void CanGetNameOfAmenities()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Fridge";
            Assert.True(amenity.Name == "Fridge");
        }
        [Fact]
        public void CanSetNameOfAmenities()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "Sink";
            amenity.Name = "Fridge";
            Assert.True(amenity.Name == "Fridge");
        }
        //Testing Hotels
        [Fact]
        public void CanGetIDOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 1;
            Assert.True(hotel.ID == 1);
        }
        [Fact]
        public void CanSetIDOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 100;
            hotel.ID = 1;
            Assert.True(hotel.ID == 1);
        }
        [Fact]
        public void CanGetNameOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "test";
            Assert.True(hotel.Name == "test");
        }
        [Fact]
        public void CanSetNameOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "test2";
            hotel.Name = "test";
            Assert.True(hotel.Name == "test");
        }
        [Fact]
        public void CanGetAddressOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "testPlace";
            Assert.True(hotel.Address == "testPlace");
        }
        [Fact]
        public void CanSetAddressOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "test2";
            hotel.Address = "test";
            Assert.True(hotel.Address == "test");
        }

        [Fact]
        public void CanGetPhoneOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "911";
            Assert.True(hotel.Phone == "911");
        }
        [Fact]
        public void CanSetPhoneOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "911";
            hotel.Phone = "5052229191";
            Assert.True(hotel.Phone == "5052229191");
        }
        [Fact]
        public void CanGetRoomCountOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.RoomCount = 10;
            Assert.True(hotel.RoomCount == 10);
        }
        [Fact]
        public void CanSetRoomCountOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.RoomCount = 100;
            hotel.RoomCount = 10;
            Assert.True(hotel.RoomCount == 10);
        }

        //CRUD
        [Fact]
        public async void CanCreateAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmen").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Amenities amen = new Amenities();
                amen.ID = 1;
                amen.Name = "Sink";

                //Act
                AmenityManagementService amenServ = new AmenityManagementService(context);

                await amenServ.CreateAmenity(amen);

                var result = context.Amenities.FirstOrDefault(c => c.ID == amen.ID);
                //Assert
                Assert.Equal(amen, result);
            }
        }
        [Fact]
        public async void CanGetAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetAmen").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Amenities amen = new Amenities();
                amen.ID = 1;
                amen.Name = "Sink";

                //Act
                AmenityManagementService amenServ = new AmenityManagementService(context);

                await amenServ.CreateAmenity(amen);

                var result = await amenServ.GetAmenity(amen.ID);

                //Assert
                Assert.Equal(amen, result);
            }
        }
        [Fact]
        public async void CanUpdateAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateAmen").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Amenities amen = new Amenities();
                amen.ID = 1;
                amen.Name = "Sink";

                //Act
                AmenityManagementService amenServ = new AmenityManagementService(context);
                await amenServ.CreateAmenity(amen);
                amen.Name = "Fridge";
                amenServ.UpdateAmenities(amen);

                var result = await amenServ.GetAmenity(amen.ID);

                //Assert
                Assert.Equal(amen, result);
            }
        }
        [Fact]
        public async void CanDeleteAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteAmen").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Amenities amen = new Amenities();
                amen.ID = 1;
                amen.Name = "Sink";

                //Act
                AmenityManagementService amenServ = new AmenityManagementService(context);
                await amenServ.CreateAmenity(amen);
                amenServ.DeleteAmenity(amen.ID);

                var result = await amenServ.GetAmenity(amen.ID);

                //Assert
                Assert.Null(result);
            }
        }
        [Fact]
        public async void CanCreateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "test";
                hotel.Address = "123 fake st";
                hotel.Phone = "555-555-5555";
                hotel.RoomCount = 0;

                //Act
                HotelManagementService hotelServ = new HotelManagementService(context);

                await hotelServ.CreateHotel(hotel);

                var result = await hotelServ.GetHotel(hotel.ID);
                //Assert
                Assert.Equal(hotel, result);
            }
        }
        [Fact]
        public async void CanUpdateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "test";
                hotel.Address = "123 fake st";
                hotel.Phone = "555-555-5555";
                hotel.RoomCount = 0;

                //Act
                HotelManagementService hotelServ = new HotelManagementService(context);

                await hotelServ.CreateHotel(hotel);

                hotel.RoomCount = 100;
                hotelServ.UpdateHotel(hotel);

                var result = context.Hotels.FirstOrDefault(c => c.ID == hotel.ID);
                //Assert
                Assert.Equal(hotel, result);
            }
        }

        [Fact]
        public async void CanReadHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("ReadHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "test";
                hotel.Address = "123 fake st";
                hotel.Phone = "555-555-5555";
                hotel.RoomCount = 0;

                //Act
                HotelManagementService hotelServ = new HotelManagementService(context);

                await hotelServ.CreateHotel(hotel);

                var result = context.Hotels.FirstOrDefault(c => c.ID == hotel.ID);
                //Assert
                Assert.Equal(hotel, result);
            }
        }
        [Fact]
        public async void CanDeleteHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "test";
                hotel.Address = "123 fake st";
                hotel.Phone = "555-555-5555";
                hotel.RoomCount = 0;

                //Act
                HotelManagementService hotelServ = new HotelManagementService(context);

                await hotelServ.CreateHotel(hotel);

                hotelServ.DeleteHotel(hotel.ID);

                var result = context.Hotels.FirstOrDefault(c => c.ID == hotel.ID);
                //Assert
                Assert.Null(result);
            }
        }
    }
}
