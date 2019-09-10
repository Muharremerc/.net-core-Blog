
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Core.Interfaces
{
    public interface IRepository<T,DBContext> where T :  IEntity where DBContext :DbContext 
    {
        int Add(T entity);
        T Get(int id);
        T Get(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Delete(int id);
        ICollection<T> All();
        ICollection<T> Find(Expression<Func<T, bool>> predicate);
    }
}