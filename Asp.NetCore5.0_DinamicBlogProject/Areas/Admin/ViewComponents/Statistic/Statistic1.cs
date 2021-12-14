using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository()); // toplam blog sayısı
       public IViewComponentResult Invoke()
        {
            ViewBag.totelBlog = blogManager.GetList().Count(); //toplam blog sayısı **birden fazla manager kulllanılcaksa viewbag kullan 
            return View();
        }
    }
}
