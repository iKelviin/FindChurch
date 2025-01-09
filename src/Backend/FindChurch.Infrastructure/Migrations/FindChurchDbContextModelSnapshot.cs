﻿// <auto-generated />
using System;
using System.Collections.Generic;
using FindChurch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FindChurch.Infrastructure.Migrations
{
    [DbContext(typeof(FindChurchDbContext))]
    partial class FindChurchDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FindChurch.Core.Entities.Church", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.PrimitiveCollection<List<string>>("PhoneNumbers")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Churches");
                });

            modelBuilder.Entity("FindChurch.Core.Entities.Ministry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdChurch")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("IdChurch");

                    b.ToTable("Ministries");
                });

            modelBuilder.Entity("FindChurch.Core.Entities.MinistryMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdMinistry")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdMinistry");

                    b.ToTable("MinistryMember");
                });

            modelBuilder.Entity("FindChurch.Core.Entities.WorshipService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdChurch")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Service")
                        .HasColumnType("integer");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdChurch");

                    b.ToTable("WorshipServices");
                });

            modelBuilder.Entity("FindChurch.Core.Entities.Ministry", b =>
                {
                    b.HasOne("FindChurch.Core.Entities.Church", "Church")
                        .WithMany("Ministry")
                        .HasForeignKey("IdChurch")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Church");
                });

            modelBuilder.Entity("FindChurch.Core.Entities.MinistryMember", b =>
                {
                    b.HasOne("FindChurch.Core.Entities.Ministry", null)
                        .WithMany("Members")
                        .HasForeignKey("IdMinistry")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("FindChurch.Core.Entities.WorshipService", b =>
                {
                    b.HasOne("FindChurch.Core.Entities.Church", "Church")
                        .WithMany("WorshipServices")
                        .HasForeignKey("IdChurch")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Church");
                });

            modelBuilder.Entity("FindChurch.Core.Entities.Church", b =>
                {
                    b.Navigation("Ministry");

                    b.Navigation("WorshipServices");
                });

            modelBuilder.Entity("FindChurch.Core.Entities.Ministry", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
