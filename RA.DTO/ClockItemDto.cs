﻿using RA.Database.Models;
using RA.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DTO
{
    public class ClockItemDTO
    {
        public int Id { get; set; }
        public int OrderIndex { get; set; }
        public int? TrackId { get; set; }

        #region Category
        public int? CategoryId { get; set; }
        public String? CategoryName { get; set; }

        public int? ArtistSeparation { get; set; }
        public int? TitleSeparation { get; set; }
        public int? TrackSeparation { get; set; }

        #endregion

        #region Event
        public EventType? EventType { get; set; }
        public string? EventLabel { get; set; }
        public TimeSpan? EstimatedEventDuration { get; set; }

        #endregion
        public int? ClockId { get; set; }

        

        public static ClockItemDTO FromEntity(ClockItem clockItem)
        {
            return new ClockItemDTO
            {
                Id = clockItem.Id,
                TrackId = clockItem.TrackId,
                CategoryId = clockItem.CategoryId,
                CategoryName = clockItem.Category?.Name ?? String.Empty,
                ArtistSeparation = clockItem.ArtistSeparation,
                TitleSeparation = clockItem.TitleSeparation,
                TrackSeparation = clockItem.TrackSeparation,
                EventType = clockItem.EventType,
                EventLabel = clockItem.EventLabel,
                EstimatedEventDuration = clockItem.EstimatedEventDuration,
                ClockId = clockItem.ClockId,
                OrderIndex = clockItem.OrderIndex,
            };
        }

        public static ClockItem ToEntity(ClockItemDTO clockItemDto)
        {
            return new ClockItem
            {
                TrackId = clockItemDto.TrackId,
                CategoryId = clockItemDto.CategoryId,
                ClockId = clockItemDto?.ClockId,
                OrderIndex = clockItemDto.OrderIndex,
                ArtistSeparation = clockItemDto.ArtistSeparation,
                TitleSeparation = clockItemDto.TitleSeparation,
                TrackSeparation = clockItemDto.TrackSeparation,
                EventType= clockItemDto.EventType,
                EventLabel = clockItemDto.EventLabel,
                EstimatedEventDuration= clockItemDto.EstimatedEventDuration,
            };
        }
    }
}
