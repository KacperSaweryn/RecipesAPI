﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipesAPI.Data;

#nullable disable

namespace RecipesAPI.Migrations
{
    [DbContext(typeof(RecipesContext))]
    [Migration("20230610103042_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DifficultyDish", b =>
                {
                    b.Property<int>("DifficultiesId")
                        .HasColumnType("int");

                    b.Property<int>("DishesId")
                        .HasColumnType("int");

                    b.HasKey("DifficultiesId", "DishesId");

                    b.HasIndex("DishesId");

                    b.ToTable("DifficultyDish");
                });

            modelBuilder.Entity("DishTool", b =>
                {
                    b.Property<int>("DishesId")
                        .HasColumnType("int");

                    b.Property<int>("ToolsId")
                        .HasColumnType("int");

                    b.HasKey("DishesId", "ToolsId");

                    b.HasIndex("ToolsId");

                    b.ToTable("DishTool");
                });

            modelBuilder.Entity("RecipesAPI.Models.Difficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("RecipesAPI.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DishTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DishTypeId");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("RecipesAPI.Models.DishDifficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<int?>("DishId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("DishId");

                    b.ToTable("DishDifficulty");
                });

            modelBuilder.Entity("RecipesAPI.Models.DishIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DishId")
                        .HasColumnType("int");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredient");
                });

            modelBuilder.Entity("RecipesAPI.Models.DishType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DishType");
                });

            modelBuilder.Entity("RecipesAPI.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("RecipesAPI.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tool");
                });

            modelBuilder.Entity("RecipesAPI.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("DifficultyDish", b =>
                {
                    b.HasOne("RecipesAPI.Models.Difficulty", null)
                        .WithMany()
                        .HasForeignKey("DifficultiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipesAPI.Models.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DishTool", b =>
                {
                    b.HasOne("RecipesAPI.Models.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipesAPI.Models.Tool", null)
                        .WithMany()
                        .HasForeignKey("ToolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipesAPI.Models.Dish", b =>
                {
                    b.HasOne("RecipesAPI.Models.DishType", "DishType")
                        .WithMany("Dishes")
                        .HasForeignKey("DishTypeId");

                    b.Navigation("DishType");
                });

            modelBuilder.Entity("RecipesAPI.Models.DishDifficulty", b =>
                {
                    b.HasOne("RecipesAPI.Models.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId");

                    b.HasOne("RecipesAPI.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId");

                    b.Navigation("Difficulty");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("RecipesAPI.Models.DishIngredient", b =>
                {
                    b.HasOne("RecipesAPI.Models.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishId");

                    b.HasOne("RecipesAPI.Models.Ingredient", "Ingredient")
                        .WithMany("DishIngredients")
                        .HasForeignKey("IngredientId");

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("RecipesAPI.Models.Ingredient", b =>
                {
                    b.HasOne("RecipesAPI.Models.Unit", "Unit")
                        .WithMany("Ingredients")
                        .HasForeignKey("UnitId");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("RecipesAPI.Models.Dish", b =>
                {
                    b.Navigation("DishIngredients");
                });

            modelBuilder.Entity("RecipesAPI.Models.DishType", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("RecipesAPI.Models.Ingredient", b =>
                {
                    b.Navigation("DishIngredients");
                });

            modelBuilder.Entity("RecipesAPI.Models.Unit", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
