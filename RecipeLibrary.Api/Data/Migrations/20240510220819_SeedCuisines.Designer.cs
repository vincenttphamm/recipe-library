﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeLibrary.Api;

#nullable disable

namespace RecipeLibrary.Api.Data.Migrations
{
    [DbContext(typeof(RecipeLibraryContext))]
    [Migration("20240510220819_SeedCuisines")]
    partial class SeedCuisines
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("RecipeLibrary.Api.Entities.Cuisine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cuisines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Italian"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Thai"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Indian"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mexican"
                        });
                });

            modelBuilder.Entity("RecipeLibrary.Api.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CookTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CuisineId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingredients")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CuisineId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeLibrary.Api.Entities.Recipe", b =>
                {
                    b.HasOne("RecipeLibrary.Api.Entities.Cuisine", "Cuisine")
                        .WithMany()
                        .HasForeignKey("CuisineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuisine");
                });
#pragma warning restore 612, 618
        }
    }
}