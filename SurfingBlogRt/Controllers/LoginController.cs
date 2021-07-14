﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfingBlogRt.DAL;
using SurfingBlogRt.Helpers;
using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.Controllers
{
    public class LoginController : Controller
    {
        private DataContext _dataContext = new DataContext();

        public LoginController()
        {
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _dataContext.Users
                    .FirstOrDefaultAsync(u => u.Nickname == model.Nickname && u.Password == model.Password);
                if (user != null)
                {
                    await AuthenticateHelper.Authenticate(model.Nickname, model.RememberMe, HttpContext); // аутентификация

                    if (user.Photo.HasValue && Guid.Empty != user.Photo.Value)
                    {
                        HttpContext.Session.SetString("Photo", user.Photo.Value.ToString());
                    }

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неверный псевдоним или пароль!");
            }
            return View(model);
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }

}
