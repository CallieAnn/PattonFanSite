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
        void AddStory(Story story);
        Story GetStoryByTitle(string Title);
    }
}
