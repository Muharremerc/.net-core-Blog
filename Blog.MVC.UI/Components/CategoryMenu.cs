using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.UI.Components
{
    public class CategoryMenu: ViewComponent
    {
        private readonly ICategory _category;
        public CategoryMenu(ICategory category)
        {
            _category = category;
        }

        public IViewComponentResult Invoke()
        {
            IQueryable test = _category.All().AsQueryable();
            return View(test);
        }
    }
}