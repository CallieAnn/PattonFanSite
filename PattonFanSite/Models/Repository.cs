using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PattonFanSite.Models
{
    public static class Repository
    {
        private static List<StoriesResponse> responses = new List<StoriesResponse>();
        public static IEnumerable<StoriesResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        public static void AddResponse(StoriesResponse response)
        {
            responses.Add(response);
        }
    }
}
