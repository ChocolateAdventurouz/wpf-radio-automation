﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RA.Database;

#nullable disable

namespace RA.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Categories_Tracks", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "TrackId");

                    b.HasIndex("TrackId");

                    b.ToTable("Categories_Tracks");
                });

            modelBuilder.Entity("RA.Database.Models.Abstract.ClockItemBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClockId")
                        .HasColumnType("int");

                    b.Property<int?>("ClockItemEventId")
                        .HasColumnType("int");

                    b.Property<int>("ClockItemType")
                        .HasColumnType("int");

                    b.Property<int?>("EventOrderIndex")
                        .HasColumnType("int");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClockId");

                    b.HasIndex("ClockItemEventId");

                    b.ToTable("ClockItems");

                    b.HasDiscriminator<int>("ClockItemType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RA.Database.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("varchar(1500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("RA.Database.Models.ArtistTrack", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "TrackId");

                    b.HasIndex("TrackId");

                    b.ToTable("Artists_Tracks");
                });

            modelBuilder.Entity("RA.Database.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Music"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Station ID"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Commercials"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Shows"
                        },
                        new
                        {
                            Id = 5,
                            Name = "News"
                        });
                });

            modelBuilder.Entity("RA.Database.Models.CategoryHierarchy", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("PathName")
                        .HasColumnType("longtext");

                    b.ToTable((string)null);

                    b.ToView("CategoriesHierarchy", (string)null);
                });

            modelBuilder.Entity("RA.Database.Models.Clock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Clocks");
                });

            modelBuilder.Entity("RA.Database.Models.ClockItemCategoryTag", b =>
                {
                    b.Property<int>("ClockItemCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TagValueId")
                        .HasColumnType("int");

                    b.HasKey("ClockItemCategoryId", "TagValueId");

                    b.HasIndex("TagValueId");

                    b.ToTable("ClockItemsCategory_Tags");
                });

            modelBuilder.Entity("RA.Database.Models.ClockTemplate", b =>
                {
                    b.Property<int>("ClockId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(6)");

                    b.Property<int>("ClockSpan")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("ClockId", "TemplateId", "StartTime");

                    b.HasIndex("TemplateId");

                    b.ToTable("Clocks_Templates");
                });

            modelBuilder.Entity("RA.Database.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AirDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("RA.Database.Models.PlaylistItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ETA")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Length")
                        .HasColumnType("double(11,5)");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int?>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("TrackId");

                    b.ToTable("PlaylistItems");
                });

            modelBuilder.Entity("RA.Database.Models.ScheduleDefault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("SchedulesDefault");
                });

            modelBuilder.Entity("RA.Database.Models.ScheduleDefaultItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("TemplateId");

                    b.ToTable("ScheduleDefaultItems");
                });

            modelBuilder.Entity("RA.Database.Models.SchedulePlanned", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Frequency")
                        .HasColumnType("int");

                    b.Property<bool?>("IsFriday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsMonday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsSaturday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsSunday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsThursday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsTuesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsWednesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("SchedulesPlanned");
                });

            modelBuilder.Entity("RA.Database.Models.TagCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsBuiltIn")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TagCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsBuiltIn = true,
                            Name = "Genre"
                        },
                        new
                        {
                            Id = 2,
                            IsBuiltIn = true,
                            Name = "Language"
                        },
                        new
                        {
                            Id = 3,
                            IsBuiltIn = true,
                            Name = "Mood"
                        });
                });

            modelBuilder.Entity("RA.Database.Models.TagValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TagCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TagCategoryId");

                    b.ToTable("TagValues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "English",
                            TagCategoryId = 2
                        },
                        new
                        {
                            Id = 2,
                            Name = "French",
                            TagCategoryId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Romanian",
                            TagCategoryId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Happy",
                            TagCategoryId = 3
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sad",
                            TagCategoryId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Energetic",
                            TagCategoryId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Rock",
                            TagCategoryId = 1
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pop",
                            TagCategoryId = 1
                        },
                        new
                        {
                            Id = 9,
                            Name = "Dance",
                            TagCategoryId = 1
                        });
                });

            modelBuilder.Entity("RA.Database.Models.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("RA.Database.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Album")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("Bpm")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Duration")
                        .HasColumnType("double(11,5)");

                    b.Property<double?>("EndCue")
                        .HasColumnType("double(11,5)");

                    b.Property<string>("FilePath")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ISRC")
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.Property<string>("ImageName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double?>("NextCue")
                        .HasColumnType("double(11,5)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double?>("StartCue")
                        .HasColumnType("double(11,5)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilePath");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("RA.Database.Models.TrackHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Artists")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DatePlayed")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ISRC")
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.Property<TimeSpan>("LengthPlayed")
                        .HasColumnType("time(6)");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("TrackId")
                        .HasColumnType("int");

                    b.Property<int>("TrackType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("TrackHistory");
                });

            modelBuilder.Entity("RA.Database.Models.TrackTag", b =>
                {
                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int>("TagValueId")
                        .HasColumnType("int");

                    b.HasKey("TrackId", "TagValueId");

                    b.HasIndex("TagValueId");

                    b.ToTable("Track_Tags");
                });

            modelBuilder.Entity("RA.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Andrei",
                            Password = "$2a$11$SWq88W6Q77w7sanz7HrxbexnTN0nLq8XB70lLFrSDQbddPzmnQdIK",
                            UserGroupId = 1,
                            Username = "andrei"
                        });
                });

            modelBuilder.Entity("RA.Database.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("RA.Database.Models.UserGroupRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RuleValue")
                        .HasColumnType("int");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.ToTable("UserGroupRules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RuleValue = 0,
                            UserGroupId = 1
                        },
                        new
                        {
                            Id = 2,
                            RuleValue = 1,
                            UserGroupId = 1
                        },
                        new
                        {
                            Id = 3,
                            RuleValue = 2,
                            UserGroupId = 1
                        },
                        new
                        {
                            Id = 4,
                            RuleValue = 3,
                            UserGroupId = 1
                        });
                });

            modelBuilder.Entity("RA.Database.Models.ClockItemCategory", b =>
                {
                    b.HasBaseType("RA.Database.Models.Abstract.ClockItemBase");

                    b.Property<int?>("ArtistSeparation")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFiller")
                        .HasColumnType("tinyint(1)");

                    b.Property<TimeSpan?>("MaxDuration")
                        .HasColumnType("time(6)");

                    b.Property<DateTime?>("MaxReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan?>("MinDuration")
                        .HasColumnType("time(6)");

                    b.Property<DateTime?>("MinReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("TitleSeparation")
                        .HasColumnType("int");

                    b.Property<int?>("TrackSeparation")
                        .HasColumnType("int");

                    b.HasIndex("CategoryId");

                    b.ToTable("ClockItems");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("RA.Database.Models.ClockItemEvent", b =>
                {
                    b.HasBaseType("RA.Database.Models.Abstract.ClockItemBase");

                    b.Property<TimeSpan?>("EstimatedEventDuration")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("EstimatedEventStart")
                        .HasColumnType("time(6)");

                    b.Property<string>("EventLabel")
                        .HasColumnType("longtext");

                    b.Property<int?>("EventType")
                        .HasColumnType("int");

                    b.ToTable("ClockItems");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("RA.Database.Models.ClockItemTrack", b =>
                {
                    b.HasBaseType("RA.Database.Models.Abstract.ClockItemBase");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasIndex("TrackId");

                    b.ToTable("ClockItems");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Categories_Tracks", b =>
                {
                    b.HasOne("RA.Database.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TrackCategories_CategoryId");

                    b.HasOne("RA.Database.Models.Track", null)
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TrackCategories_TrackId");
                });

            modelBuilder.Entity("RA.Database.Models.Abstract.ClockItemBase", b =>
                {
                    b.HasOne("RA.Database.Models.Clock", "Clock")
                        .WithMany("ClockItems")
                        .HasForeignKey("ClockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RA.Database.Models.ClockItemEvent", "ClockItemEvent")
                        .WithMany()
                        .HasForeignKey("ClockItemEventId");

                    b.Navigation("Clock");

                    b.Navigation("ClockItemEvent");
                });

            modelBuilder.Entity("RA.Database.Models.ArtistTrack", b =>
                {
                    b.HasOne("RA.Database.Models.Artist", "Artist")
                        .WithMany("ArtistTracks")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RA.Database.Models.Track", "Track")
                        .WithMany("TrackArtists")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("RA.Database.Models.Category", b =>
                {
                    b.HasOne("RA.Database.Models.Category", "CategoryParent")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentId");

                    b.Navigation("CategoryParent");
                });

            modelBuilder.Entity("RA.Database.Models.ClockItemCategoryTag", b =>
                {
                    b.HasOne("RA.Database.Models.ClockItemCategory", "ClockItemCategory")
                        .WithMany("ClockItemCategoryTags")
                        .HasForeignKey("ClockItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RA.Database.Models.TagValue", "TagValue")
                        .WithMany("ClockItemsCategoryTags")
                        .HasForeignKey("TagValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClockItemCategory");

                    b.Navigation("TagValue");
                });

            modelBuilder.Entity("RA.Database.Models.ClockTemplate", b =>
                {
                    b.HasOne("RA.Database.Models.Clock", "Clock")
                        .WithMany("ClockTemplates")
                        .HasForeignKey("ClockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RA.Database.Models.Template", "Template")
                        .WithMany("TemplateClocks")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clock");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("RA.Database.Models.Playlist", b =>
                {
                    b.HasOne("RA.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RA.Database.Models.PlaylistItem", b =>
                {
                    b.HasOne("RA.Database.Models.Playlist", "Playlist")
                        .WithMany("PlaylistItems")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RA.Database.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId");

                    b.Navigation("Playlist");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("RA.Database.Models.ScheduleDefaultItem", b =>
                {
                    b.HasOne("RA.Database.Models.ScheduleDefault", "Schedule")
                        .WithMany("ScheduleDefaultItems")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RA.Database.Models.Template", "Template")
                        .WithMany("ScheduleDefaultItems")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("RA.Database.Models.SchedulePlanned", b =>
                {
                    b.HasOne("RA.Database.Models.Template", "Template")
                        .WithMany("PlannedSchedules")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("RA.Database.Models.TagValue", b =>
                {
                    b.HasOne("RA.Database.Models.TagCategory", "TagCategory")
                        .WithMany("Values")
                        .HasForeignKey("TagCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TagCategory");
                });

            modelBuilder.Entity("RA.Database.Models.TrackHistory", b =>
                {
                    b.HasOne("RA.Database.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("RA.Database.Models.TrackTag", b =>
                {
                    b.HasOne("RA.Database.Models.TagValue", "TagValue")
                        .WithMany("TrackTags")
                        .HasForeignKey("TagValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RA.Database.Models.Track", "Track")
                        .WithMany("TrackTags")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TagValue");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("RA.Database.Models.User", b =>
                {
                    b.HasOne("RA.Database.Models.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("RA.Database.Models.UserGroupRule", b =>
                {
                    b.HasOne("RA.Database.Models.UserGroup", "UserGroup")
                        .WithMany("Rules")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("RA.Database.Models.ClockItemCategory", b =>
                {
                    b.HasOne("RA.Database.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RA.Database.Models.ClockItemTrack", b =>
                {
                    b.HasOne("RA.Database.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("RA.Database.Models.Artist", b =>
                {
                    b.Navigation("ArtistTracks");
                });

            modelBuilder.Entity("RA.Database.Models.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("RA.Database.Models.Clock", b =>
                {
                    b.Navigation("ClockItems");

                    b.Navigation("ClockTemplates");
                });

            modelBuilder.Entity("RA.Database.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistItems");
                });

            modelBuilder.Entity("RA.Database.Models.ScheduleDefault", b =>
                {
                    b.Navigation("ScheduleDefaultItems");
                });

            modelBuilder.Entity("RA.Database.Models.TagCategory", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("RA.Database.Models.TagValue", b =>
                {
                    b.Navigation("ClockItemsCategoryTags");

                    b.Navigation("TrackTags");
                });

            modelBuilder.Entity("RA.Database.Models.Template", b =>
                {
                    b.Navigation("PlannedSchedules");

                    b.Navigation("ScheduleDefaultItems");

                    b.Navigation("TemplateClocks");
                });

            modelBuilder.Entity("RA.Database.Models.Track", b =>
                {
                    b.Navigation("TrackArtists");

                    b.Navigation("TrackTags");
                });

            modelBuilder.Entity("RA.Database.Models.UserGroup", b =>
                {
                    b.Navigation("Rules");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("RA.Database.Models.ClockItemCategory", b =>
                {
                    b.Navigation("ClockItemCategoryTags");
                });
#pragma warning restore 612, 618
        }
    }
}
