using Blog.Core;
using Blog.Core.Interfaces;
using Blog.DAL.Interfaces;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DAL.Repository
{
    public class SubjectCategoryRepository : Repository<SubjectCategory, BlogDbContext>, ISubjectCategory
    {
        public SubjectCategoryRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
