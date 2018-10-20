using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PattonFanSite.Models;
using System.Web;




namespace PattonFanSite.Controllers
{
    public class HomeController : Controller
    {
        Story story;
        Story storyA;

        public HomeController()
        {
            if (Repository.Responses.Count == 0)
            {
                story = new Story()
                {
                    Name = "Sam",
                    Title = "Patton's first day",
                    Date = "3/28/17",
                    StoryText = "asdfadf"

                };

                storyA = new Story()
                {
                    Name = "Meghan",
                    Title = "Guess Who Ate the Pansies",
                    Date = "7/28/18",
                    StoryText = "Bye bye pansies, you taste too good to last long"

                };
                Repository.AddResponse(story);
                Repository.AddResponse(storyA);
            }


        }
        public ViewResult Index()
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
                Repository.AddResponse(storiesResponse);
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
            List<Story> stories = Repository.Responses;
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
            Story story = Repository.GetStoryByTitle(title);
            story.Comments.Add(new Comment()
            {
                Contributor = new User() { Name = contributor },
                CommentText = commentText
            });
            return RedirectToAction("Stories");
        }
    }
}
