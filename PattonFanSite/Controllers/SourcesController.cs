using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PattonFanSite.Models;
using PattonFanSite.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PattonFanSite.Controllers
{
    public class SourcesController : Controller
    {
        Book b1;
        Book b2;
        Link l1;
        Link l2;

        public SourcesController()
        {
            if (Repository.Books.Count == 0)
            {
                b1 = new Book()
                {
                    Title = "The Perfect Horse",
                    Author = "Elizabeth Letts",
                    Description = "US mission to capture Lipizzan stallions taken by Nazis",
                    PubDate = new DateTime(2016, 8, 23),
                    Url = "https://www.amazon.com/Perfect-Horse-Priceless-Stallions-Kidnapped/dp/0345544803"
                };

                b2 = new Book()
                {
                    Title = "The Spanish Riding School of Vienna",
                    Author = "Colonel A. Podhajsky",
                    Description = "About the Spanish Riding School and Lipizzans",
                    PubDate = new DateTime(1964, 1, 1),
                    Url = "https://www.amazon.com/Spanish-Riding-School-Vienna/dp/B0007JMMHI/ref=sr_1_1?s=books&ie=UTF8&qid=1539382989&sr=1-1&keywords=%22The+Spanish+Riding+School+of+Vienna%22"

                };

                Repository.AddBook(b1);
                Repository.AddBook(b2);

            }

            if (Repository.Links.Count == 0)
            {
                l1 = new Link()
                {
                    Title = "United States Lipizzan Federation",
                    Url = "https://www.uslipizzan.org/",
                    Description = "Register your Lipizzan, learn about the breed, etc."
                    
                };

                l2 = new Link()
                {
                    Title = "Art to Ride",
                    Url = "https://art2ride.com/",
                    Description = "Classical foundation horse training"
                    
                };

                Repository.AddLink(l1);
                Repository.AddLink(l2);
            }
        }
        

        public ViewResult Sources()
        {
            return View();
        }

        public ViewResult Books()
        {
            List<Book> books = Repository.Books;
            books.Sort((b1, b2) => string.Compare(b1.Title, b2.Title, StringComparison.Ordinal));
            return View(books);
        }

        public ViewResult Online()
        {
            List<Link> links = Repository.Links;
            links.Sort((l1, l2) => string.Compare(l1.Title, l2.Title, StringComparison.Ordinal));
            return View(links);
        }


    }
}
