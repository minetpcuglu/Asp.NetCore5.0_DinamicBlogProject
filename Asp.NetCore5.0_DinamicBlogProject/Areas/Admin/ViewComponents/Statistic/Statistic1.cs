using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
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
        Context c = new Context(); //Toplam Yeni mesaj sayısı
       public IViewComponentResult Invoke()
        {
            ViewBag.totelBlog = blogManager.GetList().Count(); //toplam blog sayısı **birden fazla manager kulllanılcaksa viewbag kullan 
            ViewBag.totelNewMessage = c.Contacts.Count(); //toplam mesaj sayısı
            ViewBag.totelComment = c.Comments.Count(); //toplam yorum sayısı
            return View();
        }
    }
}
