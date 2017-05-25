using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twiter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Twiter.Data
{
    public class DbInitializer
    {
        public static void Initialize(PostContext context)
        {
            context.Database.EnsureCreated();

            if (context.Posts.Any())
            {
                return;
            }


            //context.Posts.Add(
            //    new Post
            //    {
            //        Name = "Captain Placeholder",
            //        PostTitle = "First Post",
            //        PostData = "The very first entry!",
            //        PostDate = DateTime.UtcNow,
            //    });
            //context.SaveChanges();

        }
    }
}
