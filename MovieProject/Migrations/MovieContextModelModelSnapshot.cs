﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieProject.Models;

#nullable disable

namespace MovieProject.Migrations
{
    [DbContext(typeof(MovieContextModel))]
    partial class MovieContextModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieProject.Models.GenreModel", b =>
                {
                    b.Property<string>("GenreModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreModelId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreModelId = "D",
                            Name = "Drama"
                        },
                        new
                        {
                            GenreModelId = "C",
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreModelId = "A",
                            Name = "Action"
                        },
                        new
                        {
                            GenreModelId = "H",
                            Name = "Horror"
                        },
                        new
                        {
                            GenreModelId = "M",
                            Name = "Musical"
                        },
                        new
                        {
                            GenreModelId = "R",
                            Name = "RomCom"
                        },
                        new
                        {
                            GenreModelId = "S",
                            Name = "SciFi"
                        });
                });

            modelBuilder.Entity("MovieProject.Models.MovieModel", b =>
                {
                    b.Property<int>("MovieModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieModelId"));

                    b.Property<string>("GenreModelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("MovieModelId");

                    b.HasIndex("GenreModelId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieModelId = 1,
                            GenreModelId = "D",
                            Name = "The Godfather",
                            Rating = 5,
                            Year = 1972
                        },
                        new
                        {
                            MovieModelId = 2,
                            GenreModelId = "A",
                            Name = "John Wick",
                            Rating = 4,
                            Year = 2011
                        },
                        new
                        {
                            MovieModelId = 3,
                            GenreModelId = "D",
                            Name = "The Irishman",
                            Rating = 5,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("MovieProject.Models.MovieModel", b =>
                {
                    b.HasOne("MovieProject.Models.GenreModel", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
