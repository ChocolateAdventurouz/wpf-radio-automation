﻿using RA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DAL.Interfaces
{
    public interface IClocksService
    {
        IEnumerable<ClockDto> GetClocks();
        Task<IEnumerable<ClockDto>> GetClocksAsync();
        IEnumerable<ClockItemDto> GetClockItems(int clockId);
        Task<IEnumerable<ClockItemDto>> GetClockItemsAsync(int clockId);
        Task<Dictionary<int, TimeSpan>> CalculateAverageDurationsForCategoriesInClockWithId(int clockId);
    }
}
