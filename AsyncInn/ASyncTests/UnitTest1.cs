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
    }
}
