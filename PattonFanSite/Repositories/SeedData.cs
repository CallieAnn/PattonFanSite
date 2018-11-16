using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PattonFanSite.Models;
using Microsoft.EntityFrameworkCore;

namespace PattonFanSite.Repositories
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            context.Database.Migrate();

            if (!context.Stories.Any())
            {
                User u = new User();
                Story s = new Story
                {
                    Name = "Sammy",
                    Title = "Conversano Ballesta",
                    Date = "10/10/18",
                    StoryText = "One day..."
                };
                u.Name = s.Name;

                u.Stories.Add(s);

                User u2 = new User
                {
                    Name = "Matthew"
                };

                Comment c = new Comment
                {
                    CommentText = "C'est pas faux",
                    Contributor = u2
                };

                s.Comments.Add(c);

                context.Users.Add(u);
                context.Users.Add(u2);
                
                context.Stories.Add(s);
                context.Comments.Add(c);

                context.SaveChanges();
            }
        }
    }
}
