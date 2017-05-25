using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Twiter.Models
{
    public class Follow
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public string FollowedName { get; set; }
    }
}
