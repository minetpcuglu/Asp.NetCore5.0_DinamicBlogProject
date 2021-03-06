using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        AppUserManager userManager = new AppUserManager(new EfAppUserRepository());
        readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        WriterValidator validationRules = new WriterValidator();
        public WriterController(UserManager<AppUser> userManager ,SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


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

      

        public IActionResult WriterTextThema()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
           
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            EditProfileViewModel model = new EditProfileViewModel();
            model.Email = value.Email;
            model.Surname = value.Surname;
            model.ImageUrl = value.ImageUrl;
            model.UserName = value.UserName;
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> WriterEditProfile(EditProfileViewModel model, IFormFile file)
        {
       
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            value.UserName = model.UserName;
            value.Surname = model.Surname;
            value.Email = model.Email;
            value.ImageUrl = model.ImageUrl;
            value.PasswordHash = _userManager.PasswordHasher.HashPassword(value,model.Password);
          
            if (file != null)
            {

                var extension = Path.GetExtension(file.FileName); //uzantiya ulasmak //.jpg .png
                var randomFileName = string.Format($"{Guid.NewGuid()}{extension}");  //random bir sayı ile resim dosyaları birbirine çakışmaması
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomFileName);
                model.ImageUrl = randomFileName;

                using (var stream = new FileStream(path, FileMode.Create))  //using içinde olması isimiz bittiginde otamatşk silinecek olması.
                {
                    await file.CopyToAsync(stream);
                }
                var result = await _userManager.UpdateAsync(value);
            }
            return RedirectToAction("Index","Dashboard");
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Login");
        }
    }
   
}
