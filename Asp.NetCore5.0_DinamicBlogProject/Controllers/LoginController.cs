using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject.Controllers
{
    
    public class LoginController : Controller
    {
        readonly SignInManager<AppUser> _signInManager;
        public LoginController( SignInManager<AppUser> signInManager)
        {
     
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDTO P)
        {
            var result = await _signInManager.PasswordSignInAsync(P.UserName, P.Password, true, true); //perssitent true cerezlerde şifreyi hatırlasın //5 kez yanlıs giriş yaparsa hesap bloke olcak belli süre
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Hatalı Kullanıcı Adı/Şifre");
                return View();
            }


        }


    }
}
