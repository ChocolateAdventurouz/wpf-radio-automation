﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RA.Database;

#nullable disable

namespace RA.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230602102046_Added_SchedulePlanned_DaysFlags")]
    partial class Added_SchedulePlanned_DaysFlags
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("RA.Database.Models.ClockItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ArtistSeparation")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ClockId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("EstimatedEventDuration")
                        .HasColumnType("time(6)");

                    b.Property<string>("EventLabel")
                        .HasColumnType("longtext");

                    b.Property<int?>("EventType")
                        .HasColumnType("int");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int");

                    b.Property<int?>("TitleSeparation")
                        .HasColumnType("int");

                    b.Property<int?>("TrackId")
                        .HasColumnType("int");

                    b.Property<int?>("TrackSeparation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClockId");

                    b.HasIndex("TrackId");

                    b.ToTable("ClockItems");
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

                    b.Property<bool>("IsFriday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsMonday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSaturday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSunday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsThursday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsTuesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsWednesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("TemplateId")
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
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

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

                    b.Property<string>("Lyrics")
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

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

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
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
                });

            modelBuilder.Entity("RA.Database.Models.UserRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RuleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("UserRules");
                });

            modelBuilder.Entity("UserGroups_UserRules", b =>
                {
                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserRuleId")
                        .HasColumnType("int");

                    b.HasKey("UserGroupId", "UserRuleId");

                    b.HasIndex("UserRuleId");

                    b.ToTable("UserGroups_UserRules");
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

            modelBuilder.Entity("RA.Database.Models.ClockItem", b =>
                {
                    b.HasOne("RA.Database.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("RA.Database.Models.Clock", "Clock")
                        .WithMany("ClockItems")
                        .HasForeignKey("ClockId");

                    b.HasOne("RA.Database.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId");

                    b.Navigation("Category");

                    b.Navigation("Clock");

                    b.Navigation("Track");
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
                        .WithMany("Playlists")
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
                    b.HasOne("RA.Database.Models.Template", null)
                        .WithMany("PlannedSchedules")
                        .HasForeignKey("TemplateId");
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
                    b.HasOne("RA.Database.Models.UserGroup", null)
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId");
                });

            modelBuilder.Entity("UserGroups_UserRules", b =>
                {
                    b.HasOne("RA.Database.Models.UserGroup", null)
                        .WithMany()
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserGroupsUserRules_UserGroupId");

                    b.HasOne("RA.Database.Models.UserRule", null)
                        .WithMany()
                        .HasForeignKey("UserRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserGroupsUserRules_UserRuleId");
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

            modelBuilder.Entity("RA.Database.Models.User", b =>
                {
                    b.Navigation("Playlists");
                });

            modelBuilder.Entity("RA.Database.Models.UserGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
