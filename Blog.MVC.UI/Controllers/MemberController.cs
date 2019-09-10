using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.Interfaces;
using Blog.DAL.Repository;
using Blog.Entity;
using Blog.MVC.UI.Filter;
using Blog.MVC.UI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.UI.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMember _member;
        private readonly ISubject _subject;
        //private readonly ICategory _category;
        public MemberController(IMember member, ISubject subject)
        {
            _member = member;
            _subject = subject;
        }
        [ServiceFilter(typeof(MemberFilterAttribute))]
        public IActionResult Index()
        {           
            return View();
        }
    }
}