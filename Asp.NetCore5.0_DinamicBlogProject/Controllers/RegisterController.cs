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

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        WriterValidator writerRules = new WriterValidator();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(Writer writer, string city , string againPassword)
        {
            ValidationResult result = writerRules.Validate(writer);
            if (result.IsValid && writer.WriterPassword==againPassword)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme";
                writerManager.Add(writer);
                return RedirectToAction("Index", "Blog");
            }
            else if(!result.IsValid)
            {
                foreach (var rule in result.Errors)
                {
                    ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage);
                }
        
                                        
            }
            else
            {
                ModelState.AddModelError("WriterPassword", "Hatalı giriş. Girilen şifreler eşleşmedi tekrar deneyiniz.");
            }
            return View();
      
        }
    }
}
