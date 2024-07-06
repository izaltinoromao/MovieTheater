﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieTheater.Shared.Data.DB;

#nullable disable

namespace MovieTheater.Shared.Data.Migrations
{
    [DbContext(typeof(MovieTheaterContext))]
    [Migration("20240706204716_RelateMovie")]
    partial class RelateMovie
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieTheater_Console.MovieEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("MovieTheaterEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieTheaterEntityId");

                    b.ToTable("MovieEntity");
                });

            modelBuilder.Entity("MovieTheater_Console.MovieTheaterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MovieTheaterEntity");
                });

            modelBuilder.Entity("MovieTheater_Console.MovieEntity", b =>
                {
                    b.HasOne("MovieTheater_Console.MovieTheaterEntity", "MovieTheaterEntity")
                        .WithMany()
                        .HasForeignKey("MovieTheaterEntityId");

                    b.Navigation("MovieTheaterEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
