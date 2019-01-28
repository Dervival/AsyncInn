﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20190128193328_Lab14SeededData")]
    partial class Lab14SeededData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Mini-fridge"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Personal Safe"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Clothes Drawer"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Microwave"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Freezer"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "2901 3rd Ave #300, Seattle, WA 98121",
                            Name = "Seattle Original",
                            Phone = "(503) 780-4561"
                        },
                        new
                        {
                            ID = 2,
                            Address = "400 Broad St, Seattle, WA 98109",
                            Name = "Seattle Auxiliary",
                            Phone = "(111) 112-3456"
                        },
                        new
                        {
                            ID = 3,
                            Address = "The last train on the 8:05 red line",
                            Name = "Portland's Finest",
                            Phone = "(333) 999-0101"
                        },
                        new
                        {
                            ID = 4,
                            Address = "Somewhere in New York",
                            Name = "HQ 2 (location 1)",
                            Phone = "(551) 293-1443"
                        },
                        new
                        {
                            ID = 5,
                            Address = "Somewhere near D.C.",
                            Name = "HQ 2 (location 2)",
                            Phone = "(992) 111-2342"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelId");

                    b.Property<int>("RoomNumber");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<int>("RoomId");

                    b.HasKey("HotelId", "RoomNumber");

                    b.HasIndex("RoomId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "Basic Studio"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 0,
                            Name = "Executive Studio"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 1,
                            Name = "Basic One Bedroom"
                        },
                        new
                        {
                            ID = 4,
                            Layout = 1,
                            Name = "One Bedroom Suite"
                        },
                        new
                        {
                            ID = 5,
                            Layout = 2,
                            Name = "Two Bedroom Suite"
                        },
                        new
                        {
                            ID = 6,
                            Layout = 2,
                            Name = "Presidential Suite"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesID");

                    b.Property<int>("RoomID");

                    b.HasKey("AmenitiesID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenity")
                        .WithMany()
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("Amenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
