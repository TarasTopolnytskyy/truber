﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Truber_Project.Contexts;

namespace Truber_Project.Migrations
{
    [DbContext(typeof(HomeContext))]
    partial class HomeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Truber_Project.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarMake");

                    b.Property<string>("CarModel");

                    b.Property<string>("ConfirmPassword");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Plates");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("Year");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Truber_Project.Models.Truber", b =>
                {
                    b.Property<int>("TruberId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressDropOff");

                    b.Property<string>("AddressPickUp");

                    b.Property<int?>("Completed");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("DriverId");

                    b.Property<DateTime>("DropOffTime");

                    b.Property<int>("Height");

                    b.Property<int>("Length");

                    b.Property<int>("PhoneNumber");

                    b.Property<DateTime>("PickUpTime");

                    b.Property<int>("Price");

                    b.Property<int>("TotalAmoutOfMiles");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.Property<int>("Weight");

                    b.Property<int>("Width");

                    b.HasKey("TruberId");

                    b.HasIndex("DriverId");

                    b.HasIndex("UserId");

                    b.ToTable("Trubers");
                });

            modelBuilder.Entity("Truber_Project.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Truber_Project.Models.Truber", b =>
                {
                    b.HasOne("Truber_Project.Models.Driver", "Taker")
                        .WithMany("Jobs")
                        .HasForeignKey("DriverId");

                    b.HasOne("Truber_Project.Models.User", "Poster")
                        .WithMany("Jobs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
