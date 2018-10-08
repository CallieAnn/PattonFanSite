using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PattonFanSite.Models
{
    public class Story
    {
        private List<Comment> comments = new List<Comment>();
        private List<Rating> ratings = new List<Rating>();

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Please enter a story")]
        public string StoryText { get; set; }

        public List<Comment> Comments { get { return comments; } }
        public List<Rating> Ratings { get { return ratings; } }
    }
}
