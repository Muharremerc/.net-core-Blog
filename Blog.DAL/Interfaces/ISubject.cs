using Blog.Core.Interfaces;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DAL.Interfaces
{
    public interface ISubject : IRepository<Subject, BlogDbContext>
    {
    }
}
