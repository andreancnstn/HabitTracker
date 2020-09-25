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
    [Migration("20200705082015_changesToTableBadgeUse2")]
    partial class changesToTableBadgeUse2
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
                    b.Property<Guid>("BadgeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BadgeID");

                    b.ToTable("BadgeUses");
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.HabitAggregate.DaysOff", b =>
                {
                    b.Property<Guid>("DaysOffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HabitID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("daysoff")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DaysOffID");

                    b.HasIndex("HabitID")
                        .IsUnique();

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
                    b.Property<Guid>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateLog")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HabitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LogId");

                    b.HasIndex("HabitId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.BadgeAggregate.BadgeUse", b =>
                {
                    b.HasOne("Abc.HabitTracker.Api.BadgeAggregate.Badge", "Badge")
                        .WithMany()
                        .HasForeignKey("BadgeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.HabitAggregate.DaysOff", b =>
                {
                    b.HasOne("Abc.HabitTracker.Api.HabitAggregate.Habit", "Habit")
                        .WithOne("daysOff")
                        .HasForeignKey("Abc.HabitTracker.Api.HabitAggregate.DaysOff", "HabitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Abc.HabitTracker.Api.HabitAggregate.Log", b =>
                {
                    b.HasOne("Abc.HabitTracker.Api.HabitAggregate.Habit", "Habit")
                        .WithMany()
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}