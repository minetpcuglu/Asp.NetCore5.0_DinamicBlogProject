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
    
    public class DashBoardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
       WriterManager writerManager = new WriterManager(new EfWriterRepository());

        Context c = new Context();
      
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
          
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();


            ViewBag.CountBlogTotel = blogManager.GetList().Count();
            ViewBag.CountBlogTotelWriter = blogManager.GetBlogListByWriter(writerId).Count();
            ViewBag.CountCategoryTotel = categoryManager.GetList().Count();
            return View();
        }
    }
}
