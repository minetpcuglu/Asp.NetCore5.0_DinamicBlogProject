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
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        public IActionResult Inbox(int id) //gelen kutusu
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(writerId);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
           
            
            var value = message2Manager.GetById(id);
            return View(value);
        }
        
    }
}
