﻿// <auto-generated />
using System;
using Abc.HabitTracker.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Abc.HabitTracker.Api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200704104714_InitialMigration1")]
    partial class InitialMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Abc.HabitTracker.Api.BadgeAggregate.Badge", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.BadgeAggregate.BadgeUse", b =>
                {
                    b.Property<Guid>("HabitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("badgeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HabitID");

                    b.HasIndex("badgeID");

                    b.ToTable("BadgeUses");
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.HabitAggregate.DaysOff", b =>
                {
                    b.Property<Guid>("HabitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HabitID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("daysoff")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HabitId");

                    b.HasIndex("HabitID");

                    b.ToTable("daysOffs");
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.HabitAggregate.Habit", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<short>("CurrentStreak")
                        .HasColumnType("smallint");

                    b.Property<short>("LogCount")
                        .HasColumnType("smallint");

                    b.Property<short>("LongestStreak")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.HabitAggregate.Log", b =>
                {
                    b.Property<Guid>("HabitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateLog")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HabitID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HabitId");

                    b.HasIndex("HabitID");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.BadgeAggregate.BadgeUse", b =>
                {
                    b.HasOne("Abc.HabitTracker.Api.BadgeAggregate.Badge", "badge")
                        .WithMany()
                        .HasForeignKey("badgeID");
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.HabitAggregate.DaysOff", b =>
                {
                    b.HasOne("Abc.HabitTracker.Api.HabitAggregate.Habit", "Habit")
                        .WithMany("daysOff")
                        .HasForeignKey("HabitID");
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.HabitAggregate.Log", b =>
                {
                    b.HasOne("Abc.HabitTracker.Api.HabitAggregate.Habit", "Habit")
                        .WithMany()
                        .HasForeignKey("HabitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}