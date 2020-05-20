﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcMeetcha.Data;

namespace MvcMeetcha.Migrations
{
    [DbContext(typeof(MvcMeetchaContext))]
    [Migration("20200520054441_FixMeetupPrice")]
    partial class FixMeetupPrice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcMeetcha.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GroupImageName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GroupTypeId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("GroupTypeId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("MvcMeetcha.Models.GroupType", b =>
                {
                    b.Property<int>("GroupTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupTypeName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GroupTypeId");

                    b.ToTable("GroupType");

                    b.HasData(
                        new
                        {
                            GroupTypeId = 1,
                            GroupTypeName = "Arts"
                        },
                        new
                        {
                            GroupTypeId = 2,
                            GroupTypeName = "Beliefs"
                        },
                        new
                        {
                            GroupTypeId = 3,
                            GroupTypeName = "Book Clubs"
                        },
                        new
                        {
                            GroupTypeId = 4,
                            GroupTypeName = "Career & Business"
                        },
                        new
                        {
                            GroupTypeId = 5,
                            GroupTypeName = "Dance"
                        },
                        new
                        {
                            GroupTypeId = 6,
                            GroupTypeName = "Family"
                        },
                        new
                        {
                            GroupTypeId = 7,
                            GroupTypeName = "Fashion & Beauty"
                        },
                        new
                        {
                            GroupTypeId = 8,
                            GroupTypeName = "Film"
                        },
                        new
                        {
                            GroupTypeId = 9,
                            GroupTypeName = "Food & Drinks"
                        },
                        new
                        {
                            GroupTypeId = 10,
                            GroupTypeName = "Health & Wellness"
                        },
                        new
                        {
                            GroupTypeId = 11,
                            GroupTypeName = "Hobbies & Crafts"
                        },
                        new
                        {
                            GroupTypeId = 12,
                            GroupTypeName = "Language & Culture"
                        },
                        new
                        {
                            GroupTypeId = 13,
                            GroupTypeName = "Learning"
                        },
                        new
                        {
                            GroupTypeId = 14,
                            GroupTypeName = "Movements"
                        },
                        new
                        {
                            GroupTypeId = 15,
                            GroupTypeName = "Music"
                        },
                        new
                        {
                            GroupTypeId = 16,
                            GroupTypeName = "Outdoors & Adventure"
                        },
                        new
                        {
                            GroupTypeId = 17,
                            GroupTypeName = "Pets"
                        },
                        new
                        {
                            GroupTypeId = 18,
                            GroupTypeName = "Photography"
                        },
                        new
                        {
                            GroupTypeId = 19,
                            GroupTypeName = "Sci-Fi & Games"
                        },
                        new
                        {
                            GroupTypeId = 20,
                            GroupTypeName = "Social"
                        },
                        new
                        {
                            GroupTypeId = 21,
                            GroupTypeName = "Sports & Fitness"
                        },
                        new
                        {
                            GroupTypeId = 22,
                            GroupTypeName = "Writing"
                        });
                });

            modelBuilder.Entity("MvcMeetcha.Models.Meetup", b =>
                {
                    b.Property<int>("MeetupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MeetupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeetupDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("MeetupFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MeetupImageName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MeetupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("MeetupTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MeetupTypeId")
                        .HasColumnType("int");

                    b.Property<string>("MeetupVenue")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MeetupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("MeetupTypeId");

                    b.ToTable("Meetup");
                });

            modelBuilder.Entity("MvcMeetcha.Models.MeetupType", b =>
                {
                    b.Property<int>("MeetupTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MeetupTypeName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MeetupTypeId");

                    b.ToTable("MeetupType");

                    b.HasData(
                        new
                        {
                            MeetupTypeId = 1,
                            MeetupTypeName = "Event"
                        },
                        new
                        {
                            MeetupTypeId = 2,
                            MeetupTypeName = "Workshop"
                        },
                        new
                        {
                            MeetupTypeId = 3,
                            MeetupTypeName = "Seminar"
                        },
                        new
                        {
                            MeetupTypeId = 4,
                            MeetupTypeName = "Conference"
                        },
                        new
                        {
                            MeetupTypeId = 5,
                            MeetupTypeName = "Programme"
                        });
                });

            modelBuilder.Entity("MvcMeetcha.Models.Group", b =>
                {
                    b.HasOne("MvcMeetcha.Models.GroupType", "GroupType")
                        .WithMany()
                        .HasForeignKey("GroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MvcMeetcha.Models.Meetup", b =>
                {
                    b.HasOne("MvcMeetcha.Models.Group", "Group")
                        .WithMany("GroupMeetups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcMeetcha.Models.MeetupType", "MeetupType")
                        .WithMany()
                        .HasForeignKey("MeetupTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
