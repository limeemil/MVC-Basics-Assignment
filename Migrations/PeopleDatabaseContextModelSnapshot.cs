﻿// <auto-generated />
using MVC_Basics__Assignment.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC_Basics__Assignment.Migrations
{
    [DbContext(typeof(PeopleDatabaseContext))]
    partial class PeopleDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC_Basics__Assignment.ViewModels.CityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryModelId")
                        .HasColumnName("Country")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CountryModelId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryModelId = 1,
                            Name = "Borås"
                        },
                        new
                        {
                            Id = 2,
                            CountryModelId = 1,
                            Name = "Göteborg"
                        },
                        new
                        {
                            Id = 3,
                            CountryModelId = 1,
                            Name = "Stockholm"
                        },
                        new
                        {
                            Id = 4,
                            CountryModelId = 2,
                            Name = "Oslo"
                        });
                });

            modelBuilder.Entity("MVC_Basics__Assignment.ViewModels.CountryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sverige"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Norge"
                        });
                });

            modelBuilder.Entity("MVC_Basics__Assignment.ViewModels.DBPersonModel", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("First name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("Last name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("Phonenumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("SSN");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            SSN = "0123456789",
                            CityId = 1,
                            FirstName = "Andreas",
                            LastName = "Lönnermark",
                            PhoneNumber = "1234567890"
                        });
                });

            modelBuilder.Entity("MVC_Basics__Assignment.ViewModels.CityModel", b =>
                {
                    b.HasOne("MVC_Basics__Assignment.ViewModels.CountryModel", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_Basics__Assignment.ViewModels.DBPersonModel", b =>
                {
                    b.HasOne("MVC_Basics__Assignment.ViewModels.CityModel", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
