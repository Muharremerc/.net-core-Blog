using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Entity
{
    public class Subject : BaseClass
    {
        public Subject()
        {
            Comments = new HashSet<Comment>();
            SubjectCategories = new HashSet<SubjectCategory>();
        }
        [Required(ErrorMessage = "Please enter Header")]
        [Display(Name = "Header")]
        [StringLength(50)]
        public string Header { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public int MemberID { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SubjectCategory> SubjectCategories { get; set; }
    }
}
