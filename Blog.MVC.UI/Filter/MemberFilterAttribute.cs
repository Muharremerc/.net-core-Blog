using Blog.DAL.Interfaces;
using Blog.Entity;
using Blog.MVC.UI.Helper;
using Blog.MVC.UI.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.MVC.UI.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.UI.Filter
{
    public class MemberFilterAttribute: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)

        {
            var tempmember = context.HttpContext.Session.GetObjectFromJson<Member>("Member");

            if (tempmember==null)
            {
                context.Result = new RedirectResult("/Login/Index");
            }
            return;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

       
    }
}
