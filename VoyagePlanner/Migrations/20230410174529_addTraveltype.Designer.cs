﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VoyagePlanner.Data;

#nullable disable

namespace VoyagePlanner.Migrations
{
    [DbContext(typeof(VoyagePlannerContext))]
    [Migration("20230410174529_addTraveltype")]
    partial class addTraveltype
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VoyagePlanner.Models.Allowance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("ReductionPercentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Allowance");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DistancePlane")
                        .HasColumnType("int");

                    b.Property<int>("DistanceRoad")
                        .HasColumnType("int");

                    b.Property<bool>("FerryNeeded")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Extra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VoyageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoyageId");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VoyageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoyageId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("VoyagePlanner.Models.TravelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CostPerKilometre")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TravelTypes");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Voyage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfVoyage")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("TravelTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("TravelTypeId");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Allowance", b =>
                {
                    b.HasOne("VoyagePlanner.Models.Person", null)
                        .WithMany("Allowances")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Extra", b =>
                {
                    b.HasOne("VoyagePlanner.Models.Voyage", null)
                        .WithMany("Extras")
                        .HasForeignKey("VoyageId");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Person", b =>
                {
                    b.HasOne("VoyagePlanner.Models.Voyage", "Voyage")
                        .WithMany("Persons")
                        .HasForeignKey("VoyageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voyage");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Voyage", b =>
                {
                    b.HasOne("VoyagePlanner.Models.Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoyagePlanner.Models.TravelType", "TravelType")
                        .WithMany()
                        .HasForeignKey("TravelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("TravelType");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Person", b =>
                {
                    b.Navigation("Allowances");
                });

            modelBuilder.Entity("VoyagePlanner.Models.Voyage", b =>
                {
                    b.Navigation("Extras");

                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
