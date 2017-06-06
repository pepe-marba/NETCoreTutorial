using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NETCoreTutorial.Models;
using NETCoreTutorial.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NETCoreTutorial.Controllers.Web
{
    public class AuthController : Controller
    {
        private SignInManager<WorldUser> _signInManager;
        private UserManager<WorldUser> _userManager;

        public AuthController(SignInManager<WorldUser> signInManager, UserManager<WorldUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Trips", "App");
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, true, false);

                    if (signInResult.Succeeded)
                    {
                        if (string.IsNullOrWhiteSpace(returnUrl))
                        {
                            return RedirectToAction("Trips", "App");
                        }
                        else
                        {
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User or passwrod incorrect");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateUserViewModel newUser)
        {
            if (ModelState.IsValid)
            {

                var userExists = await _userManager.FindByEmailAsync(newUser.Email);
                if ( userExists == null)
                {
                    var user = new WorldUser() {
                        UserName = newUser.UserName,
                        Email = newUser.Email
                    };

                    var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                    return Redirect("Login");
                }
                else
                {
                    ModelState.AddModelError("", "El Usuario ya existe");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error al crear usuario");
            }
            return View();
        }

        public async Task<ActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "App");
        }
    }
}
