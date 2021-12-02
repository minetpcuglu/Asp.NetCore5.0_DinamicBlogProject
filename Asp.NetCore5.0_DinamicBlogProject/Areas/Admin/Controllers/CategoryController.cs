using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Asp.NetCore5._0_DinamicBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        CategoryValidator categoryRules = new CategoryValidator();
        public IActionResult Index( int page=1)
        {
            var value = categoryManager.GetList().ToPagedList(page,3);
            return View(value);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory( Category category)
        {
            ValidationResult result = categoryRules.Validate(category);

            if (result.IsValid)
            {
                category.CategoryStatus = true;


                categoryManager.Add(category);
                return RedirectToAction("Index", "Category");
            }
            else if (!result.IsValid)
            {
                foreach (var rule in result.Errors)
                {
                    ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage);
                }


            }

            return View();
           
        }
    }
}
