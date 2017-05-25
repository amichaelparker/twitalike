using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twiter.ViewModels
{
    public class AddPostViewModel
    {
        [Required]
        [Display(Name = "Post Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Post")]
        [MinLength(5)]
        [MaxLength(120)]
        public string Post { get; set; }

        public AddPostViewModel()
        {
        }
    }
}
