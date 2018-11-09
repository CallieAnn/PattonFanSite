using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PattonFanSite.Models;

namespace PattonFanSite.Repositories
{
    public interface IStoryRepository
    {
        List<Story> Stories { get; }
        void AddStory(Story story, User user);
        Story GetStoryByTitle(string Title);
        void AddComment(Story story, Comment comment);
    }
}
