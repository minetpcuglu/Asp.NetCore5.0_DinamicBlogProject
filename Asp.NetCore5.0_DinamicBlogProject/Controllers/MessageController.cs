using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        Context c = new Context();
        public IActionResult Inbox(int id) //gelen kutusu
        {
            
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

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 message)
        {
            var userName = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var WriterId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            message.SenderId = WriterId;
            message.ReceiverId = 2;
            message.MessageStatus = true;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2Manager.Add(message) ;
            return RedirectToAction("Inbox");
        }


      
        public  IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = message2Manager.GetSendboxListByWriter(writerId);
            return View(values);
        }

    }
}
