﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheetApp.Models;

namespace TimeSheetApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220622021853_AddDbToDatabase")]
    partial class AddDbToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeSheetApp.Models.ClockInClockOutTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ClockInTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ClockOutTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ClockInClockOutTime");
                });

            modelBuilder.Entity("TimeSheetApp.Models.TimeSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("ElapsedTime")
                        .HasColumnType("time");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TimeSheet");
                });

            modelBuilder.Entity("TimeSheetApp.Models.ClockInClockOutTime", b =>
                {
                    b.HasOne("TimeSheetApp.Models.TimeSheet", "TimeSheet")
                        .WithMany("ClockInClockOutTimes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeSheet");
                });

            modelBuilder.Entity("TimeSheetApp.Models.TimeSheet", b =>
                {
                    b.Navigation("ClockInClockOutTimes");
                });
#pragma warning restore 612, 618
        }
    }
}