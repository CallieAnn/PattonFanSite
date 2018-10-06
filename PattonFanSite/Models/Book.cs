using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PattonFanSite.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
    }
}
