﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PattonFanSite.Models;
using System.Web;
using PattonFanSite.Repositories;
using System.Linq;




namespace PattonFanSite.Controllers
{
    public class HomeController : Controller
    {
        IStoryRepository repo;

        public HomeController(IStoryRepository s)
        {
            repo = s;
        }

        public IActionResult Index()
        {
            return View("MainView");
        }

        public ViewResult History()
        {
            return View();
        }

        [HttpGet]
        public ViewResult StoriesForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult StoriesForm(Story storiesResponse)
        {
           
            if (ModelState.IsValid)
            { 
                //create new user for name entered in story form
                User u = new User()
                {
                    Name = storiesResponse.Name
                };

                //add story and corresponding user to repository
                repo.AddStory(storiesResponse, u);
                
                return View("Thanks", storiesResponse);
            }

            else
            {
                //validation error
                return View();
            }
        }

        public ViewResult Stories()
        {
            List<Story> stories = repo.Stories;
            stories.Sort((s1, s2) => string.Compare(s1.Title, s2.Title, StringComparison.Ordinal));
            return View(stories);
        }

        [HttpPost]
        public IActionResult Stories(string title, string comment)
        {
            List<Story> stories = new List<Story>();
            if (!string.IsNullOrWhiteSpace(title))
            {
                var matchTitleStories = (from s in repo.Stories
                                       where s.Title == title
                                       select s).ToList();

                if(matchTitleStories != null)
                {
                    stories = matchTitleStories;
                }
            }

            else if(!string.IsNullOrWhiteSpace(comment))
            {
                var matchCommentStories = repo.Stories.Where(story =>
                {
                    var storyComment = story.Comments.Where(sComment =>
                    {
                        return sComment.CommentText == comment;
                    }).ToList();
                   
                    return story.Comments.Contains(storyComment.FirstOrDefault());
                 
                }).ToList();

                if (matchCommentStories != null)
                {
                    stories = matchCommentStories;
                }
            }

            return View(stories);
        }


            public IActionResult AddComment(string title)
        {
            return View("AddComment", HttpUtility.HtmlDecode(title));
            
        }

        [HttpPost]
        public RedirectToActionResult AddComment(string title,
                                                string commentText,
                                                string contributor)
        {
            Story story = repo.GetStoryByTitle(title);
            repo.AddComment(story, new Comment()
            {
                Contributor = new User() { Name = contributor },
                CommentText = commentText
            });
            return RedirectToAction("Stories");
        }
    }
}
