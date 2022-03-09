using Asp.NetCore5._0_DinamicBlogProject.Models.VMs;
using AutoMapper;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{

    
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public RegisterUserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserDTO model)
        {
            if (ModelState.IsValid) //moeldeki kurallar saglandıysa
            {
                //AppUser user = new AppUser()
                //{
                //    Email = model.Mail,
                //    UserName = model.UserName,
                //    Surname = model.NameSurname
                //};
                var appUser = _mapper.Map<AppUserDTO, AppUser>(model);
                var result = await _userManager.CreateAsync(appUser, model.Password); //identtiy kütüphanesinin kendi create metoduyla ekleme yaptık
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }





    }
}
