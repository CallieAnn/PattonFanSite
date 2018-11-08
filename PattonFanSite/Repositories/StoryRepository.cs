﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PattonFanSite.Models;

namespace PattonFanSite.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private AppDbContext context;
        private List<Story> stories = new List<Story>();
        public List<Story> Stories { get { return stories; } }

        public StoryRepository()
        {
            AddFakeData();

        }

        public void AddStory(Story story)
        {
            stories.Add(story);
        }

        public Story GetStoryByTitle(string title)
        {
            Story story = stories.Find(s => s.Title == title);
            return story;
        }

        public void AddFakeData()
        {
            Story story = new Story()
            {
                Name = "Sam",
                Title = "Patton's first day",
                Date = "3/28/17",
                StoryText = "asdfadf"

            };

            Story storyA = new Story()
            {
                Name = "Meghan",
                Title = "Guess Who Ate the Pansies",
                Date = "7/28/18",
                StoryText = "Bye bye pansies, you taste too good to last long"

            };
            stories.Add(story);
            stories.Add(storyA);
        }

    }
}
