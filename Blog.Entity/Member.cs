using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Entity
{
    public class Member : BaseClass
    {
        public Member()
        {
            Subjects = new HashSet<Subject>();
        }
        [Required(ErrorMessage = "Please enter Name")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Surname")]
        [Display(Name = "Surname")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter Phone")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter Header")]
        [Display(Name = "EMail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Username")]
        [Display(Name = "Username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter Information")]
        [Display(Name = "Information")]
        [StringLength(50)]
        public string Information { get; set; }

        public virtual ICollection<Subject>  Subjects { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
