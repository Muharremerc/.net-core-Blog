using Blog.Core;
using Blog.DAL.Interfaces;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DAL.Repository
{
    public class SubjectRepository : Repository<Subject, BlogDbContext>, ISubject
    {
        public SubjectRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
