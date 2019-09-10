using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.UI.Models
{
    public class MemberViewSubjectDTO
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public int CommentCount { get; set; }
        public string LastMember { get; set; }
        public string LastComment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
