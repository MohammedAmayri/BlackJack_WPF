﻿// <auto-generated />
using System;
using EFBlackJacDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFBlackJacDAL.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20211211205414_toFixTheDamage")]
    partial class toFixTheDamage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EFBlackJacEL.Model.PlayingHabit", b =>
                {
                    b.Property<int>("HabitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MoneySpent")
                        .HasColumnType("int");

                    b.Property<int>("NoGameDays")
                        .HasColumnType("int");

                    b.HasKey("HabitId");

                    b.ToTable("PlayingHabit");
                });

            modelBuilder.Entity("GameCardLib.Model.Dealer", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CardTotal")
                        .HasColumnType("int");

                    b.Property<string>("HiddenCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HiddenCardTotal")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("GameCardLib.Model.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BankRoll")
                        .HasColumnType("int");

                    b.Property<int>("BetAmount")
                        .HasColumnType("int");

                    b.Property<int?>("CardTotal")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerPlayingHabbitsHabitId")
                        .HasColumnType("int");

                    b.Property<int>("TotalBet")
                        .HasColumnType("int");

                    b.Property<int>("TotalWinnings")
                        .HasColumnType("int");

                    b.Property<int>("WholeGameBetAmount")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("PlayerPlayingHabbitsHabitId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GameCardLib.Model.Player", b =>
                {
                    b.HasOne("EFBlackJacEL.Model.PlayingHabit", "PlayerPlayingHabbits")
                        .WithMany()
                        .HasForeignKey("PlayerPlayingHabbitsHabitId");

                    b.Navigation("PlayerPlayingHabbits");
                });
#pragma warning restore 612, 618
        }
    }
}
