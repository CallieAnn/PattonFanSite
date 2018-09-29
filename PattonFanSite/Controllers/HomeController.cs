using System;
using Microsoft.AspNetCore.Mvc;
using PattonFanSite.Models;


namespace PattonFanSite.Controllers
{
    public class HomeController : Controller
    {
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
        public ViewResult StoriesForm(StoriesResponse storiesResponse)
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
    }
}
