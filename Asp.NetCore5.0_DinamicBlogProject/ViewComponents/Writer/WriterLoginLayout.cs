using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.ViewComponents.Writer
{
    public class WriterLoginLayout:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {

            var username = User.Identity.Name;  //sisteme giren kullanıcı adı soyadı
            ViewBag.value = username;
            Context c = new Context();

            var writerName = c.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.value2 = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.Image = writerImage;
            return View();
        }
    }
}
