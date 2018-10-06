using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PattonFanSite.Models
{
    public class User
    {
        private List<Story> stories = new List<Story>();
        private List<Comment> comments = new List<Comment>();
        private List<Rating> ratings = new List<Rating>();

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Story> Stories { get { return stories; } }
        public List<Comment> Comments { get { return comments; } }
        public List<Rating> Ratings { get { return ratings; } }



        
        
    }
}
