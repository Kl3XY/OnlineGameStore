﻿// <auto-generated />
using System;
using GameStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameStore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240417135951_featuring-store")]
    partial class featuringstore
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameStore.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<bool>("isFeatured")
                        .HasColumnType("bit");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("GameStore.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("GameStore.Models.Game", b =>
                {
                    b.HasOne("GameStore.Models.User", null)
                        .WithMany("OwnedGames")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("GameStore.Models.User", b =>
                {
                    b.HasOne("GameStore.Models.User", null)
                        .WithMany("Friends")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("GameStore.Models.User", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("OwnedGames");
                });
#pragma warning restore 612, 618
        }
    }
}
