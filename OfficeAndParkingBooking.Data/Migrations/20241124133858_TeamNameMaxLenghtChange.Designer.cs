﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfficeAndParkingBooking.Data;

#nullable disable

namespace OfficeAndParkingBooking.Data.Migrations
{
    [DbContext(typeof(OfficeAndParkingBookingDbContext))]
    [Migration("20241124133858_TeamNameMaxLenghtChange")]
    partial class TeamNameMaxLenghtChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationPlate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.OfficeBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoomId");

                    b.ToTable("OfficeBooking");
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.ParkingBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ParkingSpotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ParkingSpotId");

                    b.ToTable("ParkingBooking");
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.ParkingSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkingSpots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = 1
                        },
                        new
                        {
                            Id = 2,
                            Number = 2
                        },
                        new
                        {
                            Id = 3,
                            Number = 3
                        },
                        new
                        {
                            Id = 4,
                            Number = 4
                        });
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 8,
                            Number = 403
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 8,
                            Number = 404
                        });
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "BA"
                        },
                        new
                        {
                            Id = 2,
                            Name = "HR"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sys Admin"
                        },
                        new
                        {
                            Id = 4,
                            Name = "DevOps"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 6,
                            Name = ".NET"
                        },
                        new
                        {
                            Id = 7,
                            Name = "AM"
                        },
                        new
                        {
                            Id = 8,
                            Name = "FO"
                        });
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.Car", b =>
                {
                    b.HasOne("OfficeAndParkingBooking.Data.Models.Employee", "Employee")
                        .WithMany("Cars")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.Employee", b =>
                {
                    b.HasOne("OfficeAndParkingBooking.Data.Models.Team", "Team")
                        .WithMany("Employees")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.OfficeBooking", b =>
                {
                    b.HasOne("OfficeAndParkingBooking.Data.Models.Employee", "Employees")
                        .WithMany("OfficeBookings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OfficeAndParkingBooking.Data.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.ParkingBooking", b =>
                {
                    b.HasOne("OfficeAndParkingBooking.Data.Models.Employee", "Employees")
                        .WithMany("ParkingBookings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OfficeAndParkingBooking.Data.Models.ParkingSpot", "ParkingSpot")
                        .WithMany()
                        .HasForeignKey("ParkingSpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("ParkingSpot");
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.Employee", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("OfficeBookings");

                    b.Navigation("ParkingBookings");
                });

            modelBuilder.Entity("OfficeAndParkingBooking.Data.Models.Team", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}