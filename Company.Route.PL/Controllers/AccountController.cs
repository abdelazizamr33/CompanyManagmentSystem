using Company.Route.DAL.Models;
using Company.Route.PL.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using NuGet.DependencyResolver;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Company.Route.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // P@$sw0rd
        #region Signup

        [HttpGet] //Account/SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        //P@$sw0rd
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var user=await _userManager.FindByNameAsync(model.UserName);
                if(user is null)
                {
                    user=await _userManager.FindByEmailAsync(model.Email);
                    if(user is null)
                    {
                        user = new AppUser()
                        {
                            UserName = model.UserName,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            IsAgree = model.IsAgree
                        };
                        var result = await _userManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {
                            // Send Email to confirm Email
                            return RedirectToAction("SignIn");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                ModelState.AddModelError("", "Invalid SignUp");


            }
            return View();
        }

        #endregion

        #region Signin

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var flag = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
                    {
                        //Sign in
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false); // Making Token 
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }

                    }
                }
                ModelState.AddModelError("", "Invalid Login");
            }
            return View();
        }


        #endregion

        #region Signout
        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }

        #endregion
    }
}
