﻿using RA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DAL
{
    public interface IPlaylistsService
    {
        Task AddPlaylistAsync(PlaylistDTO playlistDTO);
    }
}
