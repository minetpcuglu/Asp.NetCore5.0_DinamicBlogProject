using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
       CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        BlogValidator blogRules = new BlogValidator();
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

        public IActionResult GetBlogListByWriterId(int id)
        {
            //ViewBag.id = 2;
            var value = blogManager.GetBlogListWithCategoryByWriter(1);
            return View(value);
        }


        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.value = categoryValue;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            ValidationResult result = blogRules.Validate(blog);
            if (result.IsValid )
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                blogManager.Add(blog);
                return RedirectToAction("GetBlogListByWriterId", "Blog");
            }
            else if (!result.IsValid)
            {
                foreach (var rule in result.Errors)
                {
                    ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage );
                }


            }
            
            return View();
           
        }
    }
}
