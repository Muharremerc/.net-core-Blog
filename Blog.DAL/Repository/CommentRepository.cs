using Blog.Core;
using Blog.DAL.Interfaces;
using Blog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.DAL.Repository
{
    public class CommentRepository : Repository<Comment, BlogDbContext>, IComment
    {
        private readonly BlogDbContext _blogDbContext;
        public CommentRepository(BlogDbContext dbContext) : base(dbContext)
        {
            _blogDbContext = dbContext;
        }

        public int getCommentCountBySubjectID(int id)
        {
            var CommentList = _blogDbContext.Comments.Where(x=>x.SubjectID==id).ToList();
            if (CommentList != null)
                return CommentList.Count;
            return 0;
        }

        public string getLastCommentBySubjectID(int id)
        {
            var Comment = _blogDbContext.Comments.Where(x => x.SubjectID == id).ToList();
            if (Comment.Count > 0)
                return Comment.Last().Content;
            return " ";
        }

        public int getLastCommentMembersBySubjectID(int id)
        {
            var Comment = _blogDbContext.Comments.Where(x => x.SubjectID == id).ToList();
            if (Comment.Count >0)
                return Comment.Last().MemberID;
            return 0;
        }

        
    }
}
