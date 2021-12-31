using Asp.NetCore5._0_DinamicBlogProject.Areas.Admin.Models;
using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult CategoryChart()
        //{
        //    return Json(CategoryList(), JsonRequestBehavior.AllowGet); //kullanılma izin ver 
        //}

        //public List<CategoryClass> CategoryList()
        //{
        //    List<CategoryClass> categoryVMs = new List<CategoryClass>();
        //    categoryVMs = c.Categories.Select(x => new CategoryClass
        //    {
        //        CategoryName = x.CategoryName,
        //        CategoryCount = x.CategoryName.Count(),

        //    }).ToList();

        //    return categoryVMs;
        //}

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 5
            });
            list.Add(new CategoryClass
            {
                categoryname = "Sinema",
                categorycount = 2
            });
            return Json(new { jsonList = list });
        }






    }
}
