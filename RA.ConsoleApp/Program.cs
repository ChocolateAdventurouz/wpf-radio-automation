﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RA.DAL;
using RA.Database;
using RA.Database.Models;
using RA.DTO;
using RA.Logic.PlanningLogic;

namespace RA.ConsoleApp
{
    public class DbContextFactory : IDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<AppDbContext> optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            String connString = "server=localhost;Port=3306;database=raprod;user=root;password=";
            DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptions<AppDbContext>();

            dbContextOptions = optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString))
                .EnableSensitiveDataLogging(false)
                .Options;
            return new AppDbContext(dbContextOptions);
        }
    }
    public class Program
    {
        static DbContextFactory dbFactory = new DbContextFactory();
        static void Main(string[] args)
        {
            //TestPlaylistGenerator();
            //SchedulesPlannedService schedulesPlannedService = new SchedulesPlannedService(dbFactory);
            //_ = schedulesPlannedService.AddPlannedSchedule(new SchedulePlannedDTO()
            //{
            //    StartDate = new DateTime(2023, 6, 9),
            //    Type = SchedulePlannedType.OneTime,
            //    Template = new TemplateDTO("") { Id = 1}

            //});
            //_ = schedulesPlannedService.GetPlannedSchedulesOverviewAsync(DateTime.Now.AddDays(-20).Date,DateTime.Now.Date);


            //TagsService tagsService = new TagsService(dbFactory);
            //_ = tagsService.AddTagValue("Language", "French");
            var db = dbFactory.CreateDbContext();
            var query = from t in db.Tracks
                        select t;
            var tracks = query.ToList();
        }

       static void TestPlaylistGenerator()
        {
            IPlaylistGenerator playlistGenerator = new PlaylistGenerator(
                new PlaylistsService(dbFactory),
                new TracksService(dbFactory),
                new ClocksService(dbFactory),
                new TemplatesService(dbFactory),
                new SchedulesService(new SchedulesDefaultService(dbFactory),
                new SchedulesPlannedService(dbFactory))
                );
                ;

            var playlist = playlistGenerator.GeneratePlaylistForDate(new DateTime(2023,6,9));
        }
        
    }
}