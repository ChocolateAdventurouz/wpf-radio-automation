﻿using RA.Database.Models;
using RA.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DTO
{
    public class ClockItemCategoryDTO : ClockItemBaseDTO
    {
        public int? CategoryId { get; set; }
        public String? CategoryName { get; set; }
        public int? ArtistSeparation { get; set; }
        public int? TitleSeparation { get; set; }
        public int? TrackSeparation { get; set; }

        public static ClockItemCategoryDTO FromEntity(ClockItemCategory entity)
        {
            return new ClockItemCategoryDTO
            {
                OrderIndex = entity.OrderIndex,
                ClockId = entity.ClockId,
                Clock = entity.Clock,
                CategoryId = entity.CategoryId,
                CategoryName = entity.Category?.Name,
                ArtistSeparation = entity.ArtistSeparation,
                TitleSeparation = entity.TitleSeparation,
                TrackSeparation = entity.TrackSeparation
            };
        }
    }
}
