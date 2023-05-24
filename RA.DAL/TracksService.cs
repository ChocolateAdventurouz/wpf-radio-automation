﻿using Microsoft.EntityFrameworkCore;
using RA.DAL;
using RA.Database;
using RA.Database.Models;
using RA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DAL
{
    public class TracksService : ITracksService
    {
        private readonly IDbContextFactory<AppDbContext> dbContextFactory;

        public TracksService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<int> GetTrackCountAsync()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return await dbContext.Tracks.CountAsync();
            }
        }

        public async Task<IEnumerable<TrackListingDTO>> GetTrackListAsync(int skip, int take)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
                return await dbContext.GetTracks()
                    .Skip(skip)
                    .Take(take)
                    .Select(t => TrackListingDTO.FromEntity(t))
                    .ToListAsync();
            
        }

        public IEnumerable<TrackListingDTO> GetTrackList(int skip, int take)
        {
            return GetTrackListAsync(skip, take).Result;
        }

        public async Task<TrackDTO> GetTrack(int id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.GetTrackById(id)
                .Include(c => c.Categories)
                .Select(t => TrackDTO.FromEntity(t))
                .FirstAsync();
        }

        public async Task UpdateTrack(TrackDTO trackDTO)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            Track track = TrackDTO.ToEntity(trackDTO);

            var existingCategories = await dbContext
                .Tracks.Where(t => t.Id == track.Id)
                .SelectMany(t => t.Categories)
                .ToListAsync();

            foreach(var category in existingCategories)
            {
                var toRemove = track.Categories.Where(c => c.Id == category.Id).FirstOrDefault();
                if (toRemove != null)
                {
                    track.Categories.Remove(toRemove);
                }
            }

            dbContext.Tracks.Update(track);
            
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrackListingDTO>> GetTrackListByArtistAsync(int artistId, int skip, int take)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.GetTracks()
                .Skip(skip).Take(take)
                .Where(t => t.TrackArtists.Contains(new ArtistTrack
                {
                    ArtistId = artistId,
                    TrackId = t.Id,
                }))
                .Select(t => TrackListingDTO.FromEntity(t))
                .ToListAsync();
        }

        public IEnumerable<TrackListingDTO> GetTrackListByArtist(int artistId, int skip, int take)
        {
            return GetTrackListByArtistAsync(artistId, skip, take).Result;
        }

        public async Task<IEnumerable<TrackListingDTO>> GetTrackListByCategoryAsync(int categoryId, int skip, int take)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.GetTracks()
                .Skip(skip).Take(take)
                .Where(t => t.Categories.Contains(new Category()
                {
                    Id = categoryId,
                }))
                .Select(t => TrackListingDTO.FromEntity(t))
                .ToListAsync();
        }

        public async Task<int> AddTracks(IEnumerable<TrackDTO> trackDTOs)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var tracks = trackDTOs.Select(t => TrackDTO.ToEntity(t)).ToList();
            foreach(var t in tracks)
            {
                var categories = t.Categories.ToList();
                for(int i = 0; i < categories.Count; i++)
                {
                    categories[i] = dbContext.AttachOrGetTrackedEntity<Category>(categories[i]);
                }
                t.Categories = categories;

            }
            dbContext.Tracks.AddRange(tracks);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> TrackExistsByPath(String filePath)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var query = dbContext.Tracks
                .Where(t => t.FilePath == filePath)
                .Select(t => t.FilePath);
            return await query.AnyAsync();
        }

        private static readonly Random random = new Random();
        public async Task<TrackListingDTO?> GetRandomTrack(int categoryId, List<int>? trackIdsToExclude = null)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var noOfTracksQuery = dbContext.Tracks.Include(t => t.Categories)
                .Where(t => t.Categories.Contains(new Category() { Id = categoryId }))
                .AsQueryable();

            var query = dbContext.Tracks.Include(t => t.Categories)
                .Include(t => t.TrackArtists)
                .ThenInclude(ta => ta.Artist)
                .Where(t => t.Categories.Contains(new Category() { Id = categoryId }));

            if (trackIdsToExclude != null)
            {
                query = query.Where(t => !trackIdsToExclude.Contains(t.Id));
                noOfTracksQuery = noOfTracksQuery.Where(t => !trackIdsToExclude.Contains(t.Id));
            }

            var noOfTracks = await noOfTracksQuery.CountAsync();


            var track = await query.Skip(random.Next(noOfTracks))
                .Take(1)
                .Select(t => TrackListingDTO.FromEntity(t))
                .FirstOrDefaultAsync();
            return track;
        }

        

        
    }
}
