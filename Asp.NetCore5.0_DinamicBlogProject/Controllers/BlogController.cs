using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var value = blogManager.GetBlogListWithCategory();
            return View(value);
        }

        public IActionResult BlogReadAll(int id)
        {
            //Comment içi ID den gelen degeri belirleme
            ViewBag.Id = id;
            var value = blogManager.GetBlogById(id);
            return View(value);
        }
    }
}
