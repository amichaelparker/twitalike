using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twiter.Data;
using Twiter.Models;
using Twiter.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Twiter.Controllers
{
    public class AddController : Controller
    {
        private PostContext context;

        public AddController(PostContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/");
            }

            return View();
        }

        public IActionResult Add()
        {
            AddPostViewModel addPostViewModel = new AddPostViewModel();
            return View(addPostViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddPostViewModel addPostViewModel)
        {
            if (ModelState.IsValid)
            {
                Post newPost = new Post
                {
                    UserName = User.Identity.Name,
                    PostTitle = addPostViewModel.Title,
                    PostData = addPostViewModel.Post,
                    PostDate = DateTime.Now,
                };

                context.Posts.Add(newPost);
                context.SaveChanges();

                return Redirect("/");
            }

            return View(addPostViewModel);
        }
    }
}