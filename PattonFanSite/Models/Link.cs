﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PattonFanSite.Models
{
    public class Link
    {
        public int LinkId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
