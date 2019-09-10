using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.Interfaces;
using Blog.MVC.UI.Helper;
using Blog.Entity;
using Blog.MVC.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Blog.MVC.UI.Filter;

namespace Blog.MVC.UI.Controllers
{
    [ServiceFilter(typeof(MemberFilterAttribute))]
    public class SubjectController : Controller
    {
        private static List<int> SubjectID;
        private readonly ISubject _subject;
        private readonly ICategory _category;
        private readonly IMember _member;
        private readonly IComment _comment;
        private readonly ISubjectCategory _subjectCategory;
        private static int TempSubjectID = 0;

        public SubjectController(ISubject subject, ICategory category, ISubjectCategory subjectCategory, IComment comment, IMember member)
        {
            _subject = subject;
            _category = category;
            _subjectCategory = subjectCategory;
            _comment = comment;
            _member = member;

        }
        public IActionResult Index()
        {
            ViewBag.Category = _category.All();
            SubjectID = new List<int>();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SubjectViewDTO subject)
        {
            Subject myNeySubject = new Subject
            {
                Description = subject.Description,
                Content = subject.Content,
                Header = subject.Header,
                MemberID = HttpContext.Session.GetObjectFromJson<Member>("Member").ID,
                IsDeleted=false                
            };
            _subject.Add(myNeySubject);
            foreach (var item in SubjectID)
            {
                _subjectCategory.Add(new SubjectCategory {
                    CategoryID=item,
                    SubjectID=myNeySubject.ID                    
                });
            }
            return RedirectToAction("Index", "Member");
        }
    
        public ActionResult AddListOfCategory(int id)
        {
            if (SubjectID == null)
                SubjectID = new List<int>();
            if(!SubjectID.Contains(id))
                SubjectID.Add(id);
            var ListSubject = _category.All().Where(x => SubjectID.Contains(x.ID)).ToList();
            return PartialView("_SelectedCategoryList", ListSubject);
        }

        public ActionResult DeleteFromListofCategory(int id)
        {
            if (SubjectID.Contains(id))
                SubjectID.Remove(id);
            var ListSubject = _category.All().Where(x => SubjectID.Contains(x.ID)).ToList();
            return PartialView("_SelectedCategoryList", ListSubject);
        }


        public ActionResult SubjectOfComments(int SubjectID)
        {
            if (SubjectID != 0)
                TempSubjectID = SubjectID;
            return View();
        }

        public ActionResult AcceptComment(int id)
        {
            var Comment = _comment.Get(id);
            if (Comment != null)
            { Comment.Accepted = true;
                _comment.Update(Comment);
            }
            return Json(true);
        }

        public ActionResult _SubjectOfCommentList()
        {
            var CommentList = _comment.Find(x => x.Accepted == false && x.SubjectID == TempSubjectID);
            if (CommentList != null)
                return PartialView("_SubjectOfCommentList", CommentList);
            else return PartialView("_SubjectOfCommentList", null);


        }

        public ActionResult Comments(int id)
        {
            var CommentList = _comment.Find(X => X.SubjectID == id);
            List<SubjectofCommentsDTO> returnValue = new List<SubjectofCommentsDTO>();
            if (CommentList != null)
            {
                returnValue = CommentList.Select(x => new SubjectofCommentsDTO { Content = x.Content, Date = x.CreatedDate, Header = x.Header, Sender = _member.Get(x.MemberID).Name }).ToList();

            }
                return View(returnValue);
        }

    }
}