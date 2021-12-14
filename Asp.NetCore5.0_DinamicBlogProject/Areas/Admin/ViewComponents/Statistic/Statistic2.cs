using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        Context c = new Context(); //Toplam Yeni mesaj sayısı
        public IViewComponentResult Invoke()
        {

            ViewBag.lastBlog = c.Blogs.OrderByDescending(x=>x.BlogId).Select(x => x.BlogTitle).Take(1).FirstOrDefault();//son eklenen blog
            ViewBag.totelComment = c.Comments.Count(); //toplam yorum sayısı
            return View();
        }
    }
}
