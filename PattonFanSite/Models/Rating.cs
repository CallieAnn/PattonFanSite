using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PattonFanSite.Models
{
    public class Rating
    {
        public int UserRating { get; set; }
        public User Contributor { get; set; }
    }
}
