using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{
    [AllowAnonymous]
    public class DashBoardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
       WriterManager writerManager = new WriterManager(new EfWriterRepository());
      
        public IActionResult Index()
        {
            ViewBag.CountBlogTotel = blogManager.GetList().Count();
            ViewBag.CountBlogTotelWriter = blogManager.GetBlogListByWriter(1).Count();
            ViewBag.CountCategoryTotel = categoryManager.GetList().Count();
            return View();
        }
    }
}
