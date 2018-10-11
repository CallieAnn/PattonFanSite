using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PattonFanSite.Models
{
    public static class Repository
    {
        private static List<Story> responses = new List<Story>();
        private static List<Book> books = new List<Book>();
        private static List<Link> links = new List<Link>();
 
        public static List<Story> Responses { get { return responses; } }
        public static List<Book> Books { get { return books; } }
        public static List<Link> Links { get { return links; } }


        public static void AddResponse(Story response)
        {
            responses.Add(response);
        }

        public static void AddBook(Book book)
        {
            books.Add(book);
        }

        public static void AddLink(Link link)
        {
            links.Add(link);
        }
    }
}
