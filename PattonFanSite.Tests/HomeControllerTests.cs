using System;
using Xunit;
using PattonFanSite.Models;
using PattonFanSite.Controllers;
using PattonFanSite.Repositories;

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

        }

        [Fact]
        public void AddComment()
        {

        }

        [Fact]
        public void PostAddComment()
        {

        }
    }
}
