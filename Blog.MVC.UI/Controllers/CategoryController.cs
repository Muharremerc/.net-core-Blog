using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.Interfaces;
using Blog.Entity;
using Blog.MVC.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ISubject _subject;
        private readonly IMember _member;
        private readonly IComment _comment;
        private readonly ISubjectCategory _subjectCategory;
        public CategoryController(ISubjectCategory subjectCategory, ISubject subject, IMember member, IComment comment)
        {
            _subjectCategory = subjectCategory;
            _subject = subject;
            _member = member;
            _comment = comment;
        }
        public IActionResult Index(int? id)
        {            
            if(id==0)
            {
                return View(_subject.All());
            }else
            {
                List<CategorySubjectDTO> subjects = new List<CategorySubjectDTO>();
                var test = _subjectCategory.Find(y => y.CategoryID == id);
                foreach (var item in test.Select(x=>x.SubjectID).Distinct())
                {
                    var subject = _subject.Get(item);
                    var tempLastComment = _comment.getLastCommentBySubjectID(subject.ID);
                    subjects.Add(new CategorySubjectDTO
                    {
                        ID=item,
                        Content=(subject.Content.Length < 50) ? subject.Content : subject.Content.Substring(0, subject.Content.Length % 50),
                        Header = subject.Header,
                        Description= subject.Description,
                        CreatedDate= subject.CreatedDate,
                        Creater= _member.Get(x=>x.ID==subject.MemberID).Name,
                        LastComment = (tempLastComment.Length<50)? tempLastComment : tempLastComment.Substring(0, tempLastComment.Length %40),
                        LastMember = (_comment.getLastCommentMembersBySubjectID(subject.ID) != 0) ? _member.Get(_comment.getLastCommentMembersBySubjectID(subject.ID)).Name : "No Comment",
                        CommentCount = _comment.getCommentCountBySubjectID(subject.ID)
                    });
                }
                return View(subjects);
            }
           
        }

        public ActionResult SubjectDetails(int id)
        {
            SubjectDetailsDTO subjectDetailsDTO = null;
            var TempSubject = _subject.Get(id);
            var TempSubjectOfComment = _comment.Find(x => x.SubjectID == id);
            if(TempSubject!=null)
            {
                var tempSubjectMember = _member.Get(TempSubject.MemberID);
                subjectDetailsDTO = new SubjectDetailsDTO()
                {
                    ID = id,
                    Content = TempSubject.Content,
                    CreatedDate = TempSubject.CreatedDate,
                    Description = TempSubject.Description,
                    Header = TempSubject.Header,
                    Creater= tempSubjectMember.Name+" "+ tempSubjectMember.Surname

                };
                
                if (TempSubjectOfComment != null)
                { Member tempmember;
                    foreach (var item in _comment.Find(x => x.SubjectID == id))
                    {
                       tempmember= _member.Get(x => x.ID == item.MemberID);
                        subjectDetailsDTO.Comment.Add(new SubjectofCommentsDTO
                        {
                            Content = item.Content,
                            Date = item.CreatedDate,
                            Header = item.Header,
                            Sender = tempmember.Name+" "+tempmember.Surname
                        });
                    }
                }
            }
          
          
            return View(subjectDetailsDTO);
        }
    }
}