using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PattonFanSite.Models
{
    public static class Repository
    {
        private static List<Story> responses = new List<Story>();
 
        public static List<Story> Responses { get { return responses; } }
    

        public static void AddResponse(Story response)
        {
            responses.Add(response);
        }
    }
}
