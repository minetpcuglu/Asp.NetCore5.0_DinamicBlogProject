﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{


    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        WriterValidator validationRules = new WriterValidator();

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;  //sisteme giren kullanıcı adı soyadı
            ViewBag.value = userMail;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.value2 = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        [AllowAnonymous]

        public IActionResult WriterTextThema()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            //sisteme otantike olan kullanıcının bilgilerinin gelmesi
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var writervalue = writerManager.GetById(writerId);
            return View(writervalue);
        }

        [HttpPost]

        public async Task<IActionResult> WriterEditProfile(Writer writer, IFormFile file)
        {
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName); //uzantiya ulasmak //.jpg .png
                    var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");  //random bir sayı ile resim dosyaları birbirine çakışmaması
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomFileName);
                    writer.WriterImage = randomFileName;

                    using (var stream = new FileStream(path, FileMode.Create))  //using içinde olması isimiz bittiginde otamatşk silinecek olması.
                    {
                        await file.CopyToAsync(stream);
                    }
                }

               writerManager.Update(writer);

                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();






           
        }
    }
}
