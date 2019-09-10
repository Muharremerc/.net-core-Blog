using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entity
{
    public class SubjectCategory : BaseClass
    {
        public int CategoryID { get; set; }
        public int SubjectID { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Category Category { get; set; }
    }
}
