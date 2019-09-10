using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.Interfaces;
using Blog.Entity;
using Blog.MVC.UI.Filter;
using Blog.MVC.UI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.UI.Controllers
{
    [ServiceFilter(typeof(MemberFilterAttribute))]
    public class CommentController : Controller
    {
        private readonly IComment _comment;
        private static int Id;
        public CommentController(IComment comment)
        {
            _comment = comment;
        
        }
        public IActionResult Index(int id)
        {
            Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult CreateComment(Comment comment)
        {
            var tempmember = HttpContext.Session.GetObjectFromJson<Member>("Member");
            comment.SubjectID = Id;
            comment.MemberID = tempmember.ID;
            _comment.Add(comment);
            return RedirectToAction("SubjectDetails", "Category", new { id = comment.SubjectID });
        }
    }
}