using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections;

namespace Twiter.Models
{
    public class Post
    {
        //private int counter = 1;
        public string PostId { get; set; }
        [ForeignKey("UserName")]
        public string UserName { get; set; }
        public string PostTitle { get; set; }
        public string PostData { get; set; }
        public DateTime PostDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Follow { get; set; }
    }
}
