using Blog.Core;
using Blog.Core.Interfaces;
using Blog.DAL.Interfaces;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DAL.Repository
{
    public class CategoryRepository : Repository<Category, BlogDbContext>, ICategory
    {
        public CategoryRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
