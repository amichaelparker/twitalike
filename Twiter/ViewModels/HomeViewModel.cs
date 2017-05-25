using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twiter.Models;

namespace Twiter.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Post> Posts { get; private set; }

        public HomeViewModel(IEnumerable<Post> post)
        {
            Posts = post;
        }
    }
}
