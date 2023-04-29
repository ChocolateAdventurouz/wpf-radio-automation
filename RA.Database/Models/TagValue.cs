﻿using RA.Database.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Database.Models
{
    public class TagValue : BaseModel
    {
        public String Name { get; set; }
        public int TagCategoryId { get; set; }
        public TagCategory TagCategory { get; set; }

        public ICollection<TrackTag> TrackTags { get; set; }
    }
}
