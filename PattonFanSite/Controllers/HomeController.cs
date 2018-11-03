using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PattonFanSite.Models;
using System.Web;
using PattonFanSite.Repositories;




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
                repo.AddStory(storiesResponse);
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
            ViewBag.FakeName = "Clementine Lewis";
            ViewBag.FakeComment = "That's interesting.";
            List<Story> stories = repo.Stories;
            stories.Sort((s1, s2) => string.Compare(s1.Title, s2.Title, StringComparison.Ordinal));
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
            story.Comments.Add(new Comment()
            {
                Contributor = new User() { Name = contributor },
                CommentText = commentText
            });
            return RedirectToAction("Stories");
        }
    }
}
