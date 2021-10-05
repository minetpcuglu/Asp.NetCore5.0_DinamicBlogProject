using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
           
            return View();
        }


        public IActionResult CommentListByBlog(int id)
        {
            var value = commentManager.GetList(id);
            return View(value);
        }

       

        [HttpGet]
        public PartialViewResult _CommentAddPartialView()
        {

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult _CommentAddPartialView(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogId = 2;
            commentManager.Add(comment);
            return PartialView();
        }
    }
}
