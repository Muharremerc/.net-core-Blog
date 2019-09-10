using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.Interfaces;
using Blog.Entity;
using Blog.MVC.UI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMember _member;
        public LoginController(IMember member)
        {
            _member = member;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Member member)
        {
            Member _Tempmember = _member.Get(x => x.Username == member.Username && x.Password == member.Password);
            if (_Tempmember != null)
            { HttpContext.Session.SetObjectAsJson("Member", _Tempmember);
                return RedirectToAction("Index","Member");
            }
            return RedirectToAction("Index","Login");
        }
    }
}