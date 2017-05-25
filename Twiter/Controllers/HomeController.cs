using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twiter.Models;
using Twiter.Data;
using Microsoft.EntityFrameworkCore;
namespace Twiter.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostContext context;

        public HomeController(PostContext dbContext)
        {
            context = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.follows = context.Follows.SingleOrDefault(f => f.UserName == User.Identity.Name);
                //IList<Follow> follows = context.Follows.ToList();
                return View(await context.Posts.ToListAsync());
            } else
            {
                //ViewBag.follows = context.Follows.SingleOrDefault(f => f.UserName == User.Identity.Name).ToString();
                //IList<Post> posts = context.Posts.ToList();
                return View(await context.Posts.ToListAsync());
            }
        }

        public void AddFollow(string userName, string followedName)
        {
            var currentUser = context
            .Follows
            .SingleOrDefault(u => u.UserName == userName);

            if (currentUser == null)
            {
                var n = new Follow();
                n.UserName = userName;
                n.FollowedName = followedName;

                context.Follows.Add(n);
                context.SaveChanges();
            }

            if (currentUser != null && !currentUser.FollowedName.Contains(followedName) && userName != followedName)
            {
                currentUser.FollowedName = String.Concat(currentUser.FollowedName, ",", followedName);
                context.Follows.Attach(currentUser);
                var entry = context.Entry(currentUser);
                entry.Property(e => e.FollowedName).IsModified = true;
                context.SaveChanges();
            }
        }

        public void RemoveFollow(string userName, string followedName)
        {
            var currentUser = context
            .Follows
            .SingleOrDefault(u => u.UserName == userName);

            if (currentUser != null && currentUser.FollowedName.Contains(followedName))
            {
                var currentFollows = currentUser.FollowedName;
                currentUser.FollowedName = currentFollows.Replace(followedName, userName);
                context.Follows.Attach(currentUser);
                var entry = context.Entry(currentUser);
                entry.Property(e => e.FollowedName).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
