using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PattonFanSite.Models
{
    public class Story
    {
        private List<Comment> comments = new List<Comment>();
        private List<Rating> ratings = new List<Rating>();

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string StoryText { get; set; }
        public User Contributor { get; set; }
        public List<Comment> Comments { get { return comments; } }
        public List<Rating> Ratings { get { return ratings; } }
    }
}
