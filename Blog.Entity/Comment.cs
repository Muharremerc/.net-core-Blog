using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entity
{
    public class Comment : BaseClass
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public int MemberID { get; set; }
        public int SubjectID { get; set; }
        public bool Accepted { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Member Member { get; set; }
    }
}
