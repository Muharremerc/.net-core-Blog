using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.Interfaces;
using Blog.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMember _member;
        public RegisterController(IMember member)
        {
            _member = member;
        }                    

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Member member)
        {
            if(_member.Get(x => x.Username == member.Username) ==null)
                _member.Add(member);
            else
                return RedirectToAction("Index", "Register");

            return RedirectToAction("Index","Login");
        }
        
        [HttpPost]
        public ActionResult CheckUsername(string username)
        {

            bool result;
            Member _Tempmember = _member.Get(x => x.Username == username);
            if (_Tempmember == null)
                result = true;
            else
                result = false;
            return Json(result);
        }
    }
}