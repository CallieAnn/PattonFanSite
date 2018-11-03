using System;
using Xunit;
using PattonFanSite.Models;
using PattonFanSite.Controllers;
using PattonFanSite.Repositories;
using System.Collections.Generic;

namespace PattonFanSite.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void StoriesForm()
        {
            //Arrange
            var repo = new FakeStoryRepository();
            var controller = new HomeController(repo);
            Story s = new Story()
            {
                Name = "TestStory",
                Title = "TheTitle",
                Date = "1/5/18",
                StoryText = "Here is the story."
            };

            //Act
            controller.StoriesForm(s);

            //Assert
            Assert.Equal("TestStory", repo.Stories[repo.Stories.Count - 1].Name);

        }

        [Fact]
        public void Stories()
        {
            //tests to see that the view receives a list of stories sorted by title
            var repo = new FakeStoryRepository();
            var controller = new HomeController(repo);

            var result = controller.Stories();
            var model = ((Microsoft.AspNetCore.Mvc.ViewResult)result).Model as List<Story>;

            Assert.Equal("Guess Who Ate the Pansies", model[0].Title);

        }

        [Fact]
        public void AddComment()
        {
            var repo = new FakeStoryRepository();
            var controller = new HomeController(repo);

            Story s = repo.GetStoryByTitle("Patton's first day");
            

            var result = controller.AddComment(s.Title);
            var model = ((Microsoft.AspNetCore.Mvc.ViewResult)result).Model as String;

            Assert.Equal("Patton's first day", model);

        }

        [Fact]
        public void PostAddComment()
        {
            var repo = new FakeStoryRepository();
            var controller = new HomeController(repo);

            User u = new User
            {
                Name = "Fake User"
            };

            Comment c = new Comment()
            {
                CommentText = "Test Comment",
                Contributor = u,
            };

            controller.AddComment("Patton's first day", c.CommentText, c.Contributor.Name);

            Assert.Equal("Fake User", repo.Stories[0].Comments[0].Contributor.Name);
        }
    }
}
