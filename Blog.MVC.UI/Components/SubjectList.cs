using Blog.DAL.Interfaces;
using Blog.Entity;
using Blog.MVC.UI.Helper;
using Blog.MVC.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.UI.Components
{
    public class SubjectList: ViewComponent
    {
        private readonly ISubject _subject;
        private readonly IComment _comment;
        private readonly IMember _member;
        public SubjectList(ISubject subject, IComment comment, IMember member)
        {
            _subject = subject;
            _comment = comment;
            _member = member;
        }

        public IViewComponentResult Invoke()
        {
            List<MemberViewSubjectDTO> memberViewSubjectDTO;
            var tempmember = HttpContext.Session.GetObjectFromJson<Member>("Member");
            if (tempmember != null)
            {
                var memberSubjectList = _subject.All().Where(x => x.MemberID == tempmember.ID);
                if (memberSubjectList != null)
                {
                    string tempLastComment =null;
                    memberViewSubjectDTO = new List<MemberViewSubjectDTO>();
                    foreach (var item in memberSubjectList)
                    {
                        tempLastComment = _comment.getLastCommentBySubjectID(item.ID);
                        memberViewSubjectDTO.Add(new MemberViewSubjectDTO
                        {
                            ID=item.ID,
                            CommentCount= _comment.getCommentCountBySubjectID(item.ID),
                            Content= (item.Content.Length < 50) ? item.Content : item.Content.Substring(0, item.Content.Length % 50),
                            CreatedDate =item.CreatedDate,
                            Description=item.Description,
                            Header=item.Header,
                            LastComment= (tempLastComment.Length < 50) ? tempLastComment : tempLastComment.Substring(0, tempLastComment.Length % 40),
                            LastMember =(_comment.getLastCommentMembersBySubjectID(item.ID)!=0)? _member.Get(_comment.getLastCommentMembersBySubjectID(item.ID)).Name:"No Comment"
                        });
                    }
                    return View(memberViewSubjectDTO.AsQueryable());
                }
                return View();
            }
            return View();
        }
    }
}
