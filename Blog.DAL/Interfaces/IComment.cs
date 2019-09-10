using Blog.Core.Interfaces;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DAL.Interfaces
{
    public interface IComment:IRepository<Comment, BlogDbContext>
    {
        int getCommentCountBySubjectID(int id);
        int getLastCommentMembersBySubjectID(int id);
        string getLastCommentBySubjectID(int id);
    }
}
