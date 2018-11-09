﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PattonFanSite.Models;

namespace PattonFanSite.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private AppDbContext context;
        private List<Story> stories = new List<Story>();
        public List<Story> Stories { get { return context.Stories.Include("Comments").ToList(); } }

        public StoryRepository(AppDbContext appDbContext)
        {
            context = appDbContext;

        }

        public void AddStory(Story story, User u)
        {
            
            context.Stories.Add(story);
            context.Users.Add(u);
            //context.Stories.Update(story);
            context.SaveChanges();
        }

        public Story GetStoryByTitle(string title)
        {
            Story story = context.Stories.First(s => s.Title == title);
            return story;
        }

        public void AddComment(Story story, Comment comment)
        {
            story.Comments.Add(comment);
           
            context.Stories.Update(story);
            context.SaveChanges();

        }

    }
}
