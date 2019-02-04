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
        //Rooms
        [Fact]
        public void CanGetIDOfRoom()
        {
            Room room = new Room();
            room.ID = 1;
            Assert.True(room.ID == 1);
        }
        [Fact]
        public void CanSetIDOfRoom()
        {
            Room room = new Room();
            room.ID = 100;
            room.ID = 1;
            Assert.True(room.ID == 1);
        }
        [Fact]
        public void CanGetNameOfRoom()
        {
            Room room = new Room();
            room.Name = "test";
            Assert.True(room.Name == "test");
        }
        [Fact]
        public void CanSetNameOfRoom()
        {
            Room room = new Room();
            room.Name = "wrongName";
            room.Name = "test";
            Assert.True(room.Name == "test");
        }
        [Fact]
        public void CanGetLayoutOfRoom()
        {
            Room room = new Room();
            room.Layout = Layout.OneBedroom;
            Assert.True(room.Layout == Layout.OneBedroom);
        }
        [Fact]
        public void CanSetLayoutOfRoom()
        {
            Room room = new Room();
            room.Layout = Layout.Studio;
            room.Layout = Layout.OneBedroom;
            Assert.True(room.Layout == Layout.OneBedroom);
        }
        //HotelRoom
        [Fact]
        public void CanGetHotelIDOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.HotelId = 1;
            Assert.True(room.HotelId == 1);
        }
        [Fact]
        public void CanSetHotelIDOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.HotelId = 100;
            room.HotelId = 1;
            Assert.True(room.HotelId == 1);
        }
        [Fact]
        public void CanGetRoomNumberOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.RoomNumber = 1;
            Assert.True(room.RoomNumber == 1);
        }
        [Fact]
        public void CanSetRoomNumberOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.RoomNumber = 10;
            room.RoomNumber = 1;
            Assert.True(room.RoomNumber == 1);
        }
        [Fact]
        public void CanGetRoomIDOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.RoomId = 1;
            Assert.True(room.RoomId == 1);
        }
        [Fact]
        public void CanSetRoomIDOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.RoomId = 11231;
            room.RoomId = 1;
            Assert.True(room.RoomId == 1);
        }
        [Fact]
        public void CanGetRateOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.Rate = 99.99M;
            Assert.True(room.Rate == 99.99M);
        }
        [Fact]
        public void CanSetRateOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.Rate = 99.9M;
            room.Rate = 99.99M;
            Assert.True(room.Rate == 99.99M);
        }
        [Fact]
        public void CanGetPetFriendlyOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.PetFriendly = true;
            Assert.True(room.PetFriendly);
        }
        [Fact]
        public void CanSetPetFriendlyOfHotelRoom()
        {
            HotelRoom room = new HotelRoom();
            room.PetFriendly = false;
            room.PetFriendly = true;
            Assert.True(room.PetFriendly);
        }
        //and finally RoomAmenities
        [Fact]
        public void CanGetUselessIDofRoomAmenities()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.ID = 1;
            Assert.True(roomAmen.ID == 1);
        }
        [Fact]
        public void CanSetUselessIDofRoomAmenities()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.ID = 0;
            roomAmen.ID = 1;
            Assert.True(roomAmen.ID == 1);
        }
        [Fact]
        public void CanGetRoomIDofRoomAmenities()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.RoomID = 1;
            Assert.True(roomAmen.RoomID == 1);
        }
        [Fact]
        public void CanSetRoomIDofRoomAmenities()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.RoomID = 0;
            roomAmen.RoomID = 1;
            Assert.True(roomAmen.RoomID == 1);
        }
        [Fact]
        public void CanGetAmenIDofRoomAmenities()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.AmenitiesID = 1;
            Assert.True(roomAmen.AmenitiesID == 1);
        }
        [Fact]
        public void CanSetAmenIDofRoomAmenities()
        {
            RoomAmenities roomAmen = new RoomAmenities();
            roomAmen.AmenitiesID = 0;
            roomAmen.AmenitiesID = 1;
            Assert.True(roomAmen.AmenitiesID == 1);
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
