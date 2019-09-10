using Blog.Core;
using Blog.DAL.Interfaces;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DAL.Repository
{
    public class MemberRepository : Repository<Member, BlogDbContext>, IMember
    {
        public MemberRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }
       
    }
}
