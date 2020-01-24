using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeukenhofWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KeukenhofWebsite.Controllers
{
    public class InlogController : Controller
    {
        private UserManager<Administrator> UserMgr { get; }
        private SignInManager<Administrator> SignInMgr { get; }

        
        public InlogController(UserManager<Administrator> userManager,
            SignInManager<Administrator> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already registered.";

                Administrator user = await UserMgr.FindByNameAsync("TestUser");
                if (user == null)
                {
                    user = new Administrator();
                    user.UserName = "TestUser";
                    user.Email = "TestUser@test.com";
                    user.FirstName = "John";
                    user.LastName = "Doe";

                    IdentityResult result = await UserMgr.CreateAsync(user, "Test123!");
                    ViewBag.Message = "User was created!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

        public async Task<IActionResult> Login()
        {
            var result = await SignInMgr.PasswordSignInAsync("TestUser", "Test123!", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Result = "Result is: " + result.ToString();
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("_Hoofdpagina", "Home");
        }
    }
}