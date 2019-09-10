using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.UI.Models
{
    public class SubjectViewDTO
    {
        [Required(ErrorMessage = "Please enter Header")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Please enter Header")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Please enter Header")]
        public string Description { get; set; }
    }
}
