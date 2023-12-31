﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eduker.ViewModels.LoginVm;

namespace Eduker.Controllers
{
    [Route("/login")]
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;


        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] LoginVm loginVm)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser(loginVm.Name);

                var result = await _signInManager.PasswordSignInAsync(loginVm.Name, loginVm.Password, false, false);

                if (result.Succeeded)
                {
                    Response.Cookies.Append("Username", $"{loginVm.Name}");
                    var signInUser = await _userManager.FindByNameAsync(loginVm.Name);
                    var signInUserRole = await _userManager.GetRolesAsync(signInUser);

                    if (signInUserRole.First() == "ban")
                    {
                        return Forbid();
                    }

                    if (await _userManager.IsInRoleAsync(signInUser, "admin"))
                    {
                        return Redirect("/admin");
                    }

                    return RedirectToAction("index", "home");
                }

                return Redirect("/404");
            }

            return await Index();
        }
    }
}