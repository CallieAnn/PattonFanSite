using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PattonFanSite.Models;




namespace PattonFanSite.Controllers
{
    public class HomeController : Controller
    {
        Story story;

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
                Repository.AddResponse(story);
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
            List<Story> stories = Repository.Responses;
            return View(stories);
        }
    }
}
