using Blog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entity
{
    public class Category:BaseClass
    {
        public Category()
        {
            SubjectCategories = new HashSet<SubjectCategory>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }

        public virtual ICollection<SubjectCategory> SubjectCategories { get; set; }
    }
}
